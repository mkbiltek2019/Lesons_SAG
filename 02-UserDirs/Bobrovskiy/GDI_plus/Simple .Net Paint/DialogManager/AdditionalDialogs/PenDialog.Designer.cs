namespace DialogManger.AdditionalDialogs
{
    partial class PenDialog
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
            this.label5 = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.penStartDomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.penEndDomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.penWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.penStrengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.solidPenCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penStrengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.solidPenCheckBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.colorButton);
            this.groupBox1.Controls.Add(this.penStartDomainUpDown);
            this.groupBox1.Controls.Add(this.penEndDomainUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.penWidthNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.penStrengthNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pen Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Pen end line style";
            // 
            // colorButton
            // 
            this.colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorButton.ForeColor = System.Drawing.Color.White;
            this.colorButton.Location = new System.Drawing.Point(102, 149);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(64, 52);
            this.colorButton.TabIndex = 10;
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // penStartDomainUpDown
            // 
            this.penStartDomainUpDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.penStartDomainUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penStartDomainUpDown.Location = new System.Drawing.Point(102, 84);
            this.penStartDomainUpDown.Name = "penStartDomainUpDown";
            this.penStartDomainUpDown.ReadOnly = true;
            this.penStartDomainUpDown.Size = new System.Drawing.Size(193, 22);
            this.penStartDomainUpDown.TabIndex = 9;
            // 
            // penEndDomainUpDown
            // 
            this.penEndDomainUpDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.penEndDomainUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penEndDomainUpDown.Location = new System.Drawing.Point(102, 119);
            this.penEndDomainUpDown.Name = "penEndDomainUpDown";
            this.penEndDomainUpDown.ReadOnly = true;
            this.penEndDomainUpDown.Size = new System.Drawing.Size(193, 22);
            this.penEndDomainUpDown.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pen width";
            // 
            // penWidthNumericUpDown
            // 
            this.penWidthNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penWidthNumericUpDown.Location = new System.Drawing.Point(102, 50);
            this.penWidthNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.penWidthNumericUpDown.Name = "penWidthNumericUpDown";
            this.penWidthNumericUpDown.Size = new System.Drawing.Size(146, 22);
            this.penWidthNumericUpDown.TabIndex = 6;
            this.penWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pen start line style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pen end line style";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pen strength";
            // 
            // penStrengthNumericUpDown
            // 
            this.penStrengthNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penStrengthNumericUpDown.Location = new System.Drawing.Point(102, 24);
            this.penStrengthNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.penStrengthNumericUpDown.Name = "penStrengthNumericUpDown";
            this.penStrengthNumericUpDown.Size = new System.Drawing.Size(146, 22);
            this.penStrengthNumericUpDown.TabIndex = 0;
            this.penStrengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // solidPenCheckBox
            // 
            this.solidPenCheckBox.AutoSize = true;
            this.solidPenCheckBox.Location = new System.Drawing.Point(206, 168);
            this.solidPenCheckBox.Name = "solidPenCheckBox";
            this.solidPenCheckBox.Size = new System.Drawing.Size(71, 17);
            this.solidPenCheckBox.TabIndex = 12;
            this.solidPenCheckBox.Text = "Solid Pen";
            this.solidPenCheckBox.UseVisualStyleBackColor = true;
            // 
            // PenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PenDialog";
            this.Text = "PenDialog";
            this.Load += new System.EventHandler(this.PenDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penStrengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown penStrengthNumericUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown penWidthNumericUpDown;
        private System.Windows.Forms.DomainUpDown penStartDomainUpDown;
        private System.Windows.Forms.DomainUpDown penEndDomainUpDown;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox solidPenCheckBox;
    }
}