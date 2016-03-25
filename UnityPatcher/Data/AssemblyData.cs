using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Newtonsoft.Json;

namespace UnityPatcher.Data
{
	public class AssemblyData
	{
		public string Path { get; private set; }
		[JsonIgnore]
		public ModuleDefinition Definition { get; private set; }
		[JsonIgnore]
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

	public class NamespaceData
	{
		public string Name { get; private set; }
		public List<TypeDefinition> Types { get; private set; }

		public NamespaceData(string name)
		{
			this.Name = name;
			this.Types = new List<TypeDefinition>();
		}

		public void Add(TypeDefinition newType)
		{
			Types.Add(newType);
		}
	}
}
