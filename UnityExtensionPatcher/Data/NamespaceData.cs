using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace UnityExtensionPatcher
{
    class NamespaceData
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
