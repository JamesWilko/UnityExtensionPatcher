using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace UnityExtensionPatcher.Data
{
	class AssemblyData
	{
		public string Path { get; private set; }
		public ModuleDefinition Definition { get; private set; }
		public Dictionary<string, NamespaceData> Namespaces { get; private set; }

		public const string ASSEMBLY_EXTENSION = ".dll";

		public AssemblyData(string path, ModuleDefinition definition)
		{
			this.Path = path;
			this.Definition = definition;
            this.Namespaces = new Dictionary<string, NamespaceData>();
		}

		public void AddNamespace(string name, NamespaceData nameSpace)
		{
			this.Namespaces.Add(name, nameSpace);
		}
	}
}
