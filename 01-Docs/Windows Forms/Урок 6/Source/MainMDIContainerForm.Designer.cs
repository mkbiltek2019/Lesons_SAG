namespace MDIExample
{
    partial class MainMDIContainerForm
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewtextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewRichTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenRichTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMinimazeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaximizeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.MainMenuStrip.AllowItemReorder = true;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiWindow,
            this.tsmiLayout,
            this.tsmiHelp});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.MdiWindowListItem = this.tsmiWindow;
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenuStrip.ShowItemToolTips = true;
            this.MainMenuStrip.Size = new System.Drawing.Size(624, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.toolStripSeparator2,
            this.tsmiClose,
            this.tsmiCloseAll,
            this.toolStripSeparator1,
            this.tsmiSave,
            this.tsmiSaveAs,
            this.tsmiSaveAll,
            this.toolStripSeparator3,
            this.tsmiExit});
            this.tsmiFile.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.tsmiFile.MergeIndex = 1;
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiNew
            // 
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewtextFile,
            this.tsmiNewRichTextFile});
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(152, 22);
            this.tsmiNew.Text = "&New";
            // 
            // tsmiNewtextFile
            // 
            this.tsmiNewtextFile.Name = "tsmiNewtextFile";
            this.tsmiNewtextFile.Size = new System.Drawing.Size(170, 22);
            this.tsmiNewtextFile.Text = "&New Text File";
            this.tsmiNewtextFile.Click += new System.EventHandler(this.tsmiNewTextFile_Click);
            // 
            // tsmiNewRichTextFile
            // 
            this.tsmiNewRichTextFile.Name = "tsmiNewRichTextFile";
            this.tsmiNewRichTextFile.Size = new System.Drawing.Size(170, 22);
            this.tsmiNewRichTextFile.Text = "&New Rich Text File";
            this.tsmiNewRichTextFile.Click += new System.EventHandler(this.tsmiNewRichTextFile_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenTextFile,
            this.tsmiOpenRichTextFile});
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(152, 22);
            this.tsmiOpen.Text = "&Open";
            // 
            // tsmiOpenTextFile
            // 
            this.tsmiOpenTextFile.Name = "tsmiOpenTextFile";
            this.tsmiOpenTextFile.Size = new System.Drawing.Size(175, 22);
            this.tsmiOpenTextFile.Text = "Open Text File";
            this.tsmiOpenTextFile.Click += new System.EventHandler(this.tsmiOpenTextFile_Click);
            // 
            // tsmiOpenRichTextFile
            // 
            this.tsmiOpenRichTextFile.Name = "tsmiOpenRichTextFile";
            this.tsmiOpenRichTextFile.Size = new System.Drawing.Size(175, 22);
            this.tsmiOpenRichTextFile.Text = "Open Rich Text File";
            this.tsmiOpenRichTextFile.Click += new System.EventHandler(this.tsmiOpenRichTextFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(152, 22);
            this.tsmiClose.Text = "&Close";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // tsmiCloseAll
            // 
            this.tsmiCloseAll.Name = "tsmiCloseAll";
            this.tsmiCloseAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiCloseAll.Text = "&Close All";
            this.tsmiCloseAll.Click += new System.EventHandler(this.tsmiCloseAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(152, 22);
            this.tsmiSave.Text = "&Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(152, 22);
            this.tsmiSaveAs.Text = "&Save As . . .";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // tsmiSaveAll
            // 
            this.tsmiSaveAll.Name = "tsmiSaveAll";
            this.tsmiSaveAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiSaveAll.Text = "&Save All";
            this.tsmiSaveAll.Click += new System.EventHandler(this.tsmiSaveAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "&Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiWindow
            // 
            this.tsmiWindow.AutoToolTip = true;
            this.tsmiWindow.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.tsmiWindow.Name = "tsmiWindow";
            this.tsmiWindow.Size = new System.Drawing.Size(63, 20);
            this.tsmiWindow.Text = "&Window";
            // 
            // tsmiLayout
            // 
            this.tsmiLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCascade,
            this.toolStripSeparator5,
            this.tsmiArrangeIcons,
            this.tsmiTileHorizontal,
            this.tsmiTileVertical,
            this.toolStripSeparator4,
            this.tsmiMinimazeAll,
            this.tsmiMaximizeAll});
            this.tsmiLayout.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.tsmiLayout.Name = "tsmiLayout";
            this.tsmiLayout.Size = new System.Drawing.Size(55, 20);
            this.tsmiLayout.Text = "&Layout";
            this.tsmiLayout.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tsmiCascade
            // 
            this.tsmiCascade.Name = "tsmiCascade";
            this.tsmiCascade.Size = new System.Drawing.Size(152, 22);
            this.tsmiCascade.Text = "&Cascade";
            this.tsmiCascade.Click += new System.EventHandler(this.tsmiCascade_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiArrangeIcons
            // 
            this.tsmiArrangeIcons.Name = "tsmiArrangeIcons";
            this.tsmiArrangeIcons.Size = new System.Drawing.Size(152, 22);
            this.tsmiArrangeIcons.Text = "&ArrangeIcons";
            this.tsmiArrangeIcons.Click += new System.EventHandler(this.tsmiArrangeIcons_Click);
            // 
            // tsmiTileHorizontal
            // 
            this.tsmiTileHorizontal.Name = "tsmiTileHorizontal";
            this.tsmiTileHorizontal.Size = new System.Drawing.Size(152, 22);
            this.tsmiTileHorizontal.Text = "&TileHorizontal";
            this.tsmiTileHorizontal.Click += new System.EventHandler(this.tsmiTileHorizontal_Click);
            // 
            // tsmiTileVertical
            // 
            this.tsmiTileVertical.Name = "tsmiTileVertical";
            this.tsmiTileVertical.Size = new System.Drawing.Size(152, 22);
            this.tsmiTileVertical.Text = "&TileVertical";
            this.tsmiTileVertical.Click += new System.EventHandler(this.tsmiTileVertical_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiMinimazeAll
            // 
            this.tsmiMinimazeAll.Name = "tsmiMinimazeAll";
            this.tsmiMinimazeAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiMinimazeAll.Text = "&Minimaze All";
            this.tsmiMinimazeAll.Click += new System.EventHandler(this.tsmiMinimazeAll_Click);
            // 
            // tsmiMaximizeAll
            // 
            this.tsmiMaximizeAll.Name = "tsmiMaximizeAll";
            this.tsmiMaximizeAll.Size = new System.Drawing.Size(152, 22);
            this.tsmiMaximizeAll.Text = "&Maximize All";
            this.tsmiMaximizeAll.Click += new System.EventHandler(this.tsmiMaximizeAll_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "&Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmiAbout.Text = "&About";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // MainMDIContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 444);
            this.Controls.Add(this.MainMenuStrip);
            this.IsMdiContainer = true;
            this.Name = "MainMDIContainerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDI Example";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiLayout;
        private System.Windows.Forms.ToolStripMenuItem tsmiCascade;
        private System.Windows.Forms.ToolStripMenuItem tsmiArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmiTileVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmiMinimazeAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaximizeAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewtextFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewRichTextFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenTextFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenRichTextFile;
    }
}

