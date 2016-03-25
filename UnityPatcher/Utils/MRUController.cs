using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UnityPatcher.Utils
{

	public class MRUController
	{
		public string ApplicationName { get; private set; }
		public string SubKeyName { get; private set; }
		public int MaximumEntries { get; private set; }
		public Action<string> OnRecentFileClicked { get; private set; }
		public MenuItem ParentMenuItem { get; private set; }

		public MRUController(string applicationName, int maxEntries, MenuItem parentMenu, Action<string> onRecentFileClick)
		{
			this.ApplicationName = applicationName;
			this.MaximumEntries = maxEntries;
			this.ParentMenuItem = parentMenu;
			this.SubKeyName = $"Software\\{this.ApplicationName}\\MRU";
			this.OnRecentFileClicked = onRecentFileClick;

			Update();
		}

		public void AddOrUpdate(string fileName)
		{
			RegistryKey registryKey = null;

			try
			{
				// Get key from the registry
				registryKey = Registry.CurrentUser.CreateSubKey(SubKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
				if (registryKey == null)
				{
					return;
				}

				// Get the old recent files list
				var recentFiles = registryKey.GetValueNames();
				var oldRecentFiles = recentFiles.Select(file => (string)registryKey.GetValue(file, null));
				oldRecentFiles = oldRecentFiles.Where(file => file != fileName && file != null);

				// Create the new recent files
				var newRecentFiles = new List<string>();
				newRecentFiles.Add(fileName);
				newRecentFiles.AddRange(oldRecentFiles);

				// Remove all previous recent files in the registry
				foreach (var file in recentFiles)
				{
					registryKey.DeleteValue(file, true);
				}

				// Add the new recent files list
				int limit = Math.Min(newRecentFiles.Count, this.MaximumEntries);
				for (var i = 0; i < limit; ++i)
				{
					registryKey.SetValue(i.ToString(), newRecentFiles[i]);
				}

				registryKey.Close();

			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
				registryKey?.Dispose();
				return;
			}

			// Update the MRU list on the form
			Update();
		}

		public void Remove(string fileName)
		{
			RegistryKey registryKey = null;

			try
			{
				// Get key from the registry
				registryKey = Registry.CurrentUser.CreateSubKey(SubKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
				if (registryKey == null)
				{
					return;
				}

				// Check the files in the list and remove it
				var recentFiles = registryKey.GetValueNames();
				foreach (var file in recentFiles)
				{
					string registryName = (string)registryKey.GetValue(file, null);
					if (registryName != null && registryName == fileName)
					{
						registryKey.DeleteValue(file, true);
					}
				}

				registryKey.Close();

			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
				registryKey?.Dispose();
				return;
			}

			// Update the MRU list on the form
			Update();
		}

		protected void Update()
		{
			RegistryKey registryKey = null;

			try
			{
				// Get the key from the registry
				registryKey = Registry.CurrentUser.OpenSubKey(SubKeyName, false);
				if (registryKey == null)
				{
					return;
				}

				// Remove the old list
				ParentMenuItem.Items.Clear();

				// Find the most recent files
				var recentFiles = registryKey.GetValueNames();
				var recentFileList = recentFiles.Select(entry => (string)registryKey.GetValue(entry));
				recentFileList = recentFileList.Where(file => file != null);

				// Populate the most recent files list
				foreach (var file in recentFileList)
				{
					var recentFileButton = new MenuItem();
					recentFileButton.Header = file;
					recentFileButton.Click += RecentFileButton_Click;
					ParentMenuItem.Items.Add(recentFileButton);
				}

				// Add a clear list button 
				AddClearRecentButton();
            }
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
				registryKey?.Dispose();
				return;
			}
		}

		protected void AddClearRecentButton()
		{
			ParentMenuItem.Items.Add(new Separator());

			var clearRecentButton = new MenuItem();
			clearRecentButton.Header = "Clear Recent Files";
			clearRecentButton.Click += ClearRecentButton_Click;
			ParentMenuItem.Items.Add(clearRecentButton);
		}

		private void RecentFileButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if(OnRecentFileClicked != null)
				OnRecentFileClicked((sender as MenuItem).Header.ToString());
        }

		private void ClearRecentButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			ClearList(sender, e);
        }

		private void ClearList(object sender, EventArgs e)
		{
			// Get registry key
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(SubKeyName, true);
			if (registryKey == null)
			{
				return;
			}

			// Get all files in the list and remove them
			var recentFiles = registryKey.GetValueNames();
			foreach (var file in recentFiles)
			{
				registryKey.DeleteValue(file, true);
			}

			// Clear the list in the editor
			ParentMenuItem.Items.Clear();
			AddClearRecentButton();
		}
	}

}
