using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensionPatcher.Patches
{
	public struct PatchAuthor
	{
		public string name;
		public string url;
		public PatchAuthor( string name, string url )
		{
			this.name = name;
			this.url = url;
		}
	}

	public abstract class PatchCollection
	{
		public abstract string GameName { get; }
		public abstract List<PatchAuthor> PatchAuthor { get; }
		public abstract List<Patch> Patches { get; }

		const string PATCH_LOG = "Performing patch {0}... {1}";

		public void Patch(ref List<string> ilFile)
		{
			foreach ( Patch patch in Patches )
			{
				bool patched = patch.PerformPatch( ref ilFile );
				Logging.Log( PATCH_LOG, patch.GetType().FullName, patched ? "Success" : "Failed" );
			}
		}

	}
}
