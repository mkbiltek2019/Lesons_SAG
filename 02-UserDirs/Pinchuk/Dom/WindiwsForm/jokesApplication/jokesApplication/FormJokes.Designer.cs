namespace jokesApplication
{
    partial class FormJokes
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJokes));
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbJoksFileName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbBoring = new System.Windows.Forms.Label();
            this.lbFuny = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wwwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wwToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.VisibleJokes = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сховатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиЖартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сховатиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.показуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdJokesFileName = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(243, 38);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Вибрати";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbJoksFileName);
            this.groupBox1.Controls.Add(this.btnSelectFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вибір файлу з жартами";
            // 
            // tbJoksFileName
            // 
            this.tbJoksFileName.Location = new System.Drawing.Point(12, 41);
            this.tbJoksFileName.Name = "tbJoksFileName";
            this.tbJoksFileName.Size = new System.Drawing.Size(225, 20);
            this.tbJoksFileName.TabIndex = 1;
            this.tbJoksFileName.Text = "JokesFile.xml";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbBoring);
            this.groupBox2.Controls.Add(this.lbFuny);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(10, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(20);
            this.groupBox2.Size = new System.Drawing.Size(344, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ститистика";
            // 
            // lbBoring
            // 
            this.lbBoring.AutoSize = true;
            this.lbBoring.Location = new System.Drawing.Point(174, 32);
            this.lbBoring.Name = "lbBoring";
            this.lbBoring.Size = new System.Drawing.Size(72, 13);
            this.lbBoring.TabIndex = 1;
            this.lbBoring.Text = "Не смішниї:  ";
            // 
            // lbFuny
            // 
            this.lbFuny.AutoSize = true;
            this.lbFuny.Location = new System.Drawing.Point(12, 32);
            this.lbFuny.Name = "lbFuny";
            this.lbFuny.Size = new System.Drawing.Size(58, 13);
            this.lbFuny.TabIndex = 0;
            this.lbFuny.Text = "Смішних:  ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wwwToolStripMenuItem,
            this.wwToolStripMenuItem,
            this.wwToolStripMenuItem1,
            this.VisibleJokes});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(156, 92);
            // 
            // wwwToolStripMenuItem
            // 
            this.wwwToolStripMenuItem.Name = "wwwToolStripMenuItem";
            this.wwwToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.wwwToolStripMenuItem.Text = "Вихід";
            this.wwwToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // wwToolStripMenuItem
            // 
            this.wwToolStripMenuItem.Name = "wwToolStripMenuItem";
            this.wwToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.wwToolStripMenuItem.Text = "Показати";
            this.wwToolStripMenuItem.Click += new System.EventHandler(this.VisibleToolStripMenuItem_Click);
            // 
            // wwToolStripMenuItem1
            // 
            this.wwToolStripMenuItem1.Name = "wwToolStripMenuItem1";
            this.wwToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.wwToolStripMenuItem1.Text = "Сховати";
            this.wwToolStripMenuItem1.Click += new System.EventHandler(this.HiddenToolStripMenuItem_Click);
            // 
            // VisibleJokes
            // 
            this.VisibleJokes.Name = "VisibleJokes";
            this.VisibleJokes.Size = new System.Drawing.Size(155, 22);
            this.VisibleJokes.Text = "Показати жарт";
            this.VisibleJokes.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            // 
            // показатиToolStripMenuItem
            // 
            this.показатиToolStripMenuItem.Name = "показатиToolStripMenuItem";
            this.показатиToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.показатиToolStripMenuItem.Text = "Показати";
            // 
            // сховатиToolStripMenuItem
            // 
            this.сховатиToolStripMenuItem.Name = "сховатиToolStripMenuItem";
            this.сховатиToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.сховатиToolStripMenuItem.Text = "Сховати";
            // 
            // показатиЖартToolStripMenuItem
            // 
            this.показатиЖартToolStripMenuItem.Name = "показатиЖартToolStripMenuItem";
            this.показатиЖартToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.показатиЖартToolStripMenuItem.Text = "Показати жарт";
            // 
            // вихідToolStripMenuItem1
            // 
            this.вихідToolStripMenuItem1.Name = "вихідToolStripMenuItem1";
            this.вихідToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.вихідToolStripMenuItem1.Text = "Вихід";
            // 
            // показатиToolStripMenuItem1
            // 
            this.показатиToolStripMenuItem1.Name = "показатиToolStripMenuItem1";
            this.показатиToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.показатиToolStripMenuItem1.Text = "Показати";
            // 
            // сховатиToolStripMenuItem1
            // 
            this.сховатиToolStripMenuItem1.Name = "сховатиToolStripMenuItem1";
            this.сховатиToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.сховатиToolStripMenuItem1.Text = "Сховати";
            // 
            // показуватиToolStripMenuItem
            // 
            this.показуватиToolStripMenuItem.Name = "показуватиToolStripMenuItem";
            this.показуватиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.показуватиToolStripMenuItem.Text = "Показувати";
            // 
            // FormJokes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 174);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormJokes";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "FormJokes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbJoksFileName;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сховатиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиЖартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem показатиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сховатиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem показуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem VisibleJokes;
        private System.Windows.Forms.OpenFileDialog ofdJokesFileName;
        private System.Windows.Forms.Label lbBoring;
        private System.Windows.Forms.Label lbFuny;
    }
}

