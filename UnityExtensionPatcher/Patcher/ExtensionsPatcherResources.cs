using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace UnityExtensionPatcher.Patcher
{
	class ExtensionsPatcherResources
	{
		public const string RESOURCE_DISASSEMBLER = "UnityExtensionPatcher.Resources.ildasm.exe";
		public const string RESOURCE_ASSEMBLER_TWO_POINT_OH = "UnityExtensionPatcher.Resources.ilasm_20.exe";
		public const string RESOURCE_ASSEMBLER_FOUR_POINT_OH = "UnityExtensionPatcher.Resources.ilasm_40.exe";
		public const string RESOURCE_FUSION_DLL = "UnityExtensionPatcher.Resources.fusion.dll";

		List<string> createdResources = new List<string>();

		public void CreateDisassembler(string fileName)
		{
			CreateResource( RESOURCE_DISASSEMBLER, fileName );
			createdResources.Add( fileName );
		}

		public void CreateAssembler(DotNetVersion version, string fileName)
		{
			switch(version)
			{
				default:
				case DotNetVersion.TWO_POINT_OH:
					CreateResource( RESOURCE_ASSEMBLER_TWO_POINT_OH, fileName );
					break;
				case DotNetVersion.FOUR_POINT_OH:
					CreateResource( RESOURCE_ASSEMBLER_FOUR_POINT_OH, fileName );
					break;
			}
			createdResources.Add( fileName );
		}

		public void CreateFusionDll(string fileName)
		{
			CreateResource( RESOURCE_FUSION_DLL, fileName );
			createdResources.Add( fileName );
		}

		public void CleanupResources( bool enableLogging = true )
		{
			if ( enableLogging )
			{
				Logging.Log( "Cleaning up resources..." );
			}
			foreach ( string resourceFile in createdResources )
			{
				if ( File.Exists( resourceFile ) )
				{
					if ( enableLogging )
					{
						Logging.Log( "Removing resource '{0}'", resourceFile );
					}
					File.Delete( resourceFile );
				}
			}
		}

		void CreateResource(string resourceName, string fileName)
		{
			Logging.Log( "Creating resource '{0}' at '{1}'", resourceName, fileName );

			Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream( resourceName );
			if ( resourceStream != null )
			{
				FileStream fileStream = new FileStream( fileName, FileMode.Create, FileAccess.Write );
				resourceStream.CopyTo( fileStream );
				fileStream.Dispose();
			}
			resourceStream.Dispose();
		}

	}
}
