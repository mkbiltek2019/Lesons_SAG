namespace MatrixOperations
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
            this.mnuOperations = new System.Windows.Forms.MenuStrip();
            this.mnuItemSelOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuOperations
            // 
            this.mnuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSelOperation,
            this.mnuItemReset});
            this.mnuOperations.Location = new System.Drawing.Point(0, 0);
            this.mnuOperations.Name = "mnuOperations";
            this.mnuOperations.Size = new System.Drawing.Size(292, 24);
            this.mnuOperations.TabIndex = 0;
            this.mnuOperations.Text = "menuStrip1";
            // 
            // mnuItemSelOperation
            // 
            this.mnuItemSelOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRotate,
            this.mnuScale,
            this.mnuShear,
            this.mnuTranslate});
            this.mnuItemSelOperation.Name = "mnuItemSelOperation";
            this.mnuItemSelOperation.Size = new System.Drawing.Size(96, 20);
            this.mnuItemSelOperation.Text = "SelectOperation";
            // 
            // mnuRotate
            // 
            this.mnuRotate.Name = "mnuRotate";
            this.mnuRotate.Size = new System.Drawing.Size(152, 22);
            this.mnuRotate.Text = "Rotate";
            this.mnuRotate.Click += new System.EventHandler(this.mnuRotate_Click);
            // 
            // mnuScale
            // 
            this.mnuScale.Name = "mnuScale";
            this.mnuScale.Size = new System.Drawing.Size(152, 22);
            this.mnuScale.Text = "Scale";
            this.mnuScale.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuShear
            // 
            this.mnuShear.Name = "mnuShear";
            this.mnuShear.Size = new System.Drawing.Size(152, 22);
            this.mnuShear.Text = "Shear";
            this.mnuShear.Click += new System.EventHandler(this.mnuShear_Click);
            // 
            // mnuTranslate
            // 
            this.mnuTranslate.Name = "mnuTranslate";
            this.mnuTranslate.Size = new System.Drawing.Size(152, 22);
            this.mnuTranslate.Text = "Translate";
            this.mnuTranslate.Click += new System.EventHandler(this.mnuTranslate_Click);
            // 
            // mnuItemReset
            // 
            this.mnuItemReset.Name = "mnuItemReset";
            this.mnuItemReset.Size = new System.Drawing.Size(96, 20);
            this.mnuItemReset.Text = "ResetTransform";
            this.mnuItemReset.Click += new System.EventHandler(this.mnuItemReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.mnuOperations);
            this.MainMenuStrip = this.mnuOperations;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.mnuOperations.ResumeLayout(false);
            this.mnuOperations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuOperations;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelOperation;
        private System.Windows.Forms.ToolStripMenuItem mnuRotate;
        private System.Windows.Forms.ToolStripMenuItem mnuScale;
        private System.Windows.Forms.ToolStripMenuItem mnuShear;
        private System.Windows.Forms.ToolStripMenuItem mnuTranslate;
        private System.Windows.Forms.ToolStripMenuItem mnuItemReset;
    }
}

