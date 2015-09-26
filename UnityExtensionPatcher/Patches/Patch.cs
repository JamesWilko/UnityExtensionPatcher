using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExtensionPatcher.Patches
{
	public abstract class Patch
	{
		public enum PatchInsertionPosition
		{
			Before,
			After
		}

		public abstract string InsertionPoint { get; }
		public abstract PatchInsertionPosition InsertionPosition { get; }
		public abstract int InsertionPointOffset { get; }

		public abstract void PerformPatch( ref List<string> ilFileLines );

		public virtual int GetInsertionOffset()
		{
			switch ( InsertionPosition )
			{
				default:
				case PatchInsertionPosition.Before:
					return -InsertionPointOffset;
				case PatchInsertionPosition.After:
					return InsertionPointOffset;
			}
		}
	}
}
