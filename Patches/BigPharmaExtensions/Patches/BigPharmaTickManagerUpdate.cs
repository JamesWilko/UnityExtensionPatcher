using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions
{
	class BigPharmaTickManagerUpdate : LineAdditionPatch
	{
		public override string InsertionPoint { get { return "} // end of method TickManager::UpdateTime"; } }
		public override Patch.PatchInsertionPosition InsertionPosition { get { return PatchInsertionPosition.Before; } }
		public override int InsertionPointOffset { get { return 1; } }
		public override List<string> PatchLines
		{
			get
			{
				return new List<string>()
				{
					"// Print to unity log file",
					".maxstack 8",
					"IL_P_0000: nop",
					"IL_P_0001: ldstr \"Hello world, injected from IL!\"",
					"IL_P_0006: call void [UnityEngine]UnityEngine.Debug::Log(object)",
					"IL_P_000b: nop",
					"// End block"
				};
			}
		}
	}
}
