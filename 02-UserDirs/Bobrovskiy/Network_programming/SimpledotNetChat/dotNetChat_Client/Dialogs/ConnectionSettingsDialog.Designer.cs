namespace dotNetChatClient.Dialogs
{
    partial class ConnectionSettingsDialog
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
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverAddressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.closebutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.portTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serverAddressTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(65, 61);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.ReadOnly = true;
            this.portTextBox.Size = new System.Drawing.Size(152, 20);
            this.portTextBox.TabIndex = 5;
            this.portTextBox.Text = "8080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // serverAddressTextBox
            // 
            this.serverAddressTextBox.Location = new System.Drawing.Point(66, 25);
            this.serverAddressTextBox.Name = "serverAddressTextBox";
            this.serverAddressTextBox.Size = new System.Drawing.Size(151, 20);
            this.serverAddressTextBox.TabIndex = 3;
            this.serverAddressTextBox.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server IP:";
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(153, 109);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(78, 23);
            this.closebutton.TabIndex = 3;
            this.closebutton.Text = "&Close";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // ConnectionSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 135);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(244, 162);
            this.MinimumSize = new System.Drawing.Size(244, 162);
            this.Name = "ConnectionSettingsDialog";
            this.Text = "ConnectionSettingsDialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverAddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closebutton;

    }
}