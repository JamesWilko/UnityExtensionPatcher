using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace UnityPatcher.Data
{
	public class ProjectAssembly
	{
		public string Path { get; set; }
		public bool Load { get; set; }
		public AssemblyData assemblyData { get; protected set; }

		public string FullPath
		{
			get { return System.IO.Path.Combine(App.CurrentProject.ProjectFolder, Path); }
		}

		public void LoadAssembly()
		{
			ModuleDefinition module = ModuleDefinition.ReadModule(FullPath);
			if (module != null)
			{
				// Add the assembly module to our dictionary
				assemblyData = new AssemblyData(FullPath, module);

				// Create global namespace
				assemblyData.AddNamespace("", new NamespaceData("-"));
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

		public void SetLoad(bool load)
		{
			Load = load;
			App.CurrentProject.RequestUpdate();
		}

		public override string ToString()
		{
			return $"ProjectAssembly [Path: {Path}][Load: {Load}]";
		}
	}
}
