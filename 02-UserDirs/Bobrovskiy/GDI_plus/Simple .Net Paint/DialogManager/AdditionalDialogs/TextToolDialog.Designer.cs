namespace DialogManger.AdditionalDialogs
{
    partial class TextToolDialog
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gradientDomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientCheckBox = new System.Windows.Forms.CheckBox();
            this.endColorButton = new System.Windows.Forms.Button();
            this.startColorButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.fontButton = new System.Windows.Forms.Button();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SetButton = new System.Windows.Forms.Button();
            this.textureCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.texturePictureBox = new System.Windows.Forms.PictureBox();
            this.SolidCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.endColorButton);
            this.groupBox1.Controls.Add(this.startColorButton);
            this.groupBox1.Controls.Add(this.mainPanel);
            this.groupBox1.Controls.Add(this.fontButton);
            this.groupBox1.Controls.Add(this.mainTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Tool Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SolidCheckBox);
            this.groupBox2.Controls.Add(this.textureCheckBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.gradientDomainUpDown);
            this.groupBox2.Controls.Add(this.zoomNumericUpDown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.gradientCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(146, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 74);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Gradient direction";
            // 
            // gradientDomainUpDown
            // 
            this.gradientDomainUpDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gradientDomainUpDown.Location = new System.Drawing.Point(102, 46);
            this.gradientDomainUpDown.Name = "gradientDomainUpDown";
            this.gradientDomainUpDown.ReadOnly = true;
            this.gradientDomainUpDown.Size = new System.Drawing.Size(191, 20);
            this.gradientDomainUpDown.TabIndex = 9;
            this.gradientDomainUpDown.SelectedItemChanged += new System.EventHandler(this.gradientCheckBox_CheckedChanged);
            // 
            // zoomNumericUpDown
            // 
            this.zoomNumericUpDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zoomNumericUpDown.Location = new System.Drawing.Point(42, 19);
            this.zoomNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomNumericUpDown.Name = "zoomNumericUpDown";
            this.zoomNumericUpDown.ReadOnly = true;
            this.zoomNumericUpDown.Size = new System.Drawing.Size(40, 20);
            this.zoomNumericUpDown.TabIndex = 2;
            this.zoomNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zoomNumericUpDown.ValueChanged += new System.EventHandler(this.zoomNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Zoom";
            // 
            // gradientCheckBox
            // 
            this.gradientCheckBox.AutoSize = true;
            this.gradientCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gradientCheckBox.Location = new System.Drawing.Point(102, 19);
            this.gradientCheckBox.Name = "gradientCheckBox";
            this.gradientCheckBox.Size = new System.Drawing.Size(64, 17);
            this.gradientCheckBox.TabIndex = 4;
            this.gradientCheckBox.Text = "Gradient";
            this.gradientCheckBox.UseVisualStyleBackColor = true;
            this.gradientCheckBox.CheckedChanged += new System.EventHandler(this.gradientCheckBox_CheckedChanged);
            // 
            // endColorButton
            // 
            this.endColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.endColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.endColorButton.Image = global::DialogManager.Properties.Resources.color;
            this.endColorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.endColorButton.Location = new System.Drawing.Point(9, 204);
            this.endColorButton.Name = "endColorButton";
            this.endColorButton.Size = new System.Drawing.Size(85, 33);
            this.endColorButton.TabIndex = 7;
            this.endColorButton.Text = "End";
            this.endColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.endColorButton.UseVisualStyleBackColor = true;
            this.endColorButton.Click += new System.EventHandler(this.EndColorButton_Click);
            // 
            // startColorButton
            // 
            this.startColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startColorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startColorButton.Image = global::DialogManager.Properties.Resources.color;
            this.startColorButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startColorButton.Location = new System.Drawing.Point(9, 169);
            this.startColorButton.Name = "startColorButton";
            this.startColorButton.Size = new System.Drawing.Size(85, 32);
            this.startColorButton.TabIndex = 6;
            this.startColorButton.Text = "Start";
            this.startColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startColorButton.UseVisualStyleBackColor = true;
            this.startColorButton.Click += new System.EventHandler(this.textColorButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.ForeColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(9, 19);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(437, 144);
            this.mainPanel.TabIndex = 5;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // fontButton
            // 
            this.fontButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fontButton.Image = global::DialogManager.Properties.Resources.text;
            this.fontButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fontButton.Location = new System.Drawing.Point(97, 169);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(46, 68);
            this.fontButton.TabIndex = 3;
            this.fontButton.Text = "Text Font";
            this.fontButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainTextBox.Location = new System.Drawing.Point(40, 243);
            this.mainTextBox.MaxLength = 500;
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(405, 44);
            this.mainTextBox.TabIndex = 2;
            this.mainTextBox.TextChanged += new System.EventHandler(this.mainTextBox_TextChanged);
            this.mainTextBox.Leave += new System.EventHandler(this.mainTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(341, 368);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(101, 30);
            this.SetButton.TabIndex = 1;
            this.SetButton.Text = "Set data";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // textureCheckBox
            // 
            this.textureCheckBox.AutoSize = true;
            this.textureCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.textureCheckBox.Location = new System.Drawing.Point(180, 19);
            this.textureCheckBox.Name = "textureCheckBox";
            this.textureCheckBox.Size = new System.Drawing.Size(60, 17);
            this.textureCheckBox.TabIndex = 11;
            this.textureCheckBox.Text = "Texture";
            this.textureCheckBox.UseVisualStyleBackColor = true;
            this.textureCheckBox.CheckedChanged += new System.EventHandler(this.gradientCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load texture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.texturePictureBox);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(3, 302);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 107);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text texture";
            // 
            // texturePictureBox
            // 
            this.texturePictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.texturePictureBox.Location = new System.Drawing.Point(9, 19);
            this.texturePictureBox.Name = "texturePictureBox";
            this.texturePictureBox.Size = new System.Drawing.Size(99, 77);
            this.texturePictureBox.TabIndex = 3;
            this.texturePictureBox.TabStop = false;
            // 
            // SolidCheckBox
            // 
            this.SolidCheckBox.AutoSize = true;
            this.SolidCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SolidCheckBox.Location = new System.Drawing.Point(246, 19);
            this.SolidCheckBox.Name = "SolidCheckBox";
            this.SolidCheckBox.Size = new System.Drawing.Size(47, 17);
            this.SolidCheckBox.TabIndex = 12;
            this.SolidCheckBox.Text = "Solid";
            this.SolidCheckBox.UseVisualStyleBackColor = true;
            this.SolidCheckBox.CheckedChanged += new System.EventHandler(this.gradientCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(341, 312);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 30);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save Text";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TextToolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 417);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TextToolDialog";
            this.Text = "TextToolDialog";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TextToolDialog_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.texturePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.CheckBox gradientCheckBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button startColorButton;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.Button endColorButton;
        private System.Windows.Forms.NumericUpDown zoomNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DomainUpDown gradientDomainUpDown;
        private System.Windows.Forms.CheckBox textureCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox texturePictureBox;
        private System.Windows.Forms.CheckBox SolidCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}