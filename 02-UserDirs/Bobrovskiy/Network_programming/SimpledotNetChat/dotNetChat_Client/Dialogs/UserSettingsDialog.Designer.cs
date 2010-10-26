namespace dotNetChatClient.Dialogs
{
    partial class UserSettingsDialog
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selectedPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectImageButton);
            this.groupBox2.Controls.Add(this.nameTextBox);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(0, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 107);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(225, 64);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(106, 23);
            this.selectImageButton.TabIndex = 9;
            this.selectImageButton.Text = "&Select user image";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(225, 29);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(180, 20);
            this.nameTextBox.TabIndex = 8;
            this.nameTextBox.Text = "Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selectedPictureBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 93);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // selectedPictureBox
            // 
            this.selectedPictureBox.Location = new System.Drawing.Point(6, 9);
            this.selectedPictureBox.Name = "selectedPictureBox";
            this.selectedPictureBox.Size = new System.Drawing.Size(79, 78);
            this.selectedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedPictureBox.TabIndex = 4;
            this.selectedPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(341, 115);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(71, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // UserSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 150);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(424, 177);
            this.MinimumSize = new System.Drawing.Size(424, 177);
            this.Name = "UserSettingsDialog";
            this.Text = "UserSettingsDialog";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox selectedPictureBox;

    }
}