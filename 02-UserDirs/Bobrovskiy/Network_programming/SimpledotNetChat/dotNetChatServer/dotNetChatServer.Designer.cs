namespace dotNetChatServer
{
    partial class dotNetChatServer
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
            this.connectedUsersListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.killConnectionButton = new System.Windows.Forms.Button();
            this.stopServerButton = new System.Windows.Forms.Button();
            this.startServerButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.userImageListBox = new MessageFormatter.ImageListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectedUsersListBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Comunication";
            // 
            // connectedUsersListBox
            // 
            this.connectedUsersListBox.FormattingEnabled = true;
            this.connectedUsersListBox.Location = new System.Drawing.Point(6, 19);
            this.connectedUsersListBox.Name = "connectedUsersListBox";
            this.connectedUsersListBox.Size = new System.Drawing.Size(188, 290);
            this.connectedUsersListBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.killConnectionButton);
            this.groupBox2.Controls.Add(this.stopServerButton);
            this.groupBox2.Controls.Add(this.startServerButton);
            this.groupBox2.Location = new System.Drawing.Point(206, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 147);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // killConnectionButton
            // 
            this.killConnectionButton.Location = new System.Drawing.Point(6, 60);
            this.killConnectionButton.Name = "killConnectionButton";
            this.killConnectionButton.Size = new System.Drawing.Size(84, 23);
            this.killConnectionButton.TabIndex = 2;
            this.killConnectionButton.Text = "&kill Connection";
            this.killConnectionButton.UseVisualStyleBackColor = true;
            this.killConnectionButton.Visible = false;
            this.killConnectionButton.Click += new System.EventHandler(this.killConnectionButton_Click);
            // 
            // stopServerButton
            // 
            this.stopServerButton.Location = new System.Drawing.Point(6, 100);
            this.stopServerButton.Name = "stopServerButton";
            this.stopServerButton.Size = new System.Drawing.Size(84, 23);
            this.stopServerButton.TabIndex = 1;
            this.stopServerButton.Text = "&stopServer";
            this.stopServerButton.UseVisualStyleBackColor = true;
            this.stopServerButton.Click += new System.EventHandler(this.stopServerButton_Click);
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(6, 19);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(84, 23);
            this.startServerButton.TabIndex = 0;
            this.startServerButton.Text = "&start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(228, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "&Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.userImageListBox);
            this.groupBox3.Location = new System.Drawing.Point(309, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 317);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ConnectedUsers";
            // 
            // userImageListBox
            // 
            this.userImageListBox.Location = new System.Drawing.Point(3, 14);
            this.userImageListBox.Name = "userImageListBox";
            this.userImageListBox.Size = new System.Drawing.Size(206, 297);
            this.userImageListBox.TabIndex = 4;
            // 
            // dotNetChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 321);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(532, 348);
            this.MinimumSize = new System.Drawing.Size(532, 348);
            this.Name = "dotNetChatServer";
            this.Text = "dotNetChatServer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button killConnectionButton;
        private System.Windows.Forms.Button stopServerButton;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox connectedUsersListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private MessageFormatter.ImageListBox userImageListBox;
    }
}

