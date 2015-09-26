using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensionPatcher.Patches
{
	public abstract class LineAdditionPatch : Patch
	{
		public abstract List<string> PatchLines { get; }

		public override int GetInsertionOffset()
		{
			switch ( InsertionPosition )
			{
				default:
				case PatchInsertionPosition.Before:
					return -InsertionPointOffset;
				case PatchInsertionPosition.After:
					return InsertionPointOffset + 1;
			}
		}

		public override void PerformPatch( ref List<string> ilFileLines )
		{
			for ( int i = 0; i < ilFileLines.Count; i++ )
			{
				if ( ilFileLines[i].Contains( this.InsertionPoint ) )
				{
					for ( int k = PatchLines.Count - 1; k >= 0; k-- )
					{
						ilFileLines.Insert( i + GetInsertionOffset(), PatchLines[k] );
					}
					break;
				}
			}
		}
	}
}
