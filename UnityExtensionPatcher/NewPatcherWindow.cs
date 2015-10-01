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

namespace UnityExtensionPatcher
{
    public partial class NewPatcherWindow : Form
    {
        public NewPatcherWindow()
        {
            InitializeComponent();
        }

        string debugAssembly = @"Assembly-CSharp.dll";
        Dictionary<string, NamespaceData> loadedNamespaces = new Dictionary<string, NamespaceData>();

        private void NewPatcherWindow_Load(object sender, EventArgs e)
        {
            ModuleDefinition module = ModuleDefinition.ReadModule(debugAssembly);
            NamespaceData namespaceData;

            // Create global namespace
            namespaceData = new NamespaceData("global");
            loadedNamespaces.Add("", namespaceData);

            // Find namespaces in the loaded assembly
            foreach (TypeDefinition type in module.Types)
            {
                bool existingNamespace = loadedNamespaces.TryGetValue(type.Namespace, out namespaceData);
                if (!existingNamespace)
                {
                    namespaceData = new NamespaceData(type.Namespace);
                    loadedNamespaces.Add(type.Namespace, namespaceData);
                    
                }
                namespaceData.Add(type);
            }

            // Update tree view hierarchy 
            UpdateTreeView();
        }

        public void UpdateTreeView()
        {
            // Remove all previous nodes
            assemblyView.Nodes.Clear();

            Dictionary<string, TreeNode> namespaceNodes = new Dictionary<string, TreeNode>();

            // Add node for loaded assembly
            TreeNode assemblyNode = assemblyView.Nodes.Add(debugAssembly);

            // Add nodes from assemblies
            foreach (KeyValuePair<string, NamespaceData> namespacePair in loadedNamespaces)
            {
                NamespaceData data = namespacePair.Value;
                namespaceNodes.Add(data.Name, assemblyNode.Nodes.Add(data.Name));
                foreach (TypeDefinition type in data.Types)
                {
                    namespaceNodes[data.Name].Nodes.Add(type.Name);
                }
            }
        }
    }
}
