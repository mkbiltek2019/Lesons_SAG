namespace RegionOperations
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
            this.mnuComplement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIntersect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExclude = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuOperations
            // 
            this.mnuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSelOperation});
            this.mnuOperations.Location = new System.Drawing.Point(0, 0);
            this.mnuOperations.Name = "mnuOperations";
            this.mnuOperations.Size = new System.Drawing.Size(292, 24);
            this.mnuOperations.TabIndex = 0;
            this.mnuOperations.Text = "menuStrip1";
            // 
            // mnuItemSelOperation
            // 
            this.mnuItemSelOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComplement,
            this.mnuUnion,
            this.mnuIntersect,
            this.mnuExclude,
            this.mnuXor});
            this.mnuItemSelOperation.Name = "mnuItemSelOperation";
            this.mnuItemSelOperation.Size = new System.Drawing.Size(96, 20);
            this.mnuItemSelOperation.Text = "SelectOperation";
            // 
            // mnuComplement
            // 
            this.mnuComplement.Name = "mnuComplement";
            this.mnuComplement.Size = new System.Drawing.Size(152, 22);
            this.mnuComplement.Text = "Complement";
            this.mnuComplement.Click += new System.EventHandler(this.mnuComplement_Click);
            // 
            // mnuUnion
            // 
            this.mnuUnion.Name = "mnuUnion";
            this.mnuUnion.Size = new System.Drawing.Size(152, 22);
            this.mnuUnion.Text = "Union";
            this.mnuUnion.Click += new System.EventHandler(this.mnuUnion_Click);
            // 
            // mnuIntersect
            // 
            this.mnuIntersect.Name = "mnuIntersect";
            this.mnuIntersect.Size = new System.Drawing.Size(152, 22);
            this.mnuIntersect.Text = "Intersect";
            this.mnuIntersect.Click += new System.EventHandler(this.mnuIntersect_Click);
            // 
            // mnuExclude
            // 
            this.mnuExclude.Name = "mnuExclude";
            this.mnuExclude.Size = new System.Drawing.Size(152, 22);
            this.mnuExclude.Text = "Exclude";
            this.mnuExclude.Click += new System.EventHandler(this.mnuExlude_Click);
            // 
            // mnuXor
            // 
            this.mnuXor.Name = "mnuXor";
            this.mnuXor.Size = new System.Drawing.Size(152, 22);
            this.mnuXor.Text = "Xor";
            this.mnuXor.Click += new System.EventHandler(this.mnuXor_Click);
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
        private System.Windows.Forms.ToolStripMenuItem mnuComplement;
        private System.Windows.Forms.ToolStripMenuItem mnuUnion;
        private System.Windows.Forms.ToolStripMenuItem mnuIntersect;
        private System.Windows.Forms.ToolStripMenuItem mnuExclude;
        private System.Windows.Forms.ToolStripMenuItem mnuXor;
    }
}

