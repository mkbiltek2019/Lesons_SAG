namespace MatrixInvert
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
            this.mnuMatrixTransform = new System.Windows.Forms.MenuStrip();
            this.mnuInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMatrix1 = new System.Windows.Forms.Label();
            this.mnuMatrixTransform.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMatrixTransform
            // 
            this.mnuMatrixTransform.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInvert});
            this.mnuMatrixTransform.Location = new System.Drawing.Point(0, 0);
            this.mnuMatrixTransform.Name = "mnuMatrixTransform";
            this.mnuMatrixTransform.Size = new System.Drawing.Size(292, 24);
            this.mnuMatrixTransform.TabIndex = 0;
            this.mnuMatrixTransform.Text = "menuStrip1";
            // 
            // mnuInvert
            // 
            this.mnuInvert.Name = "mnuInvert";
            this.mnuInvert.Size = new System.Drawing.Size(49, 20);
            this.mnuInvert.Text = "Invert";
            this.mnuInvert.Click += new System.EventHandler(this.mnuInvert_Click);
            // 
            // lblMatrix1
            // 
            this.lblMatrix1.AutoSize = true;
            this.lblMatrix1.Location = new System.Drawing.Point(12, 59);
            this.lblMatrix1.Name = "lblMatrix1";
            this.lblMatrix1.Size = new System.Drawing.Size(0, 13);
            this.lblMatrix1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.lblMatrix1);
            this.Controls.Add(this.mnuMatrixTransform);
            this.MainMenuStrip = this.mnuMatrixTransform;
            this.Name = "Form1";
            this.Text = "Form1";
            this.mnuMatrixTransform.ResumeLayout(false);
            this.mnuMatrixTransform.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMatrixTransform;
        private System.Windows.Forms.ToolStripMenuItem mnuInvert;
        private System.Windows.Forms.Label lblMatrix1;
    }
}

