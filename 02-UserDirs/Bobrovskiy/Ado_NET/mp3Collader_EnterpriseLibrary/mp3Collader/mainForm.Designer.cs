namespace mp3Collader
{
    partial class mainForm
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
            System.Windows.Forms.ToolStrip mainToolStrip;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.artistComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.albumComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.genreComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.fileNameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.prevPageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pageNumberToolStripButton = new System.Windows.Forms.ToolStripLabel();
            this.nextPageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processSelectedFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredTrackInFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredDataToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            mainToolStrip = new System.Windows.Forms.ToolStrip();
            mainToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.artistComboBox,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.albumComboBox,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.genreComboBox,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.fileNameComboBox,
            this.toolStripSeparator1,
            this.prevPageToolStripButton,
            this.pageNumberToolStripButton,
            this.nextPageToolStripButton,
            this.toolStripLabel5});
            mainToolStrip.Location = new System.Drawing.Point(0, 0);
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.Size = new System.Drawing.Size(767, 25);
            mainToolStrip.TabIndex = 0;
            mainToolStrip.Text = "mainToolStrip";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Artist";
            // 
            // artistComboBox
            // 
            this.artistComboBox.CausesValidation = false;
            this.artistComboBox.DropDownWidth = 200;
            this.artistComboBox.Name = "artistComboBox";
            this.artistComboBox.Size = new System.Drawing.Size(100, 25);
            this.artistComboBox.SelectedIndexChanged += new System.EventHandler(this.albumComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel2.Text = "Album";
            // 
            // albumComboBox
            // 
            this.albumComboBox.DropDownWidth = 200;
            this.albumComboBox.Name = "albumComboBox";
            this.albumComboBox.Size = new System.Drawing.Size(100, 25);
            this.albumComboBox.SelectedIndexChanged += new System.EventHandler(this.albumComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel3.Text = "Genre";
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownWidth = 200;
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(100, 25);
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.albumComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel4.Text = "File Name";
            // 
            // fileNameComboBox
            // 
            this.fileNameComboBox.DropDownWidth = 200;
            this.fileNameComboBox.Name = "fileNameComboBox";
            this.fileNameComboBox.Size = new System.Drawing.Size(100, 25);
            this.fileNameComboBox.SelectedIndexChanged += new System.EventHandler(this.albumComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // prevPageToolStripButton
            // 
            this.prevPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevPageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("prevPageToolStripButton.Image")));
            this.prevPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevPageToolStripButton.Name = "prevPageToolStripButton";
            this.prevPageToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.prevPageToolStripButton.Tag = "back";
            this.prevPageToolStripButton.Text = "Prev";
            this.prevPageToolStripButton.Click += new System.EventHandler(this.prevPageToolStripButton_Click);
            // 
            // pageNumberToolStripButton
            // 
            this.pageNumberToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pageNumberToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pageNumberToolStripButton.Image")));
            this.pageNumberToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pageNumberToolStripButton.Name = "pageNumberToolStripButton";
            this.pageNumberToolStripButton.Size = new System.Drawing.Size(13, 22);
            this.pageNumberToolStripButton.Text = "  ";
            // 
            // nextPageToolStripButton
            // 
            this.nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextPageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nextPageToolStripButton.Image")));
            this.nextPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextPageToolStripButton.Name = "nextPageToolStripButton";
            this.nextPageToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nextPageToolStripButton.Tag = "forward";
            this.nextPageToolStripButton.Text = "Next";
            this.nextPageToolStripButton.Click += new System.EventHandler(this.nextPageToolStripButton_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel5.Text = "Page size";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(mainToolStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.19266F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.80734F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(767, 436);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDataGridView.Location = new System.Drawing.Point(3, 29);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.ReadOnly = true;
            this.mainDataGridView.Size = new System.Drawing.Size(761, 404);
            this.mainDataGridView.TabIndex = 1;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(767, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processSelectedFolderToolStripMenuItem,
            this.saveFilteredTrackInFolderToolStripMenuItem,
            this.saveFilteredDataToFolderToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // processSelectedFolderToolStripMenuItem
            // 
            this.processSelectedFolderToolStripMenuItem.Name = "processSelectedFolderToolStripMenuItem";
            this.processSelectedFolderToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.processSelectedFolderToolStripMenuItem.Text = "&Process SelectedFolder";
            this.processSelectedFolderToolStripMenuItem.Click += new System.EventHandler(this.processSelectedFolderToolStripMenuItem_Click);
            // 
            // saveFilteredTrackInFolderToolStripMenuItem
            // 
            this.saveFilteredTrackInFolderToolStripMenuItem.Name = "saveFilteredTrackInFolderToolStripMenuItem";
            this.saveFilteredTrackInFolderToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveFilteredTrackInFolderToolStripMenuItem.Text = "&Save Track In DataBase";
            this.saveFilteredTrackInFolderToolStripMenuItem.Click += new System.EventHandler(this.saveFilteredTrackInFolderToolStripMenuItem_Click_1);
            // 
            // saveFilteredDataToFolderToolStripMenuItem
            // 
            this.saveFilteredDataToFolderToolStripMenuItem.Name = "saveFilteredDataToFolderToolStripMenuItem";
            this.saveFilteredDataToFolderToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveFilteredDataToFolderToolStripMenuItem.Text = "&Save filtered data to Folder";
            this.saveFilteredDataToFolderToolStripMenuItem.Click += new System.EventHandler(this.saveFilteredDataToFolderToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDatabaseToolStripMenuItem,
            this.toolStripMenuItem2});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            this.clearDatabaseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.clearDatabaseToolStripMenuItem.Text = "&Clear database";
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem2.Text = "&Set parameter";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pageSizeNumericUpDown
            // 
            this.pageSizeNumericUpDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pageSizeNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pageSizeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageSizeNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pageSizeNumericUpDown.Location = new System.Drawing.Point(710, 27);
            this.pageSizeNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.pageSizeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pageSizeNumericUpDown.Name = "pageSizeNumericUpDown";
            this.pageSizeNumericUpDown.ReadOnly = true;
            this.pageSizeNumericUpDown.Size = new System.Drawing.Size(53, 19);
            this.pageSizeNumericUpDown.TabIndex = 2;
            this.pageSizeNumericUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.pageSizeNumericUpDown.ValueChanged += new System.EventHandler(this.pageSizeNumericUpDown_ValueChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 460);
            this.Controls.Add(this.pageSizeNumericUpDown);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "mainForm";
            this.Text = "mp3 Collader";
            mainToolStrip.ResumeLayout(false);
            mainToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton prevPageToolStripButton;
        private System.Windows.Forms.ToolStripButton nextPageToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown pageSizeNumericUpDown;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processSelectedFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredTrackInFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox artistComboBox;
        private System.Windows.Forms.ToolStripComboBox albumComboBox;
        private System.Windows.Forms.ToolStripComboBox genreComboBox;
        private System.Windows.Forms.ToolStripComboBox fileNameComboBox;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredDataToFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel pageNumberToolStripButton;
    }
}

