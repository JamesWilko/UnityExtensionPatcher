using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using JsonFx.Json;

namespace UnityExtensionPatcher.Data
{
	public class ProjectManifest
	{
		public string ProjectPath { get; set; }
		public string ProjectName { get; set; }
		public List<ProjectAssembly> Assemblies { get; set; }

		public string ProjectFolder { get { return Path.Combine(ProjectPath, ProjectName); } }
		public string ProjectFile { get { return Path.Combine(ProjectPath, ProjectName, $"{ProjectName}{PROJECT_MANIFEST_EXTENSION}"); } }
        public string ProjectTempFile { get { return Path.Combine(ProjectPath, ProjectName, $"{ProjectName}{PROJECT_MANIFEST_TEMP_EXTENSION}"); } }

		public const string PROJECT_MANIFEST_EXTENSION = ".upp";
		public const string PROJECT_MANIFEST_TEMP_EXTENSION = ".upp-temp";

		public ProjectManifest()
		{
			this.Assemblies = new List<ProjectAssembly>();
		}

		public ProjectManifest(string path, string name) : this()
		{
			this.ProjectPath = path;
			this.ProjectName = name;

			// Create project directory
			string folderPath = Path.Combine(ProjectPath, ProjectName);
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
		}

		public void AddDebug()
		{
			AddAssembly(@"Assembly-CSharp.dll");
			AddAssembly(@"System.dll");
			AddAssembly(@"UnityEngine.dll");
			AddAssembly(@"UnityEngine.UI.dll");
		}
		
		public void AddAssembly(string assemblyPath)
		{
			ProjectAssembly assembly = new ProjectAssembly();
			assembly.Path = assemblyPath;
			assembly.Load = true;
            this.Assemblies.Add(assembly);
			this.Save();
		}

		#region File Operations

		public void Save()
		{
			bool overwriting = File.Exists(ProjectFile);
            string saveFile = overwriting ? ProjectTempFile : ProjectFile;
			StreamWriter writer = new StreamWriter(saveFile);
			System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(ProjectManifest));
			xml.Serialize(writer, this);
			writer.Dispose();

			if (overwriting)
			{
				File.Delete(ProjectFile);
				File.Move(ProjectTempFile, ProjectFile);
            }
		}

		public void Load(Action<string> loadAssemblyFunc)
		{
			foreach (ProjectAssembly assembly in this.Assemblies)
			{
				if (assembly.Load)
				{
					loadAssemblyFunc(assembly.Path);
				}
			}
		}

		public static ProjectManifest Load(string filePath)
		{
			if(File.Exists(filePath))
			{
				StreamReader reader = new StreamReader(filePath);
				System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(ProjectManifest));
				ProjectManifest manifest = xml.Deserialize(reader) as ProjectManifest;
                return manifest;
            }
			else
			{
				return null;
			}			
        }

		#endregion
	}
}
