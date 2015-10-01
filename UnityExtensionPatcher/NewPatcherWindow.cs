using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mono.Cecil;
using UnityExtensionPatcher.Data;

namespace UnityExtensionPatcher
{
    public partial class NewPatcherWindow : Form
    {
        public NewPatcherWindow()
        {
            InitializeComponent();
        }

        string[] debugAssemblies = new string[] {
			@"Assembly-CSharp.dll",
			@"Assembly-CSharp - Copy.dll",
            @"Mono.Cecil.dll"
		};
		Dictionary<string, AssemblyData> loadedAssemblies = new Dictionary<string, AssemblyData>();

		private void NewPatcherWindow_Load(object sender, EventArgs e)
		{
			// Load assemblies
			foreach(string assemblyPath in debugAssemblies)
			{
				LoadAssembly(assemblyPath);
            }

			// Update tree view hierarchy 
			UpdateProjectTreeView();
            UpdateAssemblyTreeView();
		}

		private void LoadAssembly(string path)
		{
            ModuleDefinition module = ModuleDefinition.ReadModule(path);
			if(module != null)
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

		public void UpdateProjectTreeView()
		{
			// Remove all previous nodes
			projectTree.Nodes.Clear();

			// Add project settings node
			TreeNode projectSettingsNode = projectTree.Nodes.Add("Project Settings");
			projectSettingsNode.ImageKey = "gear.png";
			projectSettingsNode.SelectedImageKey = "gear.png";

			// Add project assemblies node
			TreeNode assembliesNode = projectTree.Nodes.Add("Assemblies");
			assembliesNode.ImageKey = "databases.png";
			assembliesNode.SelectedImageKey = "databases.png";

			// Add project assemblies
			foreach(string assembly in debugAssemblies)
			{
				TreeNode assemblyNode = assembliesNode.Nodes.Add(assembly);
				assemblyNode.ImageKey = "database--plus.png";
				assemblyNode.SelectedImageKey = "database--plus.png";
			}
		}

        public void UpdateAssemblyTreeView()
        {
            // Remove all previous nodes
            assemblyTree.Nodes.Clear();

			// Add each assembly data to the tree
			foreach (var loadedAssembly in loadedAssemblies)
			{
				AddAssemblyToTree(loadedAssembly.Value);
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

    }
}
