using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace UnityExtensionPatcher.Data
{
	public enum TreeNodeType
	{
		None,
		Assembly,
		Namespace,
		Type,
		ProjectSettings,
		ProjectAssembly,
	}

	public struct ProjectTreeNodeData
	{
		public TreeNodeType nodeType;
		public TypeDefinition typeDefinition;

		public ProjectTreeNodeData(TreeNodeType type)
		{
			this.nodeType = type;
			this.typeDefinition = null;
        }
		public ProjectTreeNodeData(TreeNodeType type, TypeDefinition typeDef)
		{
			this.nodeType = type;
			this.typeDefinition = typeDef;
		}
	}
}
