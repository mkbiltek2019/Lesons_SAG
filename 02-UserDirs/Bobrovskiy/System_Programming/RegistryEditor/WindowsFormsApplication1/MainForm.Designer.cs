namespace WindowsFormsApplication1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRegistryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteKeyOrParameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.RegistryKeyToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MegaRegistryViewControl = new RegistryViewMegaControl.RegistryViewControl();
            this.createSubkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRegistryKeyToolStripMenuItem,
            this.deleteKeyOrParameterToolStripMenuItem,
            this.createSubkeyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // addRegistryKeyToolStripMenuItem
            // 
            this.addRegistryKeyToolStripMenuItem.Name = "addRegistryKeyToolStripMenuItem";
            this.addRegistryKeyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addRegistryKeyToolStripMenuItem.Text = "&Add registry entry";
            this.addRegistryKeyToolStripMenuItem.Click += new System.EventHandler(this.addRegistryKeyToolStripMenuItem_Click);
            // 
            // deleteKeyOrParameterToolStripMenuItem
            // 
            this.deleteKeyOrParameterToolStripMenuItem.Name = "deleteKeyOrParameterToolStripMenuItem";
            this.deleteKeyOrParameterToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteKeyOrParameterToolStripMenuItem.Text = "&Delete key or parameter";
            this.deleteKeyOrParameterToolStripMenuItem.Click += new System.EventHandler(this.deleteKeyOrParameterToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contextToolStripMenuItem
            // 
            this.contextToolStripMenuItem.Name = "contextToolStripMenuItem";
            this.contextToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.contextToolStripMenuItem.Text = "&Context";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegistryKeyToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(648, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // RegistryKeyToolStripStatusLabel
            // 
            this.RegistryKeyToolStripStatusLabel.Name = "RegistryKeyToolStripStatusLabel";
            this.RegistryKeyToolStripStatusLabel.Size = new System.Drawing.Size(68, 17);
            this.RegistryKeyToolStripStatusLabel.Text = "MyComputer";
            // 
            // MegaRegistryViewControl
            // 
            this.MegaRegistryViewControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MegaRegistryViewControl.FullPath = null;
            this.MegaRegistryViewControl.Location = new System.Drawing.Point(0, 25);
            this.MegaRegistryViewControl.Name = "MegaRegistryViewControl";
            this.MegaRegistryViewControl.Size = new System.Drawing.Size(648, 455);
            this.MegaRegistryViewControl.TabIndex = 0;
            // 
            // createSubkeyToolStripMenuItem
            // 
            this.createSubkeyToolStripMenuItem.Name = "createSubkeyToolStripMenuItem";
            this.createSubkeyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createSubkeyToolStripMenuItem.Text = "&Create subkey";
            this.createSubkeyToolStripMenuItem.Click += new System.EventHandler(this.createSubkeyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 502);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MegaRegistryViewControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RegistryEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RegistryViewMegaControl.RegistryViewControl MegaRegistryViewControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel RegistryKeyToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRegistryKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteKeyOrParameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createSubkeyToolStripMenuItem;
    }
}

