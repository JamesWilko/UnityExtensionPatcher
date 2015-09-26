using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using UnityExtensionPatcher.Patches;
using UnityExtensionPatcher.Patcher;

namespace UnityExtensionPatcher
{
	public partial class PatcherWindow : Form
	{
		ExtensionsPatcher extensionPatcher;

		const string PATCHES_FOLDER = "Patches/";
		const string PATCH_EXTENSION = ".dll";

		const string MISSING_INPUT_TITLE = "Missing Input File";
		const string MISSING_INPUT_DESC = "'{0}' could not be found.\nPlease specify an existing input file.";

		const string EXISTING_OUTPUT_TITLE = "Existing Output File";
		const string EXISTING_OUTPUT_DESC = "'{0}' already exists, do you want to replace it?";

		delegate void SetTextCallback( string text );

		public PatcherWindow()
		{
			InitializeComponent();
			Logging.SetOutput( this );
			extensionPatcher = new ExtensionsPatcher();
		}

		private void PatcherWindow_Load( object sender, EventArgs e )
		{
			Logging.Log( "Loading patches from folder: {0}", PATCHES_FOLDER );
			DirectoryInfo dirInfo = new DirectoryInfo( PATCHES_FOLDER );
			foreach(FileInfo fileInfo in dirInfo.GetFiles())
			{
				if ( fileInfo.Extension.ToLower() == PATCH_EXTENSION )
				{
					Logging.Log( "Attempting to load patch file: {0}", fileInfo.Name );

					Assembly asm = Assembly.LoadFile( fileInfo.FullName );
					foreach(var type in asm.GetTypes())
					{
						if ( type.IsSubclassOf(typeof(PatchCollection)) )
						{
							PatchCollection collection = Activator.CreateInstance( type ) as PatchCollection;
							if ( collection != null )
							{
								extensionPatcher.AddPatchCollection( collection );
								comboPatchGame.Items.Add( collection.GameName );
								comboPatchGame.SelectedIndex = 0;
							}
						}
						
					}
				}

			}
		}

		public void LogConsole( string text )
		{
			if ( textOutput.InvokeRequired )
			{
				SetTextCallback d = new SetTextCallback( LogConsole );
				this.Invoke( d, new object[] { text } );
			}
			else
			{
				text = text.Replace( "\n", Environment.NewLine );
				textOutput.AppendText( text + Environment.NewLine );
			}
		}

		private void btnPatch_Click( object sender, EventArgs e )
		{
			// Make sure we've selected a game and we're not using a game that doesn't exist
			if(comboPatchGame.SelectedIndex < 0)
			{
				return;
			}
			if ( comboPatchGame.SelectedIndex >= extensionPatcher.AvailablePatches.Count )
			{
				comboPatchGame.SelectedIndex = extensionPatcher.AvailablePatches.Count - 1;
			}

			string inputFilePath = txtInputFile.Text;
			if(string.IsNullOrEmpty(inputFilePath))
			{
				inputFilePath = ExtensionsPatcher.DEFAULT_ASSEMBLY;
			}

			string outputFilePath = txtOutputFile.Text;
			if(string.IsNullOrEmpty(outputFilePath))
			{
				outputFilePath = ExtensionsPatcher.DEFAULT_PATCHED_ASSEMBLY;
			}

			DotNetVersion dotNetVersion = DotNetVersion.TWO_POINT_OH;
			if ( radioNetTwo.Checked )
			{
				dotNetVersion = DotNetVersion.TWO_POINT_OH;
			}
			if (radioNetFour.Checked)
			{
				dotNetVersion = DotNetVersion.FOUR_POINT_OH;
			}

			// Setup patcher
			bool inputValid = extensionPatcher.SetInputFile( inputFilePath );
			bool outValid = extensionPatcher.SetOutputFile( outputFilePath );
			extensionPatcher.SetCompileTargetVersion( dotNetVersion );
			extensionPatcher.SetBackupStatus( checkBackup.Checked );
			extensionPatcher.SetCleanupStatus( checkCleanup.Checked );

			// Invalid input file
			if ( !inputValid )
			{
				DialogResult inputDialogResult = MessageBox.Show( string.Format( MISSING_INPUT_DESC, inputFilePath ), MISSING_INPUT_TITLE, MessageBoxButtons.OK );
				if ( inputDialogResult == DialogResult.OK )
				{
					return;
				}
			}

			// Existing output file
			if ( !outValid )
			{
				DialogResult outputDialogResult = MessageBox.Show( string.Format( EXISTING_OUTPUT_DESC, outputFilePath ), EXISTING_OUTPUT_TITLE, MessageBoxButtons.YesNo );
				if ( outputDialogResult == DialogResult.No )
				{
					return;
				}
			}

			// Patch our files
			PatchCollection collection = extensionPatcher.AvailablePatches[comboPatchGame.SelectedIndex];
			if ( collection != null )
			{
				extensionPatcher.Patch( collection );
			}
		}

		private void btnBrowse_Click( object sender, EventArgs e )
		{
			dialogInputFile.Filter = "DLL Files (.dll)|*.dll";
			dialogInputFile.FilterIndex = 0;
			DialogResult result = dialogInputFile.ShowDialog();
			if(result == DialogResult.OK)
			{
				txtInputFile.Text = dialogInputFile.FileName;
			}
		}

		private void btnOutputBrowse_Click( object sender, EventArgs e )
		{
			dialogOutputFile.Filter = "DLL Files (.dll)|*.dll";
			dialogOutputFile.FilterIndex = 0;
			DialogResult result = dialogOutputFile.ShowDialog();
			if ( result == DialogResult.OK )
			{
				txtOutputFile.Text = dialogOutputFile.FileName;
			}
		}
	}
}
