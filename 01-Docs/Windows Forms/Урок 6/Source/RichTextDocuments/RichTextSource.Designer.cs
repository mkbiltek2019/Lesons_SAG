namespace MDIExample
{
    partial class RichTextSource
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
            this.tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx
            // 
            this.tbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbx.Location = new System.Drawing.Point(0, 0);
            this.tbx.Multiline = true;
            this.tbx.Name = "tbx";
            this.tbx.ReadOnly = true;
            this.tbx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx.Size = new System.Drawing.Size(706, 414);
            this.tbx.TabIndex = 1;
            // 
            // RichTextSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 414);
            this.Controls.Add(this.tbx);
            this.Name = "RichTextSource";
            this.Text = "RichTextSource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbx;

    }
}