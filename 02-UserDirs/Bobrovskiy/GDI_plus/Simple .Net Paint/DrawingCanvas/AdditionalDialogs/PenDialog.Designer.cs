namespace DrawingCanvas.AdditionalDialogs
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.penStyleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.penSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStyleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.penStyleNumericUpDown);
            this.groupBox1.Controls.Add(this.penSizeNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pen Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
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
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pen size";
            // 
            // penStyleNumericUpDown
            // 
            this.penStyleNumericUpDown.Location = new System.Drawing.Point(102, 63);
            this.penStyleNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.penStyleNumericUpDown.Name = "penStyleNumericUpDown";
            this.penStyleNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.penStyleNumericUpDown.TabIndex = 1;
            this.penStyleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // penSizeNumericUpDown
            // 
            this.penSizeNumericUpDown.Location = new System.Drawing.Point(102, 24);
            this.penSizeNumericUpDown.Name = "penSizeNumericUpDown";
            this.penSizeNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.penSizeNumericUpDown.TabIndex = 0;
            this.penSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 152);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PenDialog";
            this.Text = "PenDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStyleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown penStyleNumericUpDown;
        private System.Windows.Forms.NumericUpDown penSizeNumericUpDown;
        private System.Windows.Forms.Button button1;
    }
}