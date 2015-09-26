using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions
{
	class BigPharmaExtensionManagerField : LineAdditionPatch
	{
		public override string InsertionPoint { get { return ".field private class AIManager _aiManager"; } }
		public override Patch.PatchInsertionPosition InsertionPosition { get { return PatchInsertionPosition.Before; } }
		public override int InsertionPointOffset { get { return 1; } }
		public override List<string> PatchLines
		{
			get
			{
				return new List<string>()
				{
					".field private object _extensionManager"
				};
			}
		}
	}
}
