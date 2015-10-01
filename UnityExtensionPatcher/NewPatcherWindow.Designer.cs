namespace UnityExtensionPatcher
{
    partial class NewPatcherWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPatcherWindow));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.assemblyTree = new System.Windows.Forms.TreeView();
			this.assemblyTreeImageList = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.projectTree = new System.Windows.Forms.TreeView();
			this.projectTreeImageList = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1081, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 568);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1081, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 8, 8, 8);
			this.splitContainer1.Size = new System.Drawing.Size(1081, 544);
			this.splitContainer1.SplitterDistance = 360;
			this.splitContainer1.TabIndex = 3;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(8, 8);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.projectTree);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.assemblyTree);
			this.splitContainer2.Size = new System.Drawing.Size(352, 528);
			this.splitContainer2.SplitterDistance = 202;
			this.splitContainer2.TabIndex = 1;
			// 
			// assemblyTree
			// 
			this.assemblyTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.assemblyTree.ImageIndex = 0;
			this.assemblyTree.ImageList = this.assemblyTreeImageList;
			this.assemblyTree.Location = new System.Drawing.Point(0, 0);
			this.assemblyTree.Name = "assemblyTree";
			this.assemblyTree.SelectedImageIndex = 0;
			this.assemblyTree.ShowNodeToolTips = true;
			this.assemblyTree.Size = new System.Drawing.Size(352, 322);
			this.assemblyTree.TabIndex = 1;
			// 
			// assemblyTreeImageList
			// 
			this.assemblyTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("assemblyTreeImageList.ImageStream")));
			this.assemblyTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.assemblyTreeImageList.Images.SetKeyName(0, "Blank.png");
			this.assemblyTreeImageList.Images.SetKeyName(1, "Assembly.png");
			this.assemblyTreeImageList.Images.SetKeyName(2, "NameSpace.png");
			this.assemblyTreeImageList.Images.SetKeyName(3, "Event.png");
			this.assemblyTreeImageList.Images.SetKeyName(4, "Class.png");
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(709, 528);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(701, 502);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(701, 502);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// projectTree
			// 
			this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.projectTree.ImageIndex = 0;
			this.projectTree.ImageList = this.projectTreeImageList;
			this.projectTree.Location = new System.Drawing.Point(0, 0);
			this.projectTree.Name = "projectTree";
			this.projectTree.SelectedImageIndex = 0;
			this.projectTree.Size = new System.Drawing.Size(352, 202);
			this.projectTree.TabIndex = 0;
			// 
			// projectTreeImageList
			// 
			this.projectTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("projectTreeImageList.ImageStream")));
			this.projectTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.projectTreeImageList.Images.SetKeyName(0, "Blank.png");
			this.projectTreeImageList.Images.SetKeyName(1, "gear.png");
			this.projectTreeImageList.Images.SetKeyName(2, "database.png");
			this.projectTreeImageList.Images.SetKeyName(3, "database--minus.png");
			this.projectTreeImageList.Images.SetKeyName(4, "database--plus.png");
			this.projectTreeImageList.Images.SetKeyName(5, "databases.png");
			// 
			// NewPatcherWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1081, 590);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "NewPatcherWindow";
			this.Text = "Unity Patcher";
			this.Load += new System.EventHandler(this.NewPatcherWindow_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ImageList assemblyTreeImageList;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TreeView assemblyTree;
		private System.Windows.Forms.TreeView projectTree;
		private System.Windows.Forms.ImageList projectTreeImageList;
	}
}