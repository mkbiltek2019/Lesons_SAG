namespace FileManager
{
    partial class FileListPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListPanel));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.nameHeader = new System.Windows.Forms.ColumnHeader();
            this.sizeHeader = new System.Windows.Forms.ColumnHeader();
            this.timeCreatedHeader = new System.Windows.Forms.ColumnHeader();
            this.timeCgangedHeader = new System.Windows.Forms.ColumnHeader();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bigImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(331, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.sizeHeader,
            this.timeCreatedHeader,
            this.timeCgangedHeader});
            this.listView1.LargeImageList = this.bigImageList;
            this.listView1.Location = new System.Drawing.Point(0, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(449, 564);
            this.listView1.SmallImageList = this.smallImageList;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Файл";
            this.nameHeader.Width = 140;
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "Размер";
            this.sizeHeader.Width = 80;
            // 
            // timeCreatedHeader
            // 
            this.timeCreatedHeader.Text = "Время создания";
            this.timeCreatedHeader.Width = 120;
            // 
            // timeCgangedHeader
            // 
            this.timeCgangedHeader.Text = "Время изменения";
            this.timeCgangedHeader.Width = 120;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Image = global::FileManager.Properties.Resources.Back;
            this.button3.Location = new System.Drawing.Point(407, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::FileManager.Properties.Resources.HDD;
            this.button2.Location = new System.Drawing.Point(372, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "D:";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::FileManager.Properties.Resources.HDC12;
            this.button1.Location = new System.Drawing.Point(334, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "C:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bigImageList
            // 
            this.bigImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("bigImageList.ImageStream")));
            this.bigImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.bigImageList.Images.SetKeyName(0, "2.ico");
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "3.ico");
            // 
            // FileListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBox1);
            this.Name = "FileListPanel";
            this.Size = new System.Drawing.Size(449, 615);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader sizeHeader;
        private System.Windows.Forms.ColumnHeader timeCreatedHeader;
        private System.Windows.Forms.ColumnHeader timeCgangedHeader;
        private System.Windows.Forms.ImageList bigImageList;
        private System.Windows.Forms.ImageList smallImageList;
    }
}
