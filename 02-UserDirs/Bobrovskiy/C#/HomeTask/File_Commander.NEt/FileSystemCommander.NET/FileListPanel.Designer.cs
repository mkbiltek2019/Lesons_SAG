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
            this.bigImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.fileNameHeader = new System.Windows.Forms.ColumnHeader();
            this.fileSizeHeader = new System.Windows.Forms.ColumnHeader();
            this.fileLastModified = new System.Windows.Forms.ColumnHeader();
            this.fileLastAccessed = new System.Windows.Forms.ColumnHeader();
            this.mainListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bigImageList
            // 
            this.bigImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.bigImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.bigImageList.TransparentColor = System.Drawing.Color.White;
            // 
            // smallImageList
            // 
            this.smallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.smallImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.smallImageList.TransparentColor = System.Drawing.Color.White;
            // 
            // mainImageList
            // 
            this.mainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.mainImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.mainImageList.TransparentColor = System.Drawing.Color.White;
            // 
            // fileNameHeader
            // 
            this.fileNameHeader.Text = "File Name";
            this.fileNameHeader.Width = 200;
            // 
            // fileSizeHeader
            // 
            this.fileSizeHeader.Text = "File Size";
            this.fileSizeHeader.Width = 90;
            // 
            // fileLastModified
            // 
            this.fileLastModified.Text = "Last Modified";
            this.fileLastModified.Width = 140;
            // 
            // fileLastAccessed
            // 
            this.fileLastAccessed.Text = "Last Accesse Time";
            this.fileLastAccessed.Width = 100;
            // 
            // mainListView
            // 
            this.mainListView.AllowColumnReorder = true;
            this.mainListView.AllowDrop = true;
            this.mainListView.BackColor = System.Drawing.Color.White;
            this.mainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameHeader,
            this.fileSizeHeader,
            this.fileLastModified,
            this.fileLastAccessed});
            this.mainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListView.FullRowSelect = true;
            this.mainListView.LargeImageList = this.bigImageList;
            this.mainListView.Location = new System.Drawing.Point(0, 0);
            this.mainListView.Margin = new System.Windows.Forms.Padding(0);
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(316, 437);
            this.mainListView.SmallImageList = this.smallImageList;
            this.mainListView.TabIndex = 1;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.Details;
            this.mainListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mainListView_MouseDoubleClick);
            this.mainListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainListView_MouseUp);
            this.mainListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainListView_DragDrop);
            this.mainListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainListView_MouseMove);
            this.mainListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainListView_MouseDown);
            this.mainListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainListView_DragEnter);
            // 
            // FileListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainListView);
            this.Name = "FileListPanel";
            this.Size = new System.Drawing.Size(316, 437);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList bigImageList;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ImageList mainImageList;
        private System.Windows.Forms.ColumnHeader fileNameHeader;
        private System.Windows.Forms.ColumnHeader fileSizeHeader;
        private System.Windows.Forms.ColumnHeader fileLastModified;
        private System.Windows.Forms.ColumnHeader fileLastAccessed;
        private System.Windows.Forms.ListView mainListView;
    }
}
