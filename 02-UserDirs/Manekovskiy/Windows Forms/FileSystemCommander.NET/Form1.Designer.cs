namespace FileSystemCommander.NET
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fileListPanel1 = new FileSystemCommander.NET.FileListPanel();
            this.fileListPanel2 = new FileSystemCommander.NET.FileListPanel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileListPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileListPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(756, 474);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 0;
            // 
            // fileListPanel1
            // 
            this.fileListPanel1.CurrentDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("fileListPanel1.CurrentDirectory")));
            this.fileListPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListPanel1.Location = new System.Drawing.Point(0, 0);
            this.fileListPanel1.Name = "fileListPanel1";
            this.fileListPanel1.Size = new System.Drawing.Size(377, 474);
            this.fileListPanel1.TabIndex = 0;
            // 
            // fileListPanel2
            // 
            this.fileListPanel2.CurrentDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("fileListPanel2.CurrentDirectory")));
            this.fileListPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListPanel2.Location = new System.Drawing.Point(0, 0);
            this.fileListPanel2.Name = "fileListPanel2";
            this.fileListPanel2.Size = new System.Drawing.Size(375, 474);
            this.fileListPanel2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 474);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FileListPanel fileListPanel1;
        private FileListPanel fileListPanel2;


    }
}

