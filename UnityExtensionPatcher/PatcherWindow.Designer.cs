namespace UnityExtensionPatcher
{
	partial class PatcherWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtInputFile = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnPatch = new System.Windows.Forms.Button();
			this.textOutput = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtOutputFile = new System.Windows.Forms.TextBox();
			this.btnOutputBrowse = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.progressPatch = new System.Windows.Forms.ProgressBar();
			this.comboPatchGame = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.checkBackup = new System.Windows.Forms.CheckBox();
			this.checkCleanup = new System.Windows.Forms.CheckBox();
			this.radioNetFour = new System.Windows.Forms.RadioButton();
			this.radioNetTwo = new System.Windows.Forms.RadioButton();
			this.dialogOutputFile = new System.Windows.Forms.SaveFileDialog();
			this.dialogInputFile = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtInputFile
			// 
			this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputFile.Location = new System.Drawing.Point(6, 20);
			this.txtInputFile.Name = "txtInputFile";
			this.txtInputFile.Size = new System.Drawing.Size(359, 20);
			this.txtInputFile.TabIndex = 0;
			this.txtInputFile.Text = "Assembly-CSharp.dll";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(371, 18);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(83, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// btnPatch
			// 
			this.btnPatch.Location = new System.Drawing.Point(6, 46);
			this.btnPatch.Name = "btnPatch";
			this.btnPatch.Size = new System.Drawing.Size(75, 23);
			this.btnPatch.TabIndex = 2;
			this.btnPatch.Text = "Patch";
			this.btnPatch.UseVisualStyleBackColor = true;
			this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
			// 
			// textOutput
			// 
			this.textOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textOutput.Location = new System.Drawing.Point(6, 19);
			this.textOutput.Multiline = true;
			this.textOutput.Name = "textOutput";
			this.textOutput.ReadOnly = true;
			this.textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textOutput.Size = new System.Drawing.Size(448, 209);
			this.textOutput.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textOutput);
			this.groupBox1.Location = new System.Drawing.Point(12, 315);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(460, 234);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.txtInputFile);
			this.groupBox2.Controls.Add(this.btnBrowse);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(460, 53);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Input";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.txtOutputFile);
			this.groupBox3.Controls.Add(this.btnOutputBrowse);
			this.groupBox3.Location = new System.Drawing.Point(12, 71);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(460, 53);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Output";
			// 
			// txtOutputFile
			// 
			this.txtOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutputFile.Location = new System.Drawing.Point(6, 20);
			this.txtOutputFile.Name = "txtOutputFile";
			this.txtOutputFile.Size = new System.Drawing.Size(359, 20);
			this.txtOutputFile.TabIndex = 0;
			this.txtOutputFile.Text = "Assembly-CSharp-Patched.dll";
			// 
			// btnOutputBrowse
			// 
			this.btnOutputBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputBrowse.Location = new System.Drawing.Point(371, 18);
			this.btnOutputBrowse.Name = "btnOutputBrowse";
			this.btnOutputBrowse.Size = new System.Drawing.Size(83, 23);
			this.btnOutputBrowse.TabIndex = 1;
			this.btnOutputBrowse.Text = "Browse";
			this.btnOutputBrowse.UseVisualStyleBackColor = true;
			this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.progressPatch);
			this.groupBox4.Controls.Add(this.comboPatchGame);
			this.groupBox4.Controls.Add(this.btnPatch);
			this.groupBox4.Location = new System.Drawing.Point(12, 130);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(460, 78);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Game";
			// 
			// progressPatch
			// 
			this.progressPatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressPatch.Location = new System.Drawing.Point(87, 46);
			this.progressPatch.Name = "progressPatch";
			this.progressPatch.Size = new System.Drawing.Size(367, 23);
			this.progressPatch.TabIndex = 9;
			// 
			// comboPatchGame
			// 
			this.comboPatchGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboPatchGame.FormattingEnabled = true;
			this.comboPatchGame.Location = new System.Drawing.Point(6, 19);
			this.comboPatchGame.Name = "comboPatchGame";
			this.comboPatchGame.Size = new System.Drawing.Size(448, 21);
			this.comboPatchGame.TabIndex = 8;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.checkBackup);
			this.groupBox5.Controls.Add(this.checkCleanup);
			this.groupBox5.Controls.Add(this.radioNetFour);
			this.groupBox5.Controls.Add(this.radioNetTwo);
			this.groupBox5.Location = new System.Drawing.Point(12, 215);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(460, 94);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Options";
			// 
			// checkBackup
			// 
			this.checkBackup.AutoSize = true;
			this.checkBackup.Checked = true;
			this.checkBackup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBackup.Location = new System.Drawing.Point(6, 66);
			this.checkBackup.Name = "checkBackup";
			this.checkBackup.Size = new System.Drawing.Size(87, 17);
			this.checkBackup.TabIndex = 4;
			this.checkBackup.Text = "Backup Files";
			this.checkBackup.UseVisualStyleBackColor = true;
			// 
			// checkCleanup
			// 
			this.checkCleanup.AutoSize = true;
			this.checkCleanup.Checked = true;
			this.checkCleanup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkCleanup.Location = new System.Drawing.Point(6, 43);
			this.checkCleanup.Name = "checkCleanup";
			this.checkCleanup.Size = new System.Drawing.Size(94, 17);
			this.checkCleanup.TabIndex = 3;
			this.checkCleanup.Text = "Post Clean Up";
			this.checkCleanup.UseVisualStyleBackColor = true;
			// 
			// radioNetFour
			// 
			this.radioNetFour.AutoSize = true;
			this.radioNetFour.Checked = true;
			this.radioNetFour.Location = new System.Drawing.Point(80, 19);
			this.radioNetFour.Name = "radioNetFour";
			this.radioNetFour.Size = new System.Drawing.Size(68, 17);
			this.radioNetFour.TabIndex = 2;
			this.radioNetFour.TabStop = true;
			this.radioNetFour.Text = ".NET 4.0";
			this.radioNetFour.UseVisualStyleBackColor = true;
			// 
			// radioNetTwo
			// 
			this.radioNetTwo.AutoSize = true;
			this.radioNetTwo.Location = new System.Drawing.Point(6, 19);
			this.radioNetTwo.Name = "radioNetTwo";
			this.radioNetTwo.Size = new System.Drawing.Size(68, 17);
			this.radioNetTwo.TabIndex = 1;
			this.radioNetTwo.Text = ".NET 2.0";
			this.radioNetTwo.UseVisualStyleBackColor = true;
			// 
			// dialogOutputFile
			// 
			this.dialogOutputFile.FileName = "Assembly-CSharp-Patched.dll";
			// 
			// dialogInputFile
			// 
			this.dialogInputFile.FileName = "Assembly-CSharp.dll";
			// 
			// PatcherWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 561);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(300, 450);
			this.Name = "PatcherWindow";
			this.Text = "Unity Extension Patcher";
			this.Load += new System.EventHandler(this.PatcherWindow_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtInputFile;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnPatch;
		private System.Windows.Forms.TextBox textOutput;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtOutputFile;
		private System.Windows.Forms.Button btnOutputBrowse;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ProgressBar progressPatch;
		private System.Windows.Forms.ComboBox comboPatchGame;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox checkBackup;
		private System.Windows.Forms.CheckBox checkCleanup;
		private System.Windows.Forms.RadioButton radioNetFour;
		private System.Windows.Forms.RadioButton radioNetTwo;
		private System.Windows.Forms.SaveFileDialog dialogOutputFile;
		private System.Windows.Forms.OpenFileDialog dialogInputFile;

	}
}

