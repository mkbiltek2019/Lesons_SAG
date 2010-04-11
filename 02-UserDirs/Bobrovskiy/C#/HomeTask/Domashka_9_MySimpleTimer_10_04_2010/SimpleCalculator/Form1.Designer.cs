namespace SimpleCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondNumber = new System.Windows.Forms.TextBox();
            this.ResultOfOperation = new System.Windows.Forms.TextBox();
            this.FirstNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Calculate
            // 
            this.Calculate.BackColor = System.Drawing.Color.SandyBrown;
            this.Calculate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(135, 69);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(121, 30);
            this.Calculate.TabIndex = 0;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = false;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(177, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "+";
            // 
            // SecondNumber
            // 
            this.SecondNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SecondNumber.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondNumber.Location = new System.Drawing.Point(219, 9);
            this.SecondNumber.MaxLength = 13;
            this.SecondNumber.Name = "SecondNumber";
            this.SecondNumber.Size = new System.Drawing.Size(159, 32);
            this.SecondNumber.TabIndex = 5;
            this.SecondNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SecondNumber_KeyUp);
            // 
            // ResultOfOperation
            // 
            this.ResultOfOperation.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ResultOfOperation.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultOfOperation.Location = new System.Drawing.Point(75, 121);
            this.ResultOfOperation.MaxLength = 35;
            this.ResultOfOperation.Name = "ResultOfOperation";
            this.ResultOfOperation.ReadOnly = true;
            this.ResultOfOperation.Size = new System.Drawing.Size(246, 32);
            this.ResultOfOperation.TabIndex = 6;
            // 
            // FirstNumber
            // 
            this.FirstNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FirstNumber.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNumber.Location = new System.Drawing.Point(12, 9);
            this.FirstNumber.MaxLength = 13;
            this.FirstNumber.Name = "FirstNumber";
            this.FirstNumber.Size = new System.Drawing.Size(159, 32);
            this.FirstNumber.TabIndex = 7;
            this.FirstNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FirstNumber_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(389, 185);
            this.Controls.Add(this.FirstNumber);
            this.Controls.Add(this.ResultOfOperation);
            this.Controls.Add(this.SecondNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calculate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(397, 212);
            this.MinimumSize = new System.Drawing.Size(397, 212);
            this.Name = "MainForm";
            this.Text = "Simplee Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SecondNumber;
        private System.Windows.Forms.TextBox ResultOfOperation;
        private System.Windows.Forms.TextBox FirstNumber;
    }
}

