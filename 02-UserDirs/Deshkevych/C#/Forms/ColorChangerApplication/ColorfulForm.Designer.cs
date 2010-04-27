namespace ColorChangerApplication
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.previewColorPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.doNotExcludeColorComponentsRadioButton = new System.Windows.Forms.RadioButton();
            this.blueExcludeRadioButton = new System.Windows.Forms.RadioButton();
            this.greenExludeRadioButton = new System.Windows.Forms.RadioButton();
            this.redExculeRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.greenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.blueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.redNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.previewGroupBox.SuspendLayout();
            this.previewColorPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 609);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группа управления цветом";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(323, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 16;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 529);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(507, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.previewGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 411);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // previewGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.previewGroupBox, 2);
            this.previewGroupBox.Controls.Add(this.previewColorPanel);
            this.previewGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewGroupBox.Location = new System.Drawing.Point(3, 138);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(531, 270);
            this.previewGroupBox.TabIndex = 12;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Предпросмотр";
            // 
            // previewColorPanel
            // 
            this.previewColorPanel.Controls.Add(this.groupBox2);
            this.previewColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewColorPanel.Location = new System.Drawing.Point(3, 16);
            this.previewColorPanel.Name = "previewColorPanel";
            this.previewColorPanel.Size = new System.Drawing.Size(525, 251);
            this.previewColorPanel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.doNotExcludeColorComponentsRadioButton);
            this.groupBox2.Controls.Add(this.blueExcludeRadioButton);
            this.groupBox2.Controls.Add(this.greenExludeRadioButton);
            this.groupBox2.Controls.Add(this.redExculeRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 124);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Исключить цветовой компонент";
            // 
            // doNotExcludeColorComponentsRadioButton
            // 
            this.doNotExcludeColorComponentsRadioButton.Checked = true;
            this.doNotExcludeColorComponentsRadioButton.Location = new System.Drawing.Point(6, 88);
            this.doNotExcludeColorComponentsRadioButton.Name = "doNotExcludeColorComponentsRadioButton";
            this.doNotExcludeColorComponentsRadioButton.Size = new System.Drawing.Size(146, 31);
            this.doNotExcludeColorComponentsRadioButton.TabIndex = 3;
            this.doNotExcludeColorComponentsRadioButton.TabStop = true;
            this.doNotExcludeColorComponentsRadioButton.Text = "Не исключать цветовые компоненты";
            this.doNotExcludeColorComponentsRadioButton.UseVisualStyleBackColor = true;
            this.doNotExcludeColorComponentsRadioButton.CheckedChanged += new System.EventHandler(this.doNotExcludeColorComponentsRadioButton_CheckedChanged);
            // 
            // blueExcludeRadioButton
            // 
            this.blueExcludeRadioButton.AutoSize = true;
            this.blueExcludeRadioButton.Location = new System.Drawing.Point(6, 65);
            this.blueExcludeRadioButton.Name = "blueExcludeRadioButton";
            this.blueExcludeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.blueExcludeRadioButton.TabIndex = 2;
            this.blueExcludeRadioButton.Text = "Синий";
            this.blueExcludeRadioButton.UseVisualStyleBackColor = true;
            this.blueExcludeRadioButton.CheckedChanged += new System.EventHandler(this.blueExcludeRadioButton_CheckedChanged);
            // 
            // greenExludeRadioButton
            // 
            this.greenExludeRadioButton.AutoSize = true;
            this.greenExludeRadioButton.Location = new System.Drawing.Point(6, 42);
            this.greenExludeRadioButton.Name = "greenExludeRadioButton";
            this.greenExludeRadioButton.Size = new System.Drawing.Size(70, 17);
            this.greenExludeRadioButton.TabIndex = 1;
            this.greenExludeRadioButton.Text = "Зеленый";
            this.greenExludeRadioButton.UseVisualStyleBackColor = true;
            this.greenExludeRadioButton.CheckedChanged += new System.EventHandler(this.greenExludeRadioButton_CheckedChanged);
            // 
            // redExculeRadioButton
            // 
            this.redExculeRadioButton.AutoSize = true;
            this.redExculeRadioButton.Location = new System.Drawing.Point(6, 19);
            this.redExculeRadioButton.Name = "redExculeRadioButton";
            this.redExculeRadioButton.Size = new System.Drawing.Size(70, 17);
            this.redExculeRadioButton.TabIndex = 0;
            this.redExculeRadioButton.Text = "Красный";
            this.redExculeRadioButton.UseVisualStyleBackColor = true;
            this.redExculeRadioButton.CheckedChanged += new System.EventHandler(this.redExculeRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.greenNumericUpDown);
            this.panel1.Controls.Add(this.blueNumericUpDown);
            this.panel1.Controls.Add(this.blueTrackBar);
            this.panel1.Controls.Add(this.greenTrackBar);
            this.panel1.Controls.Add(this.redNumericUpDown);
            this.panel1.Controls.Add(this.redTrackBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 129);
            this.panel1.TabIndex = 13;
            // 
            // greenNumericUpDown
            // 
            this.greenNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.greenNumericUpDown.Location = new System.Drawing.Point(420, 43);
            this.greenNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenNumericUpDown.Name = "greenNumericUpDown";
            this.greenNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.greenNumericUpDown.TabIndex = 17;
            this.greenNumericUpDown.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // blueNumericUpDown
            // 
            this.blueNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.blueNumericUpDown.Location = new System.Drawing.Point(420, 85);
            this.blueNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueNumericUpDown.Name = "blueNumericUpDown";
            this.blueNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.blueNumericUpDown.TabIndex = 16;
            this.blueNumericUpDown.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.blueTrackBar.AutoSize = false;
            this.blueTrackBar.Location = new System.Drawing.Point(9, 85);
            this.blueTrackBar.Maximum = 255;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(405, 36);
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
            this.greenTrackBar.Location = new System.Drawing.Point(9, 43);
            this.greenTrackBar.Maximum = 255;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(405, 36);
            this.greenTrackBar.TabIndex = 14;
            this.greenTrackBar.TickFrequency = 10;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // redNumericUpDown
            // 
            this.redNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.redNumericUpDown.Location = new System.Drawing.Point(420, 1);
            this.redNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redNumericUpDown.Name = "redNumericUpDown";
            this.redNumericUpDown.Size = new System.Drawing.Size(102, 20);
            this.redNumericUpDown.TabIndex = 13;
            this.redNumericUpDown.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // redTrackBar
            // 
            this.redTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.redTrackBar.AutoSize = false;
            this.redTrackBar.Location = new System.Drawing.Point(9, 1);
            this.redTrackBar.Maximum = 255;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(405, 36);
            this.redTrackBar.TabIndex = 12;
            this.redTrackBar.TickFrequency = 10;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.redTrackBar.ValueChanged += new System.EventHandler(this.ColorComponentControlValue_ValueChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(543, 24);
            this.mainMenuStrip.TabIndex = 7;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 633);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainMenuStrip);
            this.Name = "Form1";
            this.Text = "Coolorful Form";
            this.MouseCaptureChanged += new System.EventHandler(this.Close_Forms);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Close_Forms);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.previewGroupBox.ResumeLayout(false);
            this.previewColorPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.greenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.Panel previewColorPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown greenNumericUpDown;
        private System.Windows.Forms.NumericUpDown blueNumericUpDown;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.NumericUpDown redNumericUpDown;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton blueExcludeRadioButton;
        private System.Windows.Forms.RadioButton greenExludeRadioButton;
        private System.Windows.Forms.RadioButton redExculeRadioButton;
        private System.Windows.Forms.RadioButton doNotExcludeColorComponentsRadioButton;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

