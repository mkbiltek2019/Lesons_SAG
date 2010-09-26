namespace TaskManagerCS
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView = new System.Windows.Forms.ListView();
            this.procName = new System.Windows.Forms.ColumnHeader();
            this.pId = new System.Windows.Forms.ColumnHeader();
            this.procStatrTime = new System.Windows.Forms.ColumnHeader();
            this.procCpuTime = new System.Windows.Forms.ColumnHeader();
            this.memoryUsage = new System.Windows.Forms.ColumnHeader();
            this.peakMemoryUsage = new System.Windows.Forms.ColumnHeader();
            this.heandles = new System.Windows.Forms.ColumnHeader();
            this.threds = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.завершитьПроцессToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выхоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.разверутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.procName,
            this.pId,
            this.procStatrTime,
            this.procCpuTime,
            this.memoryUsage,
            this.peakMemoryUsage,
            this.heandles,
            this.threds});
            this.listView.ContextMenuStrip = this.contextMenu;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(756, 417);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // procName
            // 
            this.procName.Text = "Имя процесса";
            this.procName.Width = 120;
            // 
            // pId
            // 
            this.pId.Text = "PID";
            this.pId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pId.Width = 80;
            // 
            // procStatrTime
            // 
            this.procStatrTime.Text = "Время старта";
            this.procStatrTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.procStatrTime.Width = 90;
            // 
            // procCpuTime
            // 
            this.procCpuTime.Text = "ЦП";
            this.procCpuTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.procCpuTime.Width = 80;
            // 
            // memoryUsage
            // 
            this.memoryUsage.Text = "Память";
            this.memoryUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.memoryUsage.Width = 100;
            // 
            // peakMemoryUsage
            // 
            this.peakMemoryUsage.Text = "Пик  памяти";
            this.peakMemoryUsage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.peakMemoryUsage.Width = 100;
            // 
            // heandles
            // 
            this.heandles.Text = "Дескрипторов";
            this.heandles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.heandles.Width = 90;
            // 
            // threds
            // 
            this.threds.Text = "Потоков";
            this.threds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.threds.Width = 90;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(756, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.Text = "Процессов:  ";
            this.toolStripStatusLabel1.ToolTipText = "        ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel2.Text = "Потоков:";
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Диспетчер задач в видимом режиме";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.завершитьПроцессToolStripMenuItem,
            this.выхоToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(185, 48);
            this.contextMenu.Text = "Контекстное меню";
            // 
            // завершитьПроцессToolStripMenuItem
            // 
            this.завершитьПроцессToolStripMenuItem.Name = "завершитьПроцессToolStripMenuItem";
            this.завершитьПроцессToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.завершитьПроцессToolStripMenuItem.Text = "Завершить процесс";
            this.завершитьПроцессToolStripMenuItem.Click += new System.EventHandler(this.завершитьПроцессToolStripMenuItem_Click);
            // 
            // выхоToolStripMenuItem
            // 
            this.выхоToolStripMenuItem.Name = "выхоToolStripMenuItem";
            this.выхоToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.выхоToolStripMenuItem.Text = "Выход";
            this.выхоToolStripMenuItem.Click += new System.EventHandler(this.выхоToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разверутьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 48);
            // 
            // разверутьToolStripMenuItem
            // 
            this.разверутьToolStripMenuItem.Name = "разверутьToolStripMenuItem";
            this.разверутьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.разверутьToolStripMenuItem.Text = "Разверуть";
            this.разверутьToolStripMenuItem.Click += new System.EventHandler(this.разверутьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 417);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Диспетчер задач ";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader procName;
        private System.Windows.Forms.ColumnHeader pId;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ColumnHeader procStatrTime;
        private System.Windows.Forms.ColumnHeader procCpuTime;
        private System.Windows.Forms.ColumnHeader memoryUsage;
        private System.Windows.Forms.ColumnHeader peakMemoryUsage;
        private System.Windows.Forms.ColumnHeader heandles;
        private System.Windows.Forms.ColumnHeader threds;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem завершитьПроцессToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выхоToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem разверутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}

