using System.Drawing;

namespace MediaLibraryUserInterface
{
    partial class MainForm
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
            System.Windows.Forms.TabPage trackListTabPage;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.modifyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.downToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.upToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pageSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.trackTabPage = new System.Windows.Forms.TabPage();
            this.singerTabPage = new System.Windows.Forms.TabPage();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            trackListTabPage = new System.Windows.Forms.TabPage();
            this.mainMenuStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // trackListTabPage
            // 
            trackListTabPage.Location = new System.Drawing.Point(4, 22);
            trackListTabPage.Name = "trackListTabPage";
            trackListTabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            trackListTabPage.Size = new System.Drawing.Size(548, 0);
            trackListTabPage.TabIndex = 0;
            trackListTabPage.Text = "TrackList";
            trackListTabPage.UseVisualStyleBackColor = true;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainMenuStrip.Size = new System.Drawing.Size(556, 24);
            this.mainMenuStrip.TabIndex = 0;
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.modifyToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator2,
            this.downToolStripButton,
            this.pageToolStripLabel,
            this.upToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.pageSizeToolStripComboBox});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Size = new System.Drawing.Size(556, 25);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "mainToolStrip";
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(30, 22);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // modifyToolStripButton
            // 
            this.modifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.modifyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("modifyToolStripButton.Image")));
            this.modifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modifyToolStripButton.Name = "modifyToolStripButton";
            this.modifyToolStripButton.Size = new System.Drawing.Size(43, 22);
            this.modifyToolStripButton.Text = "Modify";
            this.modifyToolStripButton.Click += new System.EventHandler(this.modifyToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // downToolStripButton
            // 
            this.downToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downToolStripButton.Image = global::MediaLibraryUserInterface.Properties.Resources.NavBack;
            this.downToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downToolStripButton.Name = "downToolStripButton";
            this.downToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.downToolStripButton.Text = "down";
            this.downToolStripButton.Click += new System.EventHandler(this.downToolStripButton_Click);
            // 
            // pageToolStripLabel
            // 
            this.pageToolStripLabel.Name = "pageToolStripLabel";
            this.pageToolStripLabel.Size = new System.Drawing.Size(17, 22);
            this.pageToolStripLabel.Text = "all";
            // 
            // upToolStripButton
            // 
            this.upToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upToolStripButton.Image = global::MediaLibraryUserInterface.Properties.Resources.NavForward;
            this.upToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upToolStripButton.Name = "upToolStripButton";
            this.upToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.upToolStripButton.Text = "up";
            this.upToolStripButton.Click += new System.EventHandler(this.upToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Page size";
            // 
            // pageSizeToolStripComboBox
            // 
            this.pageSizeToolStripComboBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "50"});
            this.pageSizeToolStripComboBox.Name = "pageSizeToolStripComboBox";
            this.pageSizeToolStripComboBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.pageSizeToolStripComboBox.Size = new System.Drawing.Size(75, 25);
            this.pageSizeToolStripComboBox.Text = "5";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(trackListTabPage);
            this.mainTabControl.Controls.Add(this.trackTabPage);
            this.mainTabControl.Controls.Add(this.singerTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTabControl.Location = new System.Drawing.Point(0, 49);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(556, 21);
            this.mainTabControl.TabIndex = 2;
            this.mainTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.mainTabControl_Selecting);
            // 
            // trackTabPage
            // 
            this.trackTabPage.Location = new System.Drawing.Point(4, 22);
            this.trackTabPage.Name = "trackTabPage";
            this.trackTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.trackTabPage.Size = new System.Drawing.Size(548, 0);
            this.trackTabPage.TabIndex = 1;
            this.trackTabPage.Text = "Track";
            this.trackTabPage.UseVisualStyleBackColor = true;
            // 
            // singerTabPage
            // 
            this.singerTabPage.Location = new System.Drawing.Point(4, 22);
            this.singerTabPage.Name = "singerTabPage";
            this.singerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.singerTabPage.Size = new System.Drawing.Size(548, 0);
            this.singerTabPage.TabIndex = 2;
            this.singerTabPage.Text = "Singer";
            this.singerTabPage.UseVisualStyleBackColor = true;
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainDataGridView.Location = new System.Drawing.Point(0, 71);
            this.mainDataGridView.MultiSelect = false;
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mainDataGridView.Size = new System.Drawing.Size(556, 375);
            this.mainDataGridView.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 447);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage trackTabPage;
        private System.Windows.Forms.TabPage singerTabPage;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton modifyToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton downToolStripButton;
        private System.Windows.Forms.ToolStripLabel pageToolStripLabel;
        private System.Windows.Forms.ToolStripButton upToolStripButton;
        private System.Windows.Forms.ToolStripComboBox pageSizeToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}