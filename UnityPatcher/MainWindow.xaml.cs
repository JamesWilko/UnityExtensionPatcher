using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnityPatcher.Data;
using UnityPatcher.Utils;
using UnityPatcher.Views;
using Ookii.Dialogs;

using Path = System.IO.Path;
using Mono.Cecil;

namespace UnityPatcher
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ProjectManifest CurrentProject {
			get { return App.CurrentProject; }
			set { App.CurrentProject = value; }
		}
		bool HasLoadedProject { get { return CurrentProject != null; } }

		ProjectTreeView projectTreeView;
		AssemblyTreeView assemblyTreeView;
		MRUController mostRecentList;

		const string APPLICATION_NAME = "UnityPatcher";
		const int MAX_MOST_RECENT = 10;

		public MainWindow()
		{
			InitializeComponent();

			// Listen to events
			ProjectManifest.OnNewProjectCreated += ProjectManifest_OnNewProjectCreated;
			App.OnProjectUpdated += App_OnProjectUpdated;

			// Setup views
			projectTreeView = new ProjectTreeView(treeProjectView);
			assemblyTreeView = new AssemblyTreeView(treeAssemblies, tabControl);

			// Setup most recent projects list
			mostRecentList = new MRUController(APPLICATION_NAME, MAX_MOST_RECENT, menuRecentProject, LoadRecentProject);

			// Setup drag-drop for assemblies
			this.AllowDrop = true;
			this.Drop += MainWindow_Drop;			
		}

		~MainWindow()
		{
			ProjectManifest.OnNewProjectCreated -= ProjectManifest_OnNewProjectCreated;
			App.OnProjectUpdated -= App_OnProjectUpdated;
		}

		#region Data Management

		private void ProjectManifest_OnNewProjectCreated(ProjectManifest manifest)
		{
			mostRecentList.AddOrUpdate(manifest.ProjectFile);
		}

		private void App_OnProjectUpdated()
		{
			CurrentProject.RequestUpdate();
		}

		private void CloseProject()
		{
			if (CurrentProject != null)
			{
				CurrentProject = null;
				ProjectManifest.PerformRequestUpdate();
            }
		}

		private void LoadProject(string path)
		{
			try
			{
				CloseProject();
				CurrentProject = ProjectManifest.Load(path);
				mostRecentList.AddOrUpdate(path);
				CurrentProject.RequestUpdate();
			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
			}
		}

		private void LoadRecentProject(string path)
		{
			// Check project exists
			if (File.Exists(path))
				LoadProject(path);
			else
			{
				// Project doesn't exist, check if we should remove it from the list
				var result = MessageBox.Show($"Could not find project at '{path}'.{Environment.NewLine}{Environment.NewLine}Do you want to remove it from the list?", "Could Not Open Project", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					mostRecentList.Remove(path);
				}
			}
		}

		#endregion

		#region Menu Events

		private void menuNewProject_Click(object sender, RoutedEventArgs e)
		{
			var newProject = new NewProjectWindow();
			newProject.Show();
		}

		private void menuOpenProject_Click(object sender, RoutedEventArgs e)
		{
			var dialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog()
			{
				AddExtension = true,
				CheckFileExists = true,
				DefaultExt = ProjectManifest.PROJECT_MANIFEST_EXTENSION,
				Filter = $"{ProjectManifest.PROJECT_MANIFEST_EXTENSION}|*{ProjectManifest.PROJECT_MANIFEST_EXTENSION}",
				Multiselect = false,
				ValidateNames = true,
			};
			var result = dialog.ShowDialog();
			if (result.Value)
				LoadProject(dialog.FileName);
		}

		private void menuCloseProject_Click(object sender, RoutedEventArgs e)
		{
			CloseProject();
		}

		private void MainWindow_Drop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			List<string> ignoredFiles = new List<string>();

			// Go through all dragged files and process them
			foreach (string file in files)
			{
				// Add drag-dropped file
				if (!AddDragDropFileToProject(file, true))
					ignoredFiles.Add(file);

				// Add reference files
				ModuleDefinition module = ModuleDefinition.ReadModule(file);
				if (module != null)
				{
					var dllPath = file.Replace(Path.GetFileName(file), string.Empty);

					var builder = new StringBuilder();
					builder.AppendLine("Imported referenced assemblies:");
					foreach (var refAssembly in module.AssemblyReferences)
					{
						var referenceAssembly = Path.Combine(dllPath, refAssembly.Name) + AssemblyData.ASSEMBLY_EXTENSION;
						AddDragDropFileToProject(referenceAssembly, false);
						builder.AppendLine(refAssembly.Name);
                    }
					MessageBox.Show(builder.ToString(), "Imported References");
				}
			}

			// Display any files that were not added to the project
			if (ignoredFiles.Count > 0)
			{
				StringBuilder builder = new StringBuilder();
				builder.AppendLine("Files already exist in project environment:");
                foreach (string file in ignoredFiles)
					builder.AppendLine(file);
				MessageBox.Show(builder.ToString(), "Import Failed");
			}

			CurrentProject.RequestUpdate();
		}

		private bool AddDragDropFileToProject(string filePath, bool autoInclude)
		{
			// Only add DLL assemblies
			if (Path.HasExtension(filePath) && Path.GetExtension(filePath) == AssemblyData.ASSEMBLY_EXTENSION)
			{
				string fileName = Path.GetFileName(filePath);
				string fileDestination = Path.Combine(CurrentProject.ProjectFolder, fileName);

				// Check if file doesn't already exist in project
				if (!CurrentProject.AssemblyExists(fileName))
				{
					// Copy to destination if needed
					if (!File.Exists(fileDestination))
						File.Copy(filePath, fileDestination);

					CurrentProject.AddAssembly(fileName, autoInclude);
					return true;
				}
			}
			return false;
		}

		#endregion

	}
}
