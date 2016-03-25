using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UnityPatcher.Data;
using UnityPatcher.Utils;

namespace UnityPatcher
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		static ProjectManifest m_CurrentProject;
		public static ProjectManifest CurrentProject
		{
			get
			{
				return m_CurrentProject;
            }
			set
			{
				m_CurrentProject = value;
				OnProjectUpdated.PerformInvoke();
            }
		}
		public static bool HasProject { get { return CurrentProject != null; } }

		public static event Action OnProjectUpdated;
	}
}
