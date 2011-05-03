namespace ControlUser
{
    partial class FileLister
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.logicDiskList = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.curentDirectorylistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bigImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.PathCurentDirectory = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Location = new System.Drawing.Point(0, 692);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // logicDiskList
            // 
            this.logicDiskList.Font = new System.Drawing.Font("Tahoma", 10F);
            this.logicDiskList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.logicDiskList.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.logicDiskList.Location = new System.Drawing.Point(0, 0);
            this.logicDiskList.Name = "logicDiskList";
            this.logicDiskList.Size = new System.Drawing.Size(655, 25);
            this.logicDiskList.TabIndex = 2;
            this.logicDiskList.Text = "LogicDiskList";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.curentDirectorylistView);
            this.panel1.Controls.Add(this.PathCurentDirectory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 667);
            this.panel1.TabIndex = 4;
            // 
            // curentDirectorylistView
            // 
            this.curentDirectorylistView.BackColor = System.Drawing.Color.Black;
            this.curentDirectorylistView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.curentDirectorylistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.curentDirectorylistView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curentDirectorylistView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.curentDirectorylistView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.curentDirectorylistView.FullRowSelect = true;
            this.curentDirectorylistView.LargeImageList = this.bigImageList;
            this.curentDirectorylistView.Location = new System.Drawing.Point(0, 16);
            this.curentDirectorylistView.MultiSelect = false;
            this.curentDirectorylistView.Name = "curentDirectorylistView";
            this.curentDirectorylistView.Size = new System.Drawing.Size(655, 651);
            this.curentDirectorylistView.SmallImageList = this.smallImageList;
            this.curentDirectorylistView.TabIndex = 1;
            this.curentDirectorylistView.UseCompatibleStateImageBehavior = false;
            this.curentDirectorylistView.View = System.Windows.Forms.View.Details;
            this.curentDirectorylistView.Enter += new System.EventHandler(this.curentDirectorylistView_Enter);
            this.curentDirectorylistView.Leave += new System.EventHandler(this.curentDirectorylistView_Leave);
            this.curentDirectorylistView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.curentDirectorylistView_MouseClick);
            this.curentDirectorylistView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CurentDirectorylistView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            this.columnHeader2.Width = 153;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Размер";
            this.columnHeader3.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата";
            this.columnHeader4.Width = 150;
            // 
            // bigImageList
            // 
            this.bigImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.bigImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.bigImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // smallImageList
            // 
            this.smallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.smallImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // PathCurentDirectory
            // 
            this.PathCurentDirectory.AcceptsReturn = true;
            this.PathCurentDirectory.AcceptsTab = true;
            this.PathCurentDirectory.BackColor = System.Drawing.Color.Silver;
            this.PathCurentDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PathCurentDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PathCurentDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.PathCurentDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PathCurentDirectory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.PathCurentDirectory.Location = new System.Drawing.Point(0, 0);
            this.PathCurentDirectory.Name = "PathCurentDirectory";
            this.PathCurentDirectory.ReadOnly = true;
            this.PathCurentDirectory.Size = new System.Drawing.Size(655, 16);
            this.PathCurentDirectory.TabIndex = 0;
            this.PathCurentDirectory.TabStop = false;
            this.PathCurentDirectory.WordWrap = false;
            // 
            // FileLister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logicDiskList);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FileLister";
            this.Size = new System.Drawing.Size(655, 714);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip logicDiskList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ImageList bigImageList;
        private System.Windows.Forms.ListView curentDirectorylistView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox PathCurentDirectory;

    }
}
