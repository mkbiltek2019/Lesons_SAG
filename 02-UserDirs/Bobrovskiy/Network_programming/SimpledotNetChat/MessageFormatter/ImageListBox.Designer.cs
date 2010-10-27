namespace MessageFormatter
{
    partial class ImageListBox
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
            this.olvData = new BrightIdeasSoftware.DataListView();
            this.olvColumnGif = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageRenderer1 = new BrightIdeasSoftware.ImageRenderer();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageRenderer2 = new BrightIdeasSoftware.ImageRenderer();
            ((System.ComponentModel.ISupportInitialize)(this.olvData)).BeginInit();
            this.SuspendLayout();
            // 
            // olvData
            // 
            this.olvData.AllColumns.Add(this.olvColumnGif);
            this.olvData.AllColumns.Add(this.olvColumn1);
            this.olvData.AllowColumnReorder = true;
            this.olvData.AllowDrop = true;
            this.olvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.olvData.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.olvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnGif,
            this.olvColumn1});
            this.olvData.CopySelectionOnControlC = false;
            this.olvData.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvData.DataSource = null;
            this.olvData.EmptyListMsg = "No users";
            this.olvData.EmptyListMsgFont = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvData.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvData.FullRowSelect = true;
            this.olvData.GroupWithItemCountFormat = "";
            this.olvData.GroupWithItemCountSingularFormat = "";
            this.olvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.olvData.HideSelection = false;
            this.olvData.HighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.olvData.HighlightForegroundColor = System.Drawing.Color.Black;
            this.olvData.ItemRenderer = this.imageRenderer2;
            this.olvData.Location = new System.Drawing.Point(3, 0);
            this.olvData.MultiSelect = false;
            this.olvData.Name = "olvData";
            this.olvData.OwnerDraw = true;
            this.olvData.SelectAllOnControlA = false;
            this.olvData.ShowCommandMenuOnRightClick = true;
            this.olvData.ShowGroups = false;
            this.olvData.ShowHeaderInAllViews = false;
            this.olvData.ShowImagesOnSubItems = true;
            this.olvData.ShowItemToolTips = true;
            this.olvData.Size = new System.Drawing.Size(178, 428);
            this.olvData.TabIndex = 2;
            this.olvData.UseCellFormatEvents = true;
            this.olvData.UseCompatibleStateImageBehavior = false;
            this.olvData.UseExplorerTheme = true;
            this.olvData.UseHotItem = true;
            this.olvData.UseTranslucentHotItem = true;
            this.olvData.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnGif
            // 
            this.olvColumnGif.AspectName = "SmileName";
            this.olvColumnGif.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnGif.Renderer = this.imageRenderer1;
            this.olvColumnGif.Text = "Animated GIF";
            this.olvColumnGif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnGif.Width = 50;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsTileViewColumn = true;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 150;
            // 
            // ImageListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.olvData);
            this.Name = "ImageListBox";
            this.Size = new System.Drawing.Size(181, 431);
            ((System.ComponentModel.ISupportInitialize)(this.olvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView olvData;
        private BrightIdeasSoftware.OLVColumn olvColumnGif;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.ImageRenderer imageRenderer2;
        private BrightIdeasSoftware.ImageRenderer imageRenderer1;


    }
}
