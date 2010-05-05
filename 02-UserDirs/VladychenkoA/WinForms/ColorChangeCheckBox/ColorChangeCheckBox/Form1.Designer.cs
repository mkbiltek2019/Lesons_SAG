namespace ColorChangeCheckBox
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.blueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.greenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.redNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBoxPreviewColor = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.doNotExcludeColorComponentsCheckBox = new System.Windows.Forms.CheckBox();
            this.blueCheckBox = new System.Windows.Forms.CheckBox();
            this.greenCheckBox = new System.Windows.Forms.CheckBox();
            this.redCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.redToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.greenToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.blueToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.redToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.greenToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.blueToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            this.groupBoxPreviewColor.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // abutToolStripMenuItem
            // 
            this.abutToolStripMenuItem.Name = "abutToolStripMenuItem";
            this.abutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.abutToolStripMenuItem.Text = "About";
            this.abutToolStripMenuItem.Click += new System.EventHandler(this.abutToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxPreviewColor, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.19949F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.80051F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 391);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.blueNumericUpDown);
            this.groupBox1.Controls.Add(this.greenNumericUpDown);
            this.groupBox1.Controls.Add(this.redNumericUpDown);
            this.groupBox1.Controls.Add(this.blueTrackBar);
            this.groupBox1.Controls.Add(this.greenTrackBar);
            this.groupBox1.Controls.Add(this.redTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление цветом";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Синий";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Зеленый";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Красный";
            // 
            // blueNumericUpDown
            // 
            this.blueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.blueNumericUpDown.Location = new System.Drawing.Point(573, 103);
            this.blueNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueNumericUpDown.Name = "blueNumericUpDown";
            this.blueNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.blueNumericUpDown.TabIndex = 5;
            this.blueNumericUpDown.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // greenNumericUpDown
            // 
            this.greenNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.greenNumericUpDown.Location = new System.Drawing.Point(573, 61);
            this.greenNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenNumericUpDown.Name = "greenNumericUpDown";
            this.greenNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.greenNumericUpDown.TabIndex = 4;
            this.greenNumericUpDown.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // redNumericUpDown
            // 
            this.redNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.redNumericUpDown.Location = new System.Drawing.Point(573, 19);
            this.redNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redNumericUpDown.Name = "redNumericUpDown";
            this.redNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.redNumericUpDown.TabIndex = 3;
            this.redNumericUpDown.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.blueTrackBar.AutoSize = false;
            this.blueTrackBar.Location = new System.Drawing.Point(6, 103);
            this.blueTrackBar.Maximum = 255;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(561, 45);
            this.blueTrackBar.TabIndex = 15;
            this.blueTrackBar.TickFrequency = 10;
            this.blueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.blueTrackBar.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.greenTrackBar.AutoSize = false;
            this.greenTrackBar.Location = new System.Drawing.Point(6, 61);
            this.greenTrackBar.Maximum = 255;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(561, 36);
            this.greenTrackBar.TabIndex = 13;
            this.greenTrackBar.TickFrequency = 10;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // redTrackBar
            // 
            this.redTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.redTrackBar.AutoSize = false;
            this.redTrackBar.Location = new System.Drawing.Point(6, 19);
            this.redTrackBar.Maximum = 255;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(561, 45);
            this.redTrackBar.TabIndex = 12;
            this.redTrackBar.TickFrequency = 10;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.redTrackBar.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // groupBoxPreviewColor
            // 
            this.groupBoxPreviewColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPreviewColor.Controls.Add(this.groupBox3);
            this.groupBoxPreviewColor.Location = new System.Drawing.Point(3, 168);
            this.groupBoxPreviewColor.Name = "groupBoxPreviewColor";
            this.groupBoxPreviewColor.Size = new System.Drawing.Size(676, 220);
            this.groupBoxPreviewColor.TabIndex = 1;
            this.groupBoxPreviewColor.TabStop = false;
            this.groupBoxPreviewColor.Text = "Предпосмотр";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.doNotExcludeColorComponentsCheckBox);
            this.groupBox3.Controls.Add(this.blueCheckBox);
            this.groupBox3.Controls.Add(this.greenCheckBox);
            this.groupBox3.Controls.Add(this.redCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(549, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Исключитть цвет";
            // 
            // doNotExcludeColorComponentsCheckBox
            // 
            this.doNotExcludeColorComponentsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doNotExcludeColorComponentsCheckBox.AutoSize = true;
            this.doNotExcludeColorComponentsCheckBox.Location = new System.Drawing.Point(10, 176);
            this.doNotExcludeColorComponentsCheckBox.Name = "doNotExcludeColorComponentsCheckBox";
            this.doNotExcludeColorComponentsCheckBox.Size = new System.Drawing.Size(97, 17);
            this.doNotExcludeColorComponentsCheckBox.TabIndex = 3;
            this.doNotExcludeColorComponentsCheckBox.Text = "Не исключать";
            this.doNotExcludeColorComponentsCheckBox.UseVisualStyleBackColor = true;
            this.doNotExcludeColorComponentsCheckBox.CheckedChanged += new System.EventHandler(this.doNotExcludeColorComponentsCheckBox_CheckedChanged);
            // 
            // blueCheckBox
            // 
            this.blueCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.blueCheckBox.AutoSize = true;
            this.blueCheckBox.Location = new System.Drawing.Point(10, 133);
            this.blueCheckBox.Name = "blueCheckBox";
            this.blueCheckBox.Size = new System.Drawing.Size(57, 17);
            this.blueCheckBox.TabIndex = 2;
            this.blueCheckBox.Text = "Синий";
            this.blueCheckBox.UseVisualStyleBackColor = true;
            this.blueCheckBox.CheckedChanged += new System.EventHandler(this.blueCheckBox_CheckedChanged);
            // 
            // greenCheckBox
            // 
            this.greenCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.greenCheckBox.AutoSize = true;
            this.greenCheckBox.Location = new System.Drawing.Point(10, 80);
            this.greenCheckBox.Name = "greenCheckBox";
            this.greenCheckBox.Size = new System.Drawing.Size(71, 17);
            this.greenCheckBox.TabIndex = 1;
            this.greenCheckBox.Text = "Зеленый";
            this.greenCheckBox.UseVisualStyleBackColor = true;
            this.greenCheckBox.CheckedChanged += new System.EventHandler(this.greenCheckBox_CheckedChanged);
            // 
            // redCheckBox
            // 
            this.redCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.redCheckBox.AutoSize = true;
            this.redCheckBox.Location = new System.Drawing.Point(10, 34);
            this.redCheckBox.Name = "redCheckBox";
            this.redCheckBox.Size = new System.Drawing.Size(71, 17);
            this.redCheckBox.TabIndex = 0;
            this.redCheckBox.Text = "Красный";
            this.redCheckBox.UseVisualStyleBackColor = true;
            this.redCheckBox.CheckedChanged += new System.EventHandler(this.redCheckBox_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.redToolStripStatusLabel,
            this.greenToolStripStatusLabel,
            this.blueToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(682, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.BackColorChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // redToolStripStatusLabel
            // 
            this.redToolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
            this.redToolStripStatusLabel.Name = "redToolStripStatusLabel";
            this.redToolStripStatusLabel.Size = new System.Drawing.Size(56, 17);
            this.redToolStripStatusLabel.Text = "Красный";
            this.redToolStripStatusLabel.TextChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // greenToolStripStatusLabel
            // 
            this.greenToolStripStatusLabel.ActiveLinkColor = System.Drawing.Color.ForestGreen;
            this.greenToolStripStatusLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.greenToolStripStatusLabel.Name = "greenToolStripStatusLabel";
            this.greenToolStripStatusLabel.Size = new System.Drawing.Size(56, 17);
            this.greenToolStripStatusLabel.Text = "Зелёный";
            this.greenToolStripStatusLabel.TextChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // blueToolStripStatusLabel
            // 
            this.blueToolStripStatusLabel.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.blueToolStripStatusLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.blueToolStripStatusLabel.Name = "blueToolStripStatusLabel";
            this.blueToolStripStatusLabel.Size = new System.Drawing.Size(43, 17);
            this.blueToolStripStatusLabel.Text = "Синий";
            this.blueToolStripStatusLabel.TextChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // redToolTip
            // 
            this.redToolTip.ShowAlways = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ColorChangeChekBox";
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.disabledToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 70);
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.enabledToolStripMenuItem.Text = "Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.disabledToolStripMenuItem.Text = "Disabled";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorChangeCheckBox";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            this.groupBoxPreviewColor.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.NumericUpDown blueNumericUpDown;
        private System.Windows.Forms.NumericUpDown greenNumericUpDown;
        private System.Windows.Forms.NumericUpDown redNumericUpDown;
        private System.Windows.Forms.GroupBox groupBoxPreviewColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox doNotExcludeColorComponentsCheckBox;
        private System.Windows.Forms.CheckBox blueCheckBox;
        private System.Windows.Forms.CheckBox greenCheckBox;
        private System.Windows.Forms.CheckBox redCheckBox;
        private System.Windows.Forms.ToolTip redToolTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip greenToolTip;
        private System.Windows.Forms.ToolTip blueToolTip;
        private System.Windows.Forms.ToolStripStatusLabel redToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel greenToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel blueToolStripStatusLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

