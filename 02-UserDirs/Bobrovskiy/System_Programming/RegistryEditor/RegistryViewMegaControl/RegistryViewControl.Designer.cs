namespace RegistryViewMegaControl
{
    partial class RegistryViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistryViewControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RegistryTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fullPathToKeyTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.RegistryTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(688, 476);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 0;
            // 
            // RegistryTreeView
            // 
            this.RegistryTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistryTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistryTreeView.ImageIndex = 0;
            this.RegistryTreeView.ImageList = this.imageList1;
            this.RegistryTreeView.Location = new System.Drawing.Point(0, 0);
            this.RegistryTreeView.Name = "RegistryTreeView";
            this.RegistryTreeView.SelectedImageIndex = 0;
            this.RegistryTreeView.Size = new System.Drawing.Size(274, 476);
            this.RegistryTreeView.TabIndex = 0;
            this.RegistryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RegistryTreeView_AfterSelect);
            this.RegistryTreeView.Click += new System.EventHandler(this.RegistryTreeView_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder_Closed.png");
            this.imageList1.Images.SetKeyName(1, "Folder_Open.png");
            this.imageList1.Images.SetKeyName(2, "Folder_Back.png");
            this.imageList1.Images.SetKeyName(3, "Folder_Front.png");
            this.imageList1.Images.SetKeyName(4, "foldergreen.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(410, 476);
            this.dataGridView1.TabIndex = 0;
            // 
            // fullPathToKeyTextBox
            // 
            this.fullPathToKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fullPathToKeyTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fullPathToKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullPathToKeyTextBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fullPathToKeyTextBox.Location = new System.Drawing.Point(0, 475);
            this.fullPathToKeyTextBox.Name = "fullPathToKeyTextBox";
            this.fullPathToKeyTextBox.ReadOnly = true;
            this.fullPathToKeyTextBox.Size = new System.Drawing.Size(688, 22);
            this.fullPathToKeyTextBox.TabIndex = 1;
            // 
            // RegistryViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fullPathToKeyTextBox);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RegistryViewControl";
            this.Size = new System.Drawing.Size(688, 497);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView RegistryTreeView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox fullPathToKeyTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}
