namespace SimpleDownloadManager
{
    partial class SimpleDownloadmanager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startDownloadButton = new System.Windows.Forms.Button();
            this.fileStoreDirectoryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.destFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sourceFileNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.tastListDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tastListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filrToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filrToolStripMenuItem
            // 
            this.filrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.filrToolStripMenuItem.Name = "filrToolStripMenuItem";
            this.filrToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.filrToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.startDownloadButton);
            this.groupBox1.Controls.Add(this.fileStoreDirectoryButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.destFileTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sourceFileNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // startDownloadButton
            // 
            this.startDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startDownloadButton.Location = new System.Drawing.Point(502, 23);
            this.startDownloadButton.Name = "startDownloadButton";
            this.startDownloadButton.Size = new System.Drawing.Size(84, 23);
            this.startDownloadButton.TabIndex = 5;
            this.startDownloadButton.Text = "&Add to list";
            this.startDownloadButton.UseVisualStyleBackColor = true;
            this.startDownloadButton.Click += new System.EventHandler(this.addToDownloadListButton_Click);
            // 
            // fileStoreDirectoryButton
            // 
            this.fileStoreDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fileStoreDirectoryButton.Location = new System.Drawing.Point(456, 35);
            this.fileStoreDirectoryButton.Name = "fileStoreDirectoryButton";
            this.fileStoreDirectoryButton.Size = new System.Drawing.Size(40, 20);
            this.fileStoreDirectoryButton.TabIndex = 4;
            this.fileStoreDirectoryButton.Text = "...";
            this.fileStoreDirectoryButton.UseVisualStyleBackColor = true;
            this.fileStoreDirectoryButton.Click += new System.EventHandler(this.fileStoreDirectoryButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination file";
            // 
            // destFileTextBox
            // 
            this.destFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.destFileTextBox.Location = new System.Drawing.Point(88, 35);
            this.destFileTextBox.Name = "destFileTextBox";
            this.destFileTextBox.Size = new System.Drawing.Size(369, 20);
            this.destFileTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source file";
            // 
            // sourceFileNameTextBox
            // 
            this.sourceFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFileNameTextBox.Location = new System.Drawing.Point(88, 10);
            this.sourceFileNameTextBox.Name = "sourceFileNameTextBox";
            this.sourceFileNameTextBox.Size = new System.Drawing.Size(408, 20);
            this.sourceFileNameTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.closeButton);
            this.groupBox2.Controls.Add(this.deleteItemButton);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.pauseButton);
            this.groupBox2.Controls.Add(this.restartButton);
            this.groupBox2.Controls.Add(this.tastListDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(0, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 394);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(502, 368);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(86, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteItemButton.Location = new System.Drawing.Point(499, 124);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(86, 23);
            this.deleteItemButton.TabIndex = 4;
            this.deleteItemButton.Text = "&Delete from list";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Location = new System.Drawing.Point(499, 68);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(86, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.Location = new System.Drawing.Point(499, 39);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(86, 23);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "&Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.restartButton.Location = new System.Drawing.Point(499, 10);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(86, 23);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "&Start";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tastListDataGridView
            // 
            this.tastListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tastListDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tastListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tastListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tastListDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.tastListDataGridView.Location = new System.Drawing.Point(2, 7);
            this.tastListDataGridView.MultiSelect = false;
            this.tastListDataGridView.Name = "tastListDataGridView";
            this.tastListDataGridView.ReadOnly = true;
            this.tastListDataGridView.RowHeadersVisible = false;
            this.tastListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tastListDataGridView.Size = new System.Drawing.Size(494, 384);
            this.tastListDataGridView.TabIndex = 0;
            this.tastListDataGridView.Click += new System.EventHandler(this.tastListDataGridView_Click);
            // 
            // SimpleDownloadmanager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(599, 516);
            this.MinimumSize = new System.Drawing.Size(599, 516);
            this.Name = "SimpleDownloadmanager";
            this.Text = "Simple download manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tastListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox destFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sourceFileNameTextBox;
        private System.Windows.Forms.Button fileStoreDirectoryButton;
        private System.Windows.Forms.Button startDownloadButton;
        private System.Windows.Forms.DataGridView tastListDataGridView;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.Button stopButton;
    }
}

