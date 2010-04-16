namespace _01_timer_home
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
            this.digit = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.TextBox();
            this.res = new System.Windows.Forms.Button();
            this.digit2 = new System.Windows.Forms.TextBox();
            this.plus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // digit
            // 
            this.digit.Location = new System.Drawing.Point(26, 155);
            this.digit.Name = "digit";
            this.digit.Size = new System.Drawing.Size(64, 20);
            this.digit.TabIndex = 0;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(67, 237);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(100, 20);
            this.result.TabIndex = 1;
            // 
            // res
            // 
            this.res.Location = new System.Drawing.Point(67, 194);
            this.res.Name = "res";
            this.res.Size = new System.Drawing.Size(100, 23);
            this.res.TabIndex = 3;
            this.res.Text = "RESULT";
            this.res.UseVisualStyleBackColor = true;
            // 
            // digit2
            // 
            this.digit2.Location = new System.Drawing.Point(144, 155);
            this.digit2.Name = "digit2";
            this.digit2.Size = new System.Drawing.Size(63, 20);
            this.digit2.TabIndex = 4;
            // 
            // plus
            // 
            this.plus.AutoSize = true;
            this.plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus.Location = new System.Drawing.Point(110, 158);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(16, 17);
            this.plus.TabIndex = 5;
            this.plus.Text = "+";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "TODAY:";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.date.Location = new System.Drawing.Point(108, 13);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(76, 26);
            this.date.TabIndex = 7;
            this.date.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "SECONDS:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.digit2);
            this.Controls.Add(this.res);
            this.Controls.Add(this.result);
            this.Controls.Add(this.digit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox digit;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button res;
        private System.Windows.Forms.TextBox digit2;
        private System.Windows.Forms.Label plus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label2;
    }
}

