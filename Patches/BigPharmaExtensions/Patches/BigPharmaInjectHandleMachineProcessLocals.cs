using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions.Patches
{
	class BigPharmaInjectHandleMachineProcessLocals : LineAdditionPatch
	{
		public override string InsertionPoint { get { return "class [mscorlib]System.Exception V_31"; } }
		public override Patch.PatchInsertionPosition InsertionPosition { get { return PatchInsertionPosition.After; } }
		public override int InsertionPointOffset { get { return -1; } }
		public override bool RemoveOriginalLine { get { return true; } }

		public override List<string> PatchLines
		{
			get
			{
				return new List<string>()
				{
"             class [mscorlib]System.Exception V_31,",
"             bool V_32,",
"             class [mscorlib]System.Type V_33,",
"             class [mscorlib]System.Reflection.MethodInfo V_34,",
"             bool V_35,",
"             class [mscorlib]System.Type[] V_36,",
"             int32 V37,",
"             object[] V_38)",
				};
			}
		}
	}
}
