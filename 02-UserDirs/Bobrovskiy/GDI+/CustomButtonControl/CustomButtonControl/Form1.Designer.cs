namespace CustomButtonControl
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
            this.userControl11 = new CustomButtonControlLibrary.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.BorderRadius = 30;
            this.userControl11.ClickDepth = 3;
            this.userControl11.GradientAngle = 270F;
            this.userControl11.GradientColorEnd = System.Drawing.Color.RoyalBlue;
            this.userControl11.GradientColorStart = System.Drawing.Color.MidnightBlue;
            this.userControl11.Location = new System.Drawing.Point(39, 12);
            this.userControl11.Name = "userControl11";
            this.userControl11.PenColor = System.Drawing.Color.DarkSlateBlue;
            this.userControl11.PenThickness = 1;
            this.userControl11.Size = new System.Drawing.Size(31, 172);
            this.userControl11.TabIndex = 0;
            this.userControl11.Click += new System.EventHandler(this.userControl11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButtonControlLibrary.UserControl1 userControl11;


    }
}

