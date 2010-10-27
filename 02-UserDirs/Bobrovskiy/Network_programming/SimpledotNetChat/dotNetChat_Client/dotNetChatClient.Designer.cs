namespace dotNetChatClient
{
    partial class dotNetChatClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.smilePictureBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.privateChatButton = new System.Windows.Forms.Button();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.messageLogListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setConnetionParamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUserDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userImageListBox = new MessageFormatter.ImageListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smilePictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.smilePictureBox);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Location = new System.Drawing.Point(0, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // smilePictureBox
            // 
            this.smilePictureBox.Location = new System.Drawing.Point(6, 10);
            this.smilePictureBox.Name = "smilePictureBox";
            this.smilePictureBox.Size = new System.Drawing.Size(79, 78);
            this.smilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.smilePictureBox.TabIndex = 3;
            this.smilePictureBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(91, 43);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.disconnectButton);
            this.groupBox2.Controls.Add(this.connectButton);
            this.groupBox2.Controls.Add(this.privateChatButton);
            this.groupBox2.Controls.Add(this.sendMessageButton);
            this.groupBox2.Controls.Add(this.messageTextBox);
            this.groupBox2.Controls.Add(this.messageLogListBox);
            this.groupBox2.Location = new System.Drawing.Point(213, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 432);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(87, 404);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 13;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(6, 404);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 12;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // privateChatButton
            // 
            this.privateChatButton.Location = new System.Drawing.Point(218, 404);
            this.privateChatButton.Name = "privateChatButton";
            this.privateChatButton.Size = new System.Drawing.Size(75, 23);
            this.privateChatButton.TabIndex = 11;
            this.privateChatButton.Text = "PrivateChat";
            this.privateChatButton.UseVisualStyleBackColor = true;
            this.privateChatButton.Click += new System.EventHandler(this.privateChatButton_Click);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(345, 404);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(75, 23);
            this.sendMessageButton.TabIndex = 10;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(2, 379);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(419, 20);
            this.messageTextBox.TabIndex = 9;
            // 
            // messageLogListBox
            // 
            this.messageLogListBox.FormattingEnabled = true;
            this.messageLogListBox.Location = new System.Drawing.Point(3, 8);
            this.messageLogListBox.Name = "messageLogListBox";
            this.messageLogListBox.Size = new System.Drawing.Size(418, 368);
            this.messageLogListBox.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.userImageListBox);
            this.groupBox3.Location = new System.Drawing.Point(0, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 340);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 24);
            this.menuStrip1.TabIndex = 6;
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setConnetionParamToolStripMenuItem,
            this.setUserDataToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // setConnetionParamToolStripMenuItem
            // 
            this.setConnetionParamToolStripMenuItem.Name = "setConnetionParamToolStripMenuItem";
            this.setConnetionParamToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.setConnetionParamToolStripMenuItem.Text = "&Set connetion param";
            this.setConnetionParamToolStripMenuItem.Click += new System.EventHandler(this.setConnetionParamToolStripMenuItem_Click);
            // 
            // setUserDataToolStripMenuItem
            // 
            this.setUserDataToolStripMenuItem.Name = "setUserDataToolStripMenuItem";
            this.setUserDataToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.setUserDataToolStripMenuItem.Text = "&Set user data";
            this.setUserDataToolStripMenuItem.Click += new System.EventHandler(this.setUserDataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // userImageListBox
            // 
            this.userImageListBox.Location = new System.Drawing.Point(-1, 8);
            this.userImageListBox.Name = "userImageListBox";
            this.userImageListBox.Size = new System.Drawing.Size(208, 330);
            this.userImageListBox.TabIndex = 5;
            // 
            // dotNetChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 455);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(645, 482);
            this.MinimumSize = new System.Drawing.Size(645, 482);
            this.Name = "dotNetChatClient";
            this.Text = "dotnetChat_Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smilePictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
      
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nameLabel;       
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button privateChatButton;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.ListBox messageLogListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button connectButton;        
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.PictureBox smilePictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setConnetionParamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUserDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private MessageFormatter.ImageListBox userImageListBox;
        
      
    }
}

