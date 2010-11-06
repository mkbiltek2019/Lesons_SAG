namespace ConverterClient
{
    partial class MainForm
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
            this.getResultButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pythonsUpDown = new System.Windows.Forms.NumericUpDown();
            this.parrotsUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pythonsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parrotsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // getResultButton
            // 
            this.getResultButton.Location = new System.Drawing.Point(9, 65);
            this.getResultButton.Name = "getResultButton";
            this.getResultButton.Size = new System.Drawing.Size(169, 23);
            this.getResultButton.TabIndex = 5;
            this.getResultButton.Text = "Получить результат";
            this.getResultButton.UseVisualStyleBackColor = true;
            this.getResultButton.Click += new System.EventHandler(this.getResultButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Питоны";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Попугаи";
            // 
            // pythonsUpDown
            // 
            this.pythonsUpDown.Location = new System.Drawing.Point(58, 13);
            this.pythonsUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pythonsUpDown.Name = "pythonsUpDown";
            this.pythonsUpDown.Size = new System.Drawing.Size(120, 20);
            this.pythonsUpDown.TabIndex = 8;
            // 
            // parrotsUpDown
            // 
            this.parrotsUpDown.Location = new System.Drawing.Point(58, 40);
            this.parrotsUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.parrotsUpDown.Name = "parrotsUpDown";
            this.parrotsUpDown.Size = new System.Drawing.Size(120, 20);
            this.parrotsUpDown.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.parrotsUpDown);
            this.Controls.Add(this.pythonsUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getResultButton);
            this.Name = "MainForm";
            this.Text = "Converter";
            ((System.ComponentModel.ISupportInitialize)(this.pythonsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parrotsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getResultButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pythonsUpDown;
        private System.Windows.Forms.NumericUpDown parrotsUpDown;

    }
}

