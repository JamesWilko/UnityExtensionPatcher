using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Mono.Cecil;
using UnityExtensionPatcher.Data;
using UnityExtensionPatcher.Windows;

namespace UnityExtensionPatcher
{
    public partial class NewPatcherWindow : Form
    {
        public NewPatcherWindow()
        {
            InitializeComponent();

			// Setup drag-drop for assemblies
			this.AllowDrop = true;
			this.DragEnter += NewPatcherWindow_DragEnter;
			this.DragDrop += NewPatcherWindow_DragDrop;
        }

		ProjectManifest CurrentProject {
			get { return Program.CurrentProject; }
			set { Program.CurrentProject = value; }
		}
		bool HasLoadedProject { get { return CurrentProject != null; } }

		public MRUController MostRecentList;
		Dictionary<string, AssemblyData> loadedAssemblies = new Dictionary<string, AssemblyData>();
		Dictionary<TreeNode, ProjectAssembly> projectAssemblies = new Dictionary<TreeNode, ProjectAssembly>();

		const string APPLICATION_NAME = "UnityExtensionPatcher";
		const int MAX_MOST_RECENT = 10;

		private void NewPatcherWindow_Load(object sender, EventArgs e)
		{
			MostRecentList = new MRUController(APPLICATION_NAME, MAX_MOST_RECENT, menuMostRecent, LoadMostRecentProject);

			UpdateProjectTreeView();
			UpdateAssemblyTreeView();
        }

		public void UpdateProjectTreeView()
		{
			// Remove all previous nodes
			projectTree.Nodes.Clear();

			if(CurrentProject != null)
			{
				// Add project settings node
				TreeNode projectSettingsNode = projectTree.Nodes.Add("Project Settings");
				projectSettingsNode.ImageKey = "gear.png";
				projectSettingsNode.SelectedImageKey = "gear.png";

				// Add project assemblies node
				TreeNode assembliesNode = projectTree.Nodes.Add("Assemblies");
				assembliesNode.ImageKey = "databases.png";
				assembliesNode.SelectedImageKey = "databases.png";

				// Add project assemblies
				projectAssemblies.Clear();
                foreach (ProjectAssembly assembly in CurrentProject.Assemblies)
				{
					TreeNode assemblyNode = assembliesNode.Nodes.Add(assembly.Path);
					string imageKey = assembly.Load ? "database--plus.png" : "database--minus.png";
                    assemblyNode.ImageKey = imageKey;
					assemblyNode.SelectedImageKey = imageKey;

					projectAssemblies.Add(assemblyNode, assembly);
                }

				assembliesNode.Expand();
			}
			else
			{
				// No project loaded node
				TreeNode noProjectNode = projectTree.Nodes.Add("No Project Loaded");
				noProjectNode.ImageKey = "exclamation-button.png";
				noProjectNode.SelectedImageKey = "exclamation-button.png";
			}			
		}

        public void UpdateAssemblyTreeView()
        {
            // Remove all previous nodes
            assemblyTree.Nodes.Clear();

			if (HasLoadedProject)
			{
				// Load all assemblies in the project
				loadedAssemblies.Clear();
				foreach (var assembly in CurrentProject.Assemblies)
				{
					string path = Path.Combine(CurrentProject.ProjectFolder, assembly.Path);
					LoadAssembly(path);
                }

				// Add each assembly data to the tree
				foreach (var loadedAssembly in loadedAssemblies)
				{
					AddAssemblyToTree(loadedAssembly.Value);
				}
			}
        }

		private void LoadAssembly(string path)
		{
			try
			{
				ModuleDefinition module = ModuleDefinition.ReadModule(path);
				if (module != null)
				{
					// Add the assembly module to our dictionary
					AssemblyData assemblyData = new AssemblyData(path, module);
					loadedAssemblies.Add(path, assemblyData);

					// Create global namespace
					assemblyData.AddNamespace("", new NamespaceData("global"));
					NamespaceData namespaceData;

					// Find namespaces in the loaded assembly
					foreach (TypeDefinition type in module.Types)
					{
						bool existingNamespace = assemblyData.Namespaces.TryGetValue(type.Namespace, out namespaceData);
						if (!existingNamespace)
						{
							namespaceData = new NamespaceData(type.Namespace);
							assemblyData.AddNamespace(type.Namespace, namespaceData);
						}
						namespaceData.Add(type);

					}
				}
			}
			catch(Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
				string nodeString = $"Could not load assembly: {path}";
				TreeNode node = assemblyTree.Nodes.Add(nodeString);
				node.ImageKey = "exclamation-red-frame.png";
				node.SelectedImageKey = "exclamation-red-frame.png";
			}
		}

