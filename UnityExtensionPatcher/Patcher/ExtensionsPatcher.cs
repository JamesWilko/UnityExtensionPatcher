using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using UnityExtensionPatcher.Patches;

namespace UnityExtensionPatcher.Patcher
{
	public enum DotNetVersion
	{
		TWO_POINT_OH,
		FOUR_POINT_OH
	}

	class ExtensionsPatcher
	{
		List<PatchCollection> availablePatches = new List<PatchCollection>();
		string inputFile;
		string outputFile;
		DotNetVersion compileVersion;
		bool createBackup;
		bool performCleanup;

		public List<PatchCollection> AvailablePatches { get { return availablePatches; } }
		public string InputFile { get { return this.inputFile; } }
		public string OutputFile { get { return this.outputFile; } }
		public string InputFileIL { get { return TEMP_INPUT_FILE + IL_FILE_EXT; } }
		public string InputFileRES { get { return TEMP_INPUT_FILE + RES_FILE_EXT; } }
		public DotNetVersion CompileDotNetVersion { get { return this.compileVersion; } }
		public bool CreateBackups { get { return createBackup; } }
		public bool PerformPostCompileCleanup { get { return performCleanup; } }

		public string AssemblerFile
		{
			get
			{
				switch(CompileDotNetVersion)
				{
					default:
					case DotNetVersion.TWO_POINT_OH:
						return ASSEMBLER_TWO_POINT_OH;
					case DotNetVersion.FOUR_POINT_OH:
						return ASSEMBLER_FOUR_POINT_OH;
				}
			}
		}

		public const string TEMP_INPUT_FILE = "temp-input.dll";
		public const string TEMP_OUTPUT_FILE = "temp-output.dll";

		public const string DEFAULT_ASSEMBLY = "Assembly-CSharp.dll";
		public const string DEFAULT_PATCHED_ASSEMBLY = "Assembly-CSharp-Patched.dll";

		public const string BACKUP_FOLDER = "Backup/";

		public const string IL_DISASSEMBLER = "ildasm.exe";
		public const string ASSEMBLER_TWO_POINT_OH = "ilasm_20.exe";
		public const string ASSEMBLER_FOUR_POINT_OH = "ilasm_40.exe";
		public const string FUSION_DLL = "fusion.dll";
		public const string IL_FILE_EXT = ".il";
		public const string RES_FILE_EXT = ".res";

		public const string DECOMPILE_IL_ARGUMENTS = "{0} /out={1}";
		public const string RECOMPILE_IL_ARGUMENTS = "{0} /out={1} /dll /quiet /nologo";

		public const string DECOMPILE_SUCCESS = "Decompile Successful!";
		public const string DECOMPILE_FAILED_EXCEPTION = "Decomplile failed!\nAn exception occurred during the decompile process:\n{0}";
		public const string DECOMPILE_FAILED_MISSING = "Decompile failed! '{0}' was not created by the disassembler!";

		public const string RECOMPILE_SUCCESSFUL = "Recompile successful!";
		public const string RECOMPILE_FAILED_EXCEPTION = "Recompile Failed!\nAn exception occurred during the recompile process:\n{0}";
		public const string RECOMPILE_FAILED_MISSING = "Recompile failed! '{0}' was not built by the assembler!";

		public ExtensionsPatcher()
		{
		}

		public bool SetInputFile( string fileName )
		{
			inputFile = fileName;
			return File.Exists( fileName );
		}

		public bool SetOutputFile( string fileName )
		{
			outputFile = fileName;
			return !File.Exists( fileName );
		}

		public void SetCompileTargetVersion( DotNetVersion version )
		{
			compileVersion = version;
		}

		public void SetBackupStatus( bool backup )
		{
			createBackup = backup;
		}

		public void SetCleanupStatus( bool cleanup )
		{
			performCleanup = cleanup;
		}

		public void AddPatchCollection( PatchCollection collection )
		{
			availablePatches.Add( collection );
		}

		public void Patch( PatchCollection patchCollection )
		{
			Logging.Log( "Beginning {0} patch on file '{1}'", patchCollection.GameName, InputFile );

			// Create the resources required to patch
			Logging.Log( "Creating resources..." );
			ExtensionsPatcherResources patcherResources = new ExtensionsPatcherResources();
			patcherResources.CreateAssembler( CompileDotNetVersion, AssemblerFile );
			patcherResources.CreateDisassembler( IL_DISASSEMBLER );
			patcherResources.CreateFusionDll( FUSION_DLL );

			// Backup our files if necessary
			if ( this.CreateBackups )
			{
				Logging.Log( "Backing up files..." );
				BackupFiles();
			}

			// Decompile the target DLL
			Logging.Log( "" );
			Logging.Log( "Beginning decompile of '{0}'", InputFile );
			bool decompileSuccess = DecompileTarget();
			if ( !decompileSuccess )
			{
				Logging.Log( "" );
				Logging.Log( "Patching failed!" );
				CleanupFiles( patcherResources, false );
				return;
			}

			// Read IL file in
			List<string> ilFile = File.ReadAllLines( InputFileIL ).ToList();

			// Perform the required patch on the IL
			Logging.Log( "Starting patch..." );
			patchCollection.Patch( ref ilFile );

			// Remove the old un-patched IL file
			if ( File.Exists( InputFileIL ) )
			{
				File.Delete( InputFileIL );
			}
			
			// Save the patched IL to our file
			FileStream fs = File.Create( InputFileIL );
			fs.Dispose();

			StringBuilder builder = new StringBuilder();
			foreach(string line in ilFile)
			{
				builder.AppendLine( line );
			}

			File.WriteAllText( InputFileIL, builder.ToString() );

			// Recompile IL file to into dll
			Logging.Log( "Beginning recompile of '{0}'", InputFile );
			bool recompileSuccess = RecompileTarget();
			if ( !recompileSuccess )
			{
				Logging.Log( "" );
				Logging.Log( "Patching failed!" );
				CleanupFiles( patcherResources, false );
				return;
			}

			// Remove any files created during the patch
			if ( this.PerformPostCompileCleanup )
			{
				Logging.Log( "" );
				Logging.Log( "Beginning cleanup..." );
				CleanupFiles( patcherResources, true );
			}

			Logging.Log( "" );
			Logging.Log( "Patch complete!" );
			Logging.Log( "Created file '{0}'", OutputFile );
		}

