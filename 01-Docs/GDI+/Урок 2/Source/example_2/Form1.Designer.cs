namespace example_2
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
            this.cbxSmoothing = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbxSmoothing
            // 
            this.cbxSmoothing.AutoSize = true;
            this.cbxSmoothing.Location = new System.Drawing.Point(12, 12);
            this.cbxSmoothing.Name = "cbxSmoothing";
            this.cbxSmoothing.Size = new System.Drawing.Size(94, 17);
            this.cbxSmoothing.TabIndex = 0;
            this.cbxSmoothing.Text = "Сглаживание";
            this.cbxSmoothing.UseVisualStyleBackColor = true;
            this.cbxSmoothing.CheckedChanged += new System.EventHandler(this.cbxSmoothing_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 444);
            this.Controls.Add(this.cbxSmoothing);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxSmoothing;

    }
}

