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

        private void NewPatcherWindow_Load(object sender, EventArgs e)
        {
            string debugAssembly = @"Assembly-CSharp.dll";

            TreeNode assemblyNode = assemblyView.Nodes.Add(debugAssembly);
            ModuleDefinition module = ModuleDefinition.ReadModule(debugAssembly);

            Dictionary<string, NamespaceData> namespaces = new Dictionary<string, NamespaceData>();
            NamespaceData namespaceData;

            // Create global namespace
            namespaceData = new NamespaceData("global");
            namespaces.Add("", namespaceData);
            assemblyNode.Nodes.Add("global");

            // Find namespaces in the loaded assembly
            foreach (TypeDefinition type in module.Types)
            {
                bool existingNamespace = namespaces.TryGetValue(type.Namespace, out namespaceData);
                if (!existingNamespace)
                {
                    namespaceData = new NamespaceData(type.Namespace);
                    namespaces.Add(type.Namespace, namespaceData);
                    assemblyNode.Nodes.Add(type.Namespace);
                }
                namespaceData.Add(type);
            }
        }
    }
}
