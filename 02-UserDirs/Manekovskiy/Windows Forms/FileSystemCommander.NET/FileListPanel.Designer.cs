namespace FileSystemCommander.NET
{
    partial class FileListPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListPanel));
            this.listView1 = new System.Windows.Forms.ListView();
            this.fileNameHeader = new System.Windows.Forms.ColumnHeader();
            this.fileSizeHeader = new System.Windows.Forms.ColumnHeader();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bigImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameHeader,
            this.fileSizeHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.LargeImageList = this.bigImageList;
            this.listView1.Location = new System.Drawing.Point(0, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(316, 410);
            this.listView1.SmallImageList = this.smallImageList;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // fileNameHeader
            // 
            this.fileNameHeader.Text = "File Name";
            this.fileNameHeader.Width = 111;
            // 
            // fileSizeHeader
            // 
            this.fileSizeHeader.Text = "File Size";
            this.fileSizeHeader.Width = 111;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bigImageList
            // 
            this.bigImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("bigImageList.ImageStream")));
            this.bigImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.bigImageList.Images.SetKeyName(0, "AttachmentHH.bmp");
            this.bigImageList.Images.SetKeyName(1, "AddTableHH.bmp");
            this.bigImageList.Images.SetKeyName(2, "ArrangeWindowsHH.bmp");
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "AddToFavoritesHS.bmp");
            this.smallImageList.Images.SetKeyName(1, "ActualSizeHS.bmp");
            this.smallImageList.Images.SetKeyName(2, "AddTableHS.bmp");
            // 
            // FileListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView1);
            this.Name = "FileListPanel";
            this.Size = new System.Drawing.Size(316, 437);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader fileNameHeader;
        private System.Windows.Forms.ColumnHeader fileSizeHeader;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList bigImageList;
        private System.Windows.Forms.ImageList smallImageList;
    }
}
