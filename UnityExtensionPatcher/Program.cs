using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityExtensionPatcher.Data;

namespace UnityExtensionPatcher
{
	static class Program
	{
		public static ProjectManifest CurrentProject;
		public static NewPatcherWindow Window;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Window = new NewPatcherWindow();
			Application.Run(Window);
		}
	}
}