		private void AddAssemblyToTree(AssemblyData assemblyData)
		{
			// Add node for loaded assembly
			TreeNode assemblyNode = assemblyTree.Nodes.Add(assemblyData.Definition.Name);
			assemblyNode.ToolTipText = $"Location: {assemblyData.Path}";
            assemblyNode.ImageKey = "Assembly.png";
			assemblyNode.SelectedImageKey = "Assembly.png";

			// Add nodes from assemblies
			foreach (KeyValuePair<string, NamespaceData> namespacePair in assemblyData.Namespaces)
			{
				NamespaceData data = namespacePair.Value;
				TreeNode namespaceNode = assemblyNode.Nodes.Add(data.Name);
				namespaceNode.ImageKey = "NameSpace.png";
				namespaceNode.SelectedImageKey = "NameSpace.png";

				// Populate namespace types
				foreach (TypeDefinition type in data.Types)
				{
					string typeName = type.Name;

					// Check if the type has any generic parameters
					if (type.HasGenericParameters)
					{
						// Build a string using the type name and the generic parameter names
						string[] splitTypeName = typeName.Split('`');
						string parametersString = "";
						foreach (GenericParameter param in type.GenericParameters)
						{
							string separator = parametersString.Length > 0 ? ", " : "";
							parametersString = string.Format("{0}{1}{2}", parametersString, separator, param.Name);
						}
						typeName = string.Format("{0}<{1}>", splitTypeName[0], parametersString);
					}

					// Add the type node
					TreeNode typeNode = namespaceNode.Nodes.Add(typeName);
					typeNode.ImageKey = "Class.png";
					typeNode.SelectedImageKey = "Class.png";
				}
			}
		}

		private void menuQuit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void menuNewProject_Click(object sender, EventArgs e)
		{
			NewProjectWindow window = new NewProjectWindow();
			window.ShowDialog();
			UpdateProjectTreeView();
			UpdateAssemblyTreeView();
		}

		private void menuOpenProject_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog()
			{
				AddExtension = true,
				CheckFileExists = true,
				DefaultExt = ProjectManifest.PROJECT_MANIFEST_EXTENSION,
				Filter = $"{ProjectManifest.PROJECT_MANIFEST_EXTENSION}|*{ProjectManifest.PROJECT_MANIFEST_EXTENSION}",
				Multiselect = false,
                ValidateNames = true,
			};
			var result = dialog.ShowDialog();
			if(result == DialogResult.OK)
			{
				LoadProject(dialog.FileName);
            }
        }

		private void menuCloseProject_Click(object sender, EventArgs e)
		{
			CloseProject();
        }

		private void LoadMostRecentProject(object sender, EventArgs e)
		{
			string path = sender.ToString();

			// Check project exists
			if(File.Exists(path))
			{
				LoadProject(sender.ToString());
			}
			else
			{

				// Project doesn't exist, check if we should remove it from the list
				DialogResult result = MessageBox.Show($"Could not find project at '{sender}'.{Environment.NewLine}{Environment.NewLine}Do you want to remove it from the list?", "Could Not Open Project", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					MostRecentList.Remove(sender.ToString());
				}
			}
		}

		private void LoadProject(string path)
		{
			try
			{
				CloseProject();
				CurrentProject = ProjectManifest.Load(path);

				MostRecentList.AddOrUpdate(path);
				UpdateProjectTreeView();
				UpdateAssemblyTreeView();
			}
			catch(Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
			}
		}

		private void CloseProject()
		{
			loadedAssemblies.Clear();
			CurrentProject = null;
			UpdateProjectTreeView();
			UpdateAssemblyTreeView();
		}

		#region Drag-Drop

		private void NewPatcherWindow_DragEnter(object sender, DragEventArgs eventArgs)
		{
			if (HasLoadedProject && eventArgs.Data.GetDataPresent(DataFormats.FileDrop))
			{
				eventArgs.Effect = DragDropEffects.Copy;
			}
		}

		private void NewPatcherWindow_DragDrop(object sender, DragEventArgs eventArgs)
		{
			if (HasLoadedProject)
			{
				string[] files = (string[])eventArgs.Data.GetData(DataFormats.FileDrop);
				List<string> ignoredFiles = new List<string>();

				// Go through all dragged files and process them
				foreach (string file in files)
				{
					// Only add DLL assemblies
					if (Path.HasExtension(file) && Path.GetExtension(file) == AssemblyData.ASSEMBLY_EXTENSION)
					{
						string fileName = Path.GetFileName(file);
                        string fileDestination = Path.Combine(CurrentProject.ProjectFolder, fileName);

						// Check if file already exists in project
						if(File.Exists(fileDestination))
						{
							ignoredFiles.Add(fileName);
                            continue;
						}

						// Copy file, and add to project
                        File.Copy(file, fileDestination);
						CurrentProject.AddAssembly(fileName);
					}
				}

				// Display any files that were not added to the project
				if(ignoredFiles.Count > 0)
				{
					string message = $"Failed to import files:{Environment.NewLine}";
					foreach(string file in ignoredFiles)
					{
						message = $"{message}{file}{Environment.NewLine}";
                    }
					MessageBox.Show(message, "Import Failed");
                }

				// Update view
				UpdateProjectTreeView();
				UpdateAssemblyTreeView();
			}
		}

		#endregion

		#region Project Assemblies Context Menu

		private void projectTree_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				// Select the node we clicked on in the tree
				projectTree.SelectedNode = projectTree.GetNodeAt(e.X, e.Y);
				if (projectTree.SelectedNode != null)
				{
					// Clicked an assembly, show the assemblies context menu
					if (projectAssemblies.ContainsKey(projectTree.SelectedNode))
					{
						contextProjectAssembly.Show(projectTree, e.Location);
					}
				}
			}
		}

		private void includeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (projectAssemblies.ContainsKey(projectTree.SelectedNode))
			{
				// Remove the assembly from the project
				CurrentProject.RemoveAssembly(projectAssemblies[projectTree.SelectedNode]);

				// Update the view
				UpdateProjectTreeView();
				UpdateAssemblyTreeView();
			}
		}

		#endregion
	}
}
