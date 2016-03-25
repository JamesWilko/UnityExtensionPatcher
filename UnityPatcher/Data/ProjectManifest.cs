using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Newtonsoft.Json;
using UnityPatcher.Utils;

namespace UnityPatcher.Data
{
	public class ProjectManifest
	{
		public string ProjectPath { get; set; }
		public string ProjectName { get; set; }
		public List<ProjectAssembly> Assemblies { get; set; }

		[JsonIgnore]
		protected ReaderParameters m_ReaderParams;
		[JsonIgnore]
		public ReaderParameters ReaderParams
		{
			get
			{
				if (m_ReaderParams == null)
				{
					var resolver = new DefaultAssemblyResolver();
					resolver.AddSearchDirectory(ProjectFolder);
					m_ReaderParams = new ReaderParameters
					{
						AssemblyResolver = resolver,
					};
				}
				return m_ReaderParams;
            }
		}

		[JsonIgnore]
		public string ProjectFolder { get { return Path.Combine(ProjectPath, ProjectName); } }
		[JsonIgnore]
		public string ProjectFile { get { return Path.Combine(ProjectPath, ProjectName, $"{ProjectName}{PROJECT_MANIFEST_EXTENSION}"); } }
		[JsonIgnore]
		public string ProjectTempFile { get { return Path.Combine(ProjectPath, ProjectName, $"{ProjectName}{PROJECT_MANIFEST_TEMP_EXTENSION}"); } }

		public static event Action<ProjectManifest> OnNewProjectCreated;
		public static event Action OnProjectUpdated;

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

			if(OnNewProjectCreated != null)
			{
				OnNewProjectCreated(this);
            }
        }

		public static void PerformRequestUpdate()
		{
			OnProjectUpdated.PerformInvoke();
        }

		public void RequestUpdate()
		{
			PerformRequestUpdate();
        }

		#region Assemblies

		public bool AssemblyExists(string assemblyPath)
		{
			foreach(var assembly in this.Assemblies)
			{
				if (assembly.Path == assemblyPath)
					return true;
			}
			return false;
		}

		public void AddAssembly(string assemblyPath, bool include = true)
		{
			ProjectAssembly assembly = new ProjectAssembly();
			assembly.Path = assemblyPath;
			assembly.Load = include;
			this.Assemblies.Add(assembly);
			this.Save();
		}

		public void RemoveAssembly(ProjectAssembly assembly)
		{
			Assemblies.Remove(assembly);
			Save();
		}

		public bool IsAssemblyIncluded(ProjectAssembly assembly)
		{
			return assembly.Load;
		}

		public void SetAssemblyIncluded(ProjectAssembly assembly, bool include)
		{
			for (int i = 0; i < this.Assemblies.Count; ++i)
			{
				if (Assemblies[i].Equals(assembly))
				{
					ProjectAssembly asm = Assemblies[i];
					asm.Load = include;
					Assemblies[i] = asm;
					break;
				}
			}
			Save();
		}

		#endregion

		#region File Operations

		public void Save()
		{
			bool overwriting = File.Exists(ProjectFile);
			string saveFile = overwriting ? ProjectTempFile : ProjectFile;
			StreamWriter writer = new StreamWriter(saveFile);
			var jsonData = JsonConvert.SerializeObject(this);
			writer.Write(jsonData);
            writer.Dispose();

			if (overwriting)
			{
				File.Delete(ProjectFile);
				File.Move(ProjectTempFile, ProjectFile);
			}
		}

		public static ProjectManifest Load(string filePath)
		{
			if (File.Exists(filePath))
			{
				StreamReader reader = new StreamReader(filePath);
				var jsonData = reader.ReadToEnd();
				ProjectManifest manifest = JsonConvert.DeserializeObject(jsonData, typeof(ProjectManifest)) as ProjectManifest;
				reader.Dispose();
				return manifest;
			}
			else
			{
				Console.WriteLine($"No file exists at: {filePath}");
				return null;
			}
		}

		#endregion

	}
}
