using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityPatcher.Utils
{
	public static partial class Utils
	{

		public static void PerformInvoke(this Action action)
		{
			if(action != null)
			{
				action();
			}
		}

	}
}
