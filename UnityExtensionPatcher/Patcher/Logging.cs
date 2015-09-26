using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityExtensionPatcher
{
	public static class Logging
	{
		static PatcherWindow patcherWindow;

		public static void SetOutput( PatcherWindow form )
		{
			patcherWindow = form;
		}

		public static void Log( object obj, params object[] args )
		{
			if ( obj != null )
			{
				string output = string.Format( obj.ToString(), args );
				patcherWindow.LogConsole( output );
				Console.WriteLine( output );
			}
		}
	}
}
