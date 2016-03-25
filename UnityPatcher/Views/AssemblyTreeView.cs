using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Mono.Cecil;
using UnityPatcher.Data;

namespace UnityPatcher.Views
{
	public class AssemblyTreeView
	{
		protected TreeImageView parentView;
		protected TreeView parentTree;
		protected TabControl tabControl;

		public AssemblyTreeView(TreeImageView parentView, TabControl tabControl)
		{
			this.parentView = parentView;
			this.parentTree = parentView.treeView;
			this.tabControl = tabControl;

			ProjectManifest.OnProjectUpdated += Update;

			Update();
		}

		~AssemblyTreeView()
		{
			ProjectManifest.OnProjectUpdated -= Update;
		}

		public void Update()
		{
			parentTree.Items.Clear();
			if (!App.HasProject) { return; }

			ProjectManifest project = App.CurrentProject;

			foreach(var assembly in project.Assemblies)
			{
				if (assembly.Load)
					AddAssembly(assembly);
            }

		}

		protected void AddAssembly(ProjectAssembly assembly)
		{
			TreeViewItem assemblyNode = new TreeViewItem()
			{
				Header = assembly.Path,
				DataContext = "database_add.png"
			};

			try
			{
				assembly.LoadAssembly();
				parentTree.Items.Add(assemblyNode);

				foreach (var kvp in assembly.assemblyData.Namespaces)
				{
					TreeViewItem namespaceNode = new TreeViewItem()
					{
						Header = kvp.Value.Name,
						DataContext = "namespace.png"
					};
					assemblyNode.Items.Add(namespaceNode);

					var typeList = new List<TypeDefinition>();
					foreach (var namespaceType in kvp.Value.Types)
					{
						typeList.Add(namespaceType);
                    }
					typeList.Sort(new Utils.TypeNameUtils.AlphabeticalTypeComparer());

					foreach (var namespaceType in typeList)
					{
						TreeViewItem typeNode = new TreeViewItem()
						{
							Header = Utils.TypeNameUtils.GetTypeNameWithGenerics(namespaceType),
							DataContext = "class.png"
						};
                        typeNode.MouseDoubleClick += (object sender, System.Windows.Input.MouseButtonEventArgs e) =>
						{
							AddTypeTab(namespaceType);
                        };
                        namespaceNode.Items.Add(typeNode);
					}
                }

            }
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message}{Environment.NewLine}{exception.StackTrace}");
				assemblyNode = new TreeViewItem()
				{
					Header = $"Could not load assembly: {assembly.Path}",
					DataContext = "database_error.png"
				};
				parentTree.Items.Clear();
                parentTree.Items.Add(assemblyNode);
			}
		}

		protected void AddTypeTab(TypeDefinition typeDefinition)
		{
			// Setup detail view
			var detailView = new ClassDetailsView();
			detailView.textBoxTypename.Text = Utils.TypeNameUtils.GetTypeNameWithGenerics(typeDefinition);
			detailView.textBoxDeclaration.Text = Utils.TypeNameUtils.GetTypeDeclarationString(typeDefinition);

			// Setup members tree
			TreeView membersTree = detailView.treeMembers.treeView;

			var fieldsNode = new TreeViewItem()
			{
				Header = "Fields",
				DataContext = "folder.png",
				IsExpanded = true
			};
			membersTree.Items.Add(fieldsNode);

			foreach (var field in typeDefinition.Fields)
			{
				var fieldNode = new TreeViewItem()
				{
					Header = Utils.TypeNameUtils.GetFieldDefintionFullName(field),
					DataContext = "field.png",
				};
				fieldsNode.Items.Add(fieldNode);
			}
			foreach (var property in typeDefinition.Properties)
			{
				var propertyNode = new TreeViewItem()
				{
					Header = property.Name,
					DataContext = "property.png",
				};
				fieldsNode.Items.Add(propertyNode);
			}

			// Add Methods
			var methodsNode = new TreeViewItem()
			{
				Header = "Methods",
				DataContext = "folder.png",
				IsExpanded = true
			};
			membersTree.Items.Add(methodsNode);

			foreach (var method in typeDefinition.Methods)
			{
				if (method.IsSetter || method.IsGetter)
					continue;

				var methodNode = new TreeViewItem()
				{
					Header = Utils.TypeNameUtils.GetMethodDefintionFullName(method, typeDefinition),
					DataContext = "method.png",
				};
				methodNode.MouseDoubleClick += (object sender, System.Windows.Input.MouseButtonEventArgs e) =>
				{
					if(method.HasBody)
						detailView.textEditorIL.Text = Utils.Decompiler.ToIL(method.Body);
                };
                methodsNode.Items.Add(methodNode);
			}

			// Setup and add tab
			var frame = new Frame();
			frame.Content = detailView;

			TabItem newTab = new TabItem();
			newTab.Header = typeDefinition.Name;
			newTab.Content = frame;
			tabControl.SelectedIndex = tabControl.Items.Add(newTab);
		}

	}
}
