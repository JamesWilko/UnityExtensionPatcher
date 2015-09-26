using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions
{
	public class BigPharmaCallLoadExtensionManager : LineAdditionPatch
	{
		public override string InsertionPoint { get { return "// end of method Backbone::Awake"; } }
		public override Patch.PatchInsertionPosition InsertionPosition { get { return PatchInsertionPosition.Before; } }
		public override int InsertionPointOffset { get { return 1; } }
		public override List<string> PatchLines
		{
			get
			{
				return new List<string>()
				{
					"IL_P_0000: nop",
					"IL_P_0001: ldarg.0",
					"IL_P_0002: call instance void Backbone::LoadAssembly()",
					"IL_P_0007: nop"
				};
			}
		}
	}
}
