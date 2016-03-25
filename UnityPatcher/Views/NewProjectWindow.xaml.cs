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
using System.Windows.Shapes;

namespace UnityPatcher.Views
{
	/// <summary>
	/// Interaction logic for NewProjectWindow.xaml
	/// </summary>
	public partial class NewProjectWindow : Window
	{
		public NewProjectWindow()
		{
			InitializeComponent();
		}

		private void buttonBrowse_Click(object sender, RoutedEventArgs e)
		{
			var folderDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
			var folderResult = folderDialog.ShowDialog();
			if (folderResult.HasValue && folderResult.Value)
			{
				textBoxLocation.Text = folderDialog.SelectedPath;
			}
		}

		private void buttonCreate_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxLocation.Text) ||
				string.IsNullOrEmpty(textBoxName.Text) ||
				!Directory.Exists(textBoxLocation.Text))
			{
				return;
			}

			// Create project manifest
			App.CurrentProject = new Data.ProjectManifest(textBoxLocation.Text, textBoxName.Text);
			App.CurrentProject.Save();

			// Add project to the most recent projects list
			// Program.Window.MostRecentList.AddOrUpdate(Program.CurrentProject.ProjectFile);

			// Close create project dialog
			this.Close();
		}

		private void buttonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
