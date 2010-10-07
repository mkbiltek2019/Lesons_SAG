namespace HooksInDotNET
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
            this.components = new System.ComponentModel.Container();
            this.installHookButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallHookButton = new System.Windows.Forms.Button();
            this.messageLogTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // installHookButton
            // 
            this.installHookButton.Location = new System.Drawing.Point(12, 248);
            this.installHookButton.Name = "installHookButton";
            this.installHookButton.Size = new System.Drawing.Size(94, 23);
            this.installHookButton.TabIndex = 0;
            this.installHookButton.Text = "Install hook";
            this.installHookButton.UseVisualStyleBackColor = true;
            this.installHookButton.Click += new System.EventHandler(this.InstallHookButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 26);
            // 
            // contextMenuItemToolStripMenuItem
            // 
            this.contextMenuItemToolStripMenuItem.Name = "contextMenuItemToolStripMenuItem";
            this.contextMenuItemToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.contextMenuItemToolStripMenuItem.Text = "Context menu item";
            // 
            // uninstallHookButton
            // 
            this.uninstallHookButton.Location = new System.Drawing.Point(112, 248);
            this.uninstallHookButton.Name = "uninstallHookButton";
            this.uninstallHookButton.Size = new System.Drawing.Size(94, 23);
            this.uninstallHookButton.TabIndex = 0;
            this.uninstallHookButton.Text = "Uninstall hook";
            this.uninstallHookButton.UseVisualStyleBackColor = true;
            this.uninstallHookButton.Click += new System.EventHandler(this.OnUninstallHook);
            // 
            // messageLogTextBox
            // 
            this.messageLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLogTextBox.Location = new System.Drawing.Point(12, 12);
            this.messageLogTextBox.Multiline = true;
            this.messageLogTextBox.Name = "messageLogTextBox";
            this.messageLogTextBox.ReadOnly = true;
            this.messageLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageLogTextBox.Size = new System.Drawing.Size(421, 230);
            this.messageLogTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 273);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.installHookButton);
            this.Controls.Add(this.uninstallHookButton);
            this.Controls.Add(this.messageLogTextBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnUninstallHook);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button installHookButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemToolStripMenuItem;
        private System.Windows.Forms.Button uninstallHookButton;
        private System.Windows.Forms.TextBox messageLogTextBox;
    }
}

