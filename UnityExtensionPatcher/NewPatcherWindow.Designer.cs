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
			this.menuNewProject = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCloseProject = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMostRecent = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.projectTree = new System.Windows.Forms.TreeView();
			this.projectTreeImageList = new System.Windows.Forms.ImageList(this.components);
			this.assemblyTree = new System.Windows.Forms.TreeView();
			this.assemblyTreeImageList = new System.Windows.Forms.ImageList(this.components);
			this.tabsMain = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.contextTabControl = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeOtherTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeTabsToTheRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextProjectAssembly = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.includeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabsMain.SuspendLayout();
			this.contextTabControl.SuspendLayout();
			this.contextProjectAssembly.SuspendLayout();
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
            this.menuNewProject,
            this.menuOpenProject,
            this.menuCloseProject,
            this.toolStripSeparator1,
            this.menuMostRecent,
            this.toolStripSeparator2,
            this.menuQuit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// menuNewProject
			// 
			this.menuNewProject.Name = "menuNewProject";
			this.menuNewProject.Size = new System.Drawing.Size(155, 22);
			this.menuNewProject.Text = "New Project";
			this.menuNewProject.Click += new System.EventHandler(this.menuNewProject_Click);
			// 
			// menuOpenProject
			// 
			this.menuOpenProject.Name = "menuOpenProject";
			this.menuOpenProject.Size = new System.Drawing.Size(155, 22);
			this.menuOpenProject.Text = "Open Project";
			this.menuOpenProject.Click += new System.EventHandler(this.menuOpenProject_Click);
			// 
			// menuCloseProject
			// 
			this.menuCloseProject.Name = "menuCloseProject";
			this.menuCloseProject.Size = new System.Drawing.Size(155, 22);
			this.menuCloseProject.Text = "Close Project";
			this.menuCloseProject.Click += new System.EventHandler(this.menuCloseProject_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
			// 
			// menuMostRecent
			// 
			this.menuMostRecent.Name = "menuMostRecent";
			this.menuMostRecent.Size = new System.Drawing.Size(155, 22);
			this.menuMostRecent.Text = "Recent Projects";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
			// 
			// menuQuit
			// 
			this.menuQuit.Name = "menuQuit";
			this.menuQuit.Size = new System.Drawing.Size(155, 22);
			this.menuQuit.Text = "Quit";
			this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
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
			this.splitContainer1.Panel2.Controls.Add(this.tabsMain);
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
			this.splitContainer2.SplitterDistance = 166;
			this.splitContainer2.TabIndex = 1;
			// 
			// projectTree
			// 
			this.projectTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.projectTree.ImageIndex = 0;
			this.projectTree.ImageList = this.projectTreeImageList;
			this.projectTree.Location = new System.Drawing.Point(0, 0);
			this.projectTree.Name = "projectTree";
			this.projectTree.SelectedImageIndex = 0;
			this.projectTree.Size = new System.Drawing.Size(352, 166);
			this.projectTree.TabIndex = 0;
			this.projectTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.projectTree_MouseUp);
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
			this.projectTreeImageList.Images.SetKeyName(6, "exclamation-button.png");
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
			this.assemblyTree.Size = new System.Drawing.Size(352, 358);
			this.assemblyTree.TabIndex = 1;
			this.assemblyTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.assemblyTree_NodeMouseDoubleClick);
			this.assemblyTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.assemblyTree_MouseUp);
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
			this.assemblyTreeImageList.Images.SetKeyName(5, "exclamation-red-frame.png");
			// 
			// tabsMain
			// 
			this.tabsMain.Controls.Add(this.tabPage1);
			this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabsMain.Location = new System.Drawing.Point(0, 8);
			this.tabsMain.Name = "tabsMain";
			this.tabsMain.SelectedIndex = 0;
			this.tabsMain.Size = new System.Drawing.Size(709, 528);
			this.tabsMain.TabIndex = 0;
			this.tabsMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabsMain_MouseUp);
			// 
			// tabPage1
			// 
			this.tabPage1.ContextMenuStrip = this.contextTabControl;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(701, 502);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Project Settings";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// contextTabControl
			// 
			this.contextTabControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.closeOtherTabsToolStripMenuItem,
            this.closeTabsToTheRightToolStripMenuItem});
			this.contextTabControl.Name = "contextTabControl";
			this.contextTabControl.Size = new System.Drawing.Size(197, 70);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// closeOtherTabsToolStripMenuItem
			// 
			this.closeOtherTabsToolStripMenuItem.Name = "closeOtherTabsToolStripMenuItem";
			this.closeOtherTabsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.closeOtherTabsToolStripMenuItem.Text = "Close Other Tabs";
			this.closeOtherTabsToolStripMenuItem.Click += new System.EventHandler(this.closeOtherTabsToolStripMenuItem_Click);
			// 
			// closeTabsToTheRightToolStripMenuItem
			// 
			this.closeTabsToTheRightToolStripMenuItem.Name = "closeTabsToTheRightToolStripMenuItem";
			this.closeTabsToTheRightToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.closeTabsToTheRightToolStripMenuItem.Text = "Close Tabs to the Right";
			this.closeTabsToTheRightToolStripMenuItem.Click += new System.EventHandler(this.closeTabsToTheRightToolStripMenuItem_Click);
			// 
			// contextProjectAssembly
			// 
			this.contextProjectAssembly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeToolStripMenuItem,
            this.removeToolStripMenuItem});
			this.contextProjectAssembly.Name = "contextProjectAssembly";
			this.contextProjectAssembly.Size = new System.Drawing.Size(118, 48);
			// 
			// includeToolStripMenuItem
			// 
			this.includeToolStripMenuItem.Name = "includeToolStripMenuItem";
			this.includeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.includeToolStripMenuItem.Text = "Include";
			this.includeToolStripMenuItem.Click += new System.EventHandler(this.includeToolStripMenuItem_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
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
			this.tabsMain.ResumeLayout(false);
			this.contextTabControl.ResumeLayout(false);
			this.contextProjectAssembly.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ImageList assemblyTreeImageList;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TreeView assemblyTree;
		private System.Windows.Forms.TreeView projectTree;
		private System.Windows.Forms.ImageList projectTreeImageList;
		private System.Windows.Forms.ToolStripMenuItem menuNewProject;
		private System.Windows.Forms.ToolStripMenuItem menuOpenProject;
		private System.Windows.Forms.ToolStripMenuItem menuCloseProject;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ContextMenuStrip contextProjectAssembly;
		private System.Windows.Forms.ToolStripMenuItem includeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuMostRecent;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabControl tabsMain;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ContextMenuStrip contextTabControl;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeOtherTabsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeTabsToTheRightToolStripMenuItem;
	}
}