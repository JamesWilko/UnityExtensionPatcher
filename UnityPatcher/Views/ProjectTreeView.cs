using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UnityPatcher.Data;

namespace UnityPatcher.Views
{
	public class ProjectTreeView
	{
		protected TreeImageView parentView;
		protected TreeView parentTree;

		public ProjectTreeView(TreeImageView parentView)
		{
			this.parentView = parentView;
			this.parentTree = parentView.treeView;

			ProjectManifest.OnProjectUpdated += Update;

			Update();
        }

		~ProjectTreeView()
		{
			ProjectManifest.OnProjectUpdated -= Update;
		}

		public void Update()
		{
			parentTree.Items.Clear();

			if (!App.HasProject)
			{
				parentTree.Items.Add("No Project");
				return;
			}

			ProjectManifest project = App.CurrentProject;

			// Add project settings
			TreeViewItem settingsItem = new TreeViewItem()
			{
				Header = "Project Settings",
				DataContext = "cog.png"
			};
			parentTree.Items.Add(settingsItem);

			// Add assemblies
			TreeViewItem assembliesItem = new TreeViewItem()
			{
				Header = "Assemblies",
				DataContext = "folder_database.png",
                IsExpanded = true,
			};
			parentTree.Items.Add(assembliesItem);

			foreach(var assembly in project.Assemblies)
			{
				// Create assembly node
				TreeViewItem newAssemblyItem = new TreeViewItem()
				{
					Header = assembly.Path,
					DataContext = assembly.Load ? "database_add.png" : "database_delete.png",
				};

				// Add node context menu
				newAssemblyItem.ContextMenu = new ContextMenu();
				var toggleInclusion = new MenuItem();
				toggleInclusion.Header = assembly.Load ? "Exclude" : "Include";
				toggleInclusion.Click += (object sender, RoutedEventArgs e) =>
				{
					assembly.SetLoad(!assembly.Load);
                };
				newAssemblyItem.ContextMenu.Items.Add(toggleInclusion);

				var removeItem = new MenuItem();
				removeItem.Header = "Remove";
				removeItem.Click += (object sender, RoutedEventArgs e) =>
				{
					App.CurrentProject.RemoveAssembly(assembly);
					App.CurrentProject.RequestUpdate();
                };
				newAssemblyItem.ContextMenu.Items.Add(removeItem);

				// Add assembly to tree
				assembliesItem.Items.Add(newAssemblyItem);
			}

			// Add hooks
			TreeViewItem hooksItem = new TreeViewItem()
			{
				Header = "Hooks",
				DataContext = "folder_page.png",
				IsExpanded = true,
			};
			parentTree.Items.Add(hooksItem);
		}
	}

}
