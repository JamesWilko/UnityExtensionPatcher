using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensionPatcher.Patches
{
	public abstract class LineRemovalPatch : Patch
	{
		public abstract int NumberOfLinesToRemove { get; }

		const string COMMENT_CHARACTERS = "//";

		public override bool PerformPatch( ref List<string> ilFileLines )
		{
			for ( int i = 0; i < ilFileLines.Count; i++ )
			{
				if ( ilFileLines[i].Contains( this.InsertionPoint ) )
				{
					int start = i + GetInsertionOffset();
					int end = start + NumberOfLinesToRemove;
					for ( int k = start; k < end; k++ )
					{
						ilFileLines[k] = string.Format( "{0}{1}", COMMENT_CHARACTERS, ilFileLines[k] );
					}
					return true;
				}
			}
			return false;
		}

	}
}
