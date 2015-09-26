using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExtensionPatcher.Patches;

namespace BigPharmaExtensions
{
    public class BigPharmaPatch : PatchCollection
    {
		public override string GameName { get { return "Big Pharma"; } }
		public override List<PatchAuthor> PatchAuthor
		{
			get
			{
				return new List<PatchAuthor>()
				{
					new PatchAuthor("James Wilkinson", "http://jameswilko.com/")
				};
			}
		}
		public override List<Patch> Patches
		{
			get
			{
				return new List<Patch>()
				{
					new BigPharmaCallLoadExtensionManager(),
					new BigPharmaExtensionManagerField(),
					new BigPharmaLoadExtensionManager()
					//new BigPharmaTickManagerUpdate()
				};
			}
		}
    }
}
