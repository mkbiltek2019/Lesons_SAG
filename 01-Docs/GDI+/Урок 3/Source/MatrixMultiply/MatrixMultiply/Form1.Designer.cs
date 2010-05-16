namespace MatrixMultiply
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
            this.mnuMultiply = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMatrix1 = new System.Windows.Forms.Label();
            this.lblMatrix2 = new System.Windows.Forms.Label();
            this.lblMatrix3 = new System.Windows.Forms.Label();
            this.lblMult = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.mnuMatrixTransform.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMatrixTransform
            // 
            this.mnuMatrixTransform.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMultiply});
            this.mnuMatrixTransform.Location = new System.Drawing.Point(0, 0);
            this.mnuMatrixTransform.Name = "mnuMatrixTransform";
            this.mnuMatrixTransform.Size = new System.Drawing.Size(292, 24);
            this.mnuMatrixTransform.TabIndex = 0;
            this.mnuMatrixTransform.Text = "menuStrip1";
            // 
            // mnuMultiply
            // 
            this.mnuMultiply.Name = "mnuMultiply";
            this.mnuMultiply.Size = new System.Drawing.Size(55, 20);
            this.mnuMultiply.Text = "Multiply";
            this.mnuMultiply.Click += new System.EventHandler(this.mnuMultiply_Click);
            // 
            // lblMatrix1
            // 
            this.lblMatrix1.AutoSize = true;
            this.lblMatrix1.Location = new System.Drawing.Point(12, 59);
            this.lblMatrix1.Name = "lblMatrix1";
            this.lblMatrix1.Size = new System.Drawing.Size(0, 13);
            this.lblMatrix1.TabIndex = 1;
            // 
            // lblMatrix2
            // 
            this.lblMatrix2.AutoSize = true;
            this.lblMatrix2.Location = new System.Drawing.Point(104, 59);
            this.lblMatrix2.Name = "lblMatrix2";
            this.lblMatrix2.Size = new System.Drawing.Size(0, 13);
            this.lblMatrix2.TabIndex = 2;
            // 
            // lblMatrix3
            // 
            this.lblMatrix3.AutoSize = true;
            this.lblMatrix3.Location = new System.Drawing.Point(202, 59);
            this.lblMatrix3.Name = "lblMatrix3";
            this.lblMatrix3.Size = new System.Drawing.Size(0, 13);
            this.lblMatrix3.TabIndex = 3;
            // 
            // lblMult
            // 
            this.lblMult.AutoSize = true;
            this.lblMult.Location = new System.Drawing.Point(87, 59);
            this.lblMult.Name = "lblMult";
            this.lblMult.Size = new System.Drawing.Size(11, 13);
            this.lblMult.TabIndex = 4;
            this.lblMult.Text = "*";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(183, 59);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(13, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblMult);
            this.Controls.Add(this.lblMatrix3);
            this.Controls.Add(this.lblMatrix2);
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
        private System.Windows.Forms.ToolStripMenuItem mnuMultiply;
        private System.Windows.Forms.Label lblMatrix1;
        private System.Windows.Forms.Label lblMatrix2;
        private System.Windows.Forms.Label lblMatrix3;
        private System.Windows.Forms.Label lblMult;
        private System.Windows.Forms.Label lblResult;
    }
}

