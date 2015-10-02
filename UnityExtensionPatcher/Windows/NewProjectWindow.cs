using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace UnityExtensionPatcher.Windows
{
	public partial class NewProjectWindow : Form
	{
		public NewProjectWindow()
		{
			InitializeComponent();
		}

		private void btnLocationBrowse_Click(object sender, EventArgs e)
		{
			var folderDialog = new Ookii.Dialogs.VistaFolderBrowserDialog();
			var folderResult = folderDialog.ShowDialog();
			if (folderResult == DialogResult.OK)
			{
				textLocation.Text = folderDialog.SelectedPath;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(textLocation.Text) || string.IsNullOrEmpty(textName.Text) || !Directory.Exists(textLocation.Text))
			{
				return;
			}

			// Create project manifest
			Program.CurrentProject = new Data.ProjectManifest(textLocation.Text, textName.Text);
			Program.CurrentProject.Save();

			Program.Window.UpdateProjectTreeView();
			Program.Window.UpdateAssemblyTreeView();

			// Close create project dialog
			this.Close();
		}
	}
}