		void BackupFiles()
		{
			if ( !Directory.Exists( BACKUP_FOLDER ) )
			{
				Directory.CreateDirectory( BACKUP_FOLDER );
			}

			string inputFileName = Path.GetFileName( InputFile );
			string inputBackupPath = string.Format( "{0}/{1}", BACKUP_FOLDER, inputFileName );
			if ( File.Exists( inputBackupPath ) )
			{
				File.Delete( inputBackupPath );
			}
			File.Copy( inputFile, inputBackupPath );

			if ( File.Exists( OutputFile ) )
			{
				string outputFileName = Path.GetFileName( OutputFile );
				string outputBackupPath = string.Format( "{0}/{1}", BACKUP_FOLDER, outputFileName );
				if ( File.Exists( outputBackupPath ) )
				{
					File.Delete( outputBackupPath );
				}
				File.Copy( outputFile, outputBackupPath );
			}
		}

		void CleanupFiles( ExtensionsPatcherResources patcherResources, bool enableLogging = true )
		{
			if ( File.Exists( TEMP_INPUT_FILE ) )
			{
				if ( enableLogging )
				{
					Logging.Log( "Removing temporary file '{0}'", TEMP_INPUT_FILE );
				}
				File.Delete( TEMP_INPUT_FILE );
			}
			if ( File.Exists( TEMP_OUTPUT_FILE ) )
			{
				if ( enableLogging )
				{
					Logging.Log( "Removing temporary file '{0}'", TEMP_OUTPUT_FILE );
				}
				File.Delete( TEMP_INPUT_FILE );
			}
			if ( File.Exists( InputFileIL ) )
			{
				if ( enableLogging )
				{
					Logging.Log( "Removing temporary file '{0}'", InputFileIL );
				}
				File.Delete( InputFileIL );
			}
			if ( File.Exists( InputFileRES ) )
			{
				if ( enableLogging )
				{
					Logging.Log( "Removing temporary file '{0}'", InputFileRES );
				}
				File.Delete( InputFileRES );
			}
			patcherResources.CleanupResources( enableLogging );
		}

		bool DecompileTarget()
		{
			// Copy our target file for decompile
			File.Copy( InputFile, TEMP_INPUT_FILE );

			// Perform decompile using ildasm
			try
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo( IL_DISASSEMBLER )
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					Arguments = string.Format( DECOMPILE_IL_ARGUMENTS, TEMP_INPUT_FILE, InputFileIL )
				};
				process.OutputDataReceived += ( s, e ) => { Logging.Log( e.Data ); };
				process.ErrorDataReceived += ( s, e ) => { Logging.Log( e.Data ); };

				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
			}
			catch ( Exception exception )
			{
				Logging.Log( DECOMPILE_FAILED_EXCEPTION, exception );
				return false;
			}

			if ( File.Exists( InputFileIL ) )
			{
				Logging.Log( DECOMPILE_SUCCESS );
				return true;
			}
			else
			{
				Logging.Log( DECOMPILE_FAILED_MISSING, InputFileIL );
				return false;
			}			
		}

		bool RecompileTarget()
		{
			Logging.Log( "Recompiling target..." );

			try
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo( AssemblerFile )
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					Arguments = string.Format( RECOMPILE_IL_ARGUMENTS, InputFileIL, TEMP_OUTPUT_FILE )
				};
				process.OutputDataReceived += ( s, e ) => { Logging.Log( e.Data ); };
				process.ErrorDataReceived += ( s, e ) => { Logging.Log( e.Data ); };

				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
			}
			catch ( Exception exception )
			{
				Logging.Log( RECOMPILE_FAILED_EXCEPTION, exception );
				return false;
			}

			if ( File.Exists( TEMP_OUTPUT_FILE ) )
			{
				// Copy our temporary output file to our proper output
				if ( File.Exists( OutputFile ) )
				{
					File.Delete( OutputFile );
				}
				File.Copy( TEMP_OUTPUT_FILE, OutputFile );
				File.Delete( TEMP_OUTPUT_FILE );

				Logging.Log( RECOMPILE_SUCCESSFUL );
				return true;
			}
			else
			{
				Logging.Log( RECOMPILE_FAILED_MISSING, TEMP_OUTPUT_FILE );
				return false;
			}
		}

	}
}
