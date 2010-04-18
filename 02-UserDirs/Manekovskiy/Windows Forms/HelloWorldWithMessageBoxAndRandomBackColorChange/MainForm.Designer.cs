namespace HelloWorldWithMessageBoxAndRandomBackColorChange
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
            this.showMessageBoxButton = new System.Windows.Forms.Button();
            this.captionLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.changeBackColorOfEveryControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showMessageBoxButton
            // 
            this.showMessageBoxButton.Location = new System.Drawing.Point(12, 215);
            this.showMessageBoxButton.Name = "showMessageBoxButton";
            this.showMessageBoxButton.Size = new System.Drawing.Size(108, 35);
            this.showMessageBoxButton.TabIndex = 0;
            this.showMessageBoxButton.Text = "Show MessageBox";
            this.showMessageBoxButton.UseVisualStyleBackColor = true;
            this.showMessageBoxButton.Click += new System.EventHandler(this.ShowMessageBoxButton_Click);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Location = new System.Drawing.Point(9, 15);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(43, 13);
            this.captionLabel.TabIndex = 1;
            this.captionLabel.Text = "Caption";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(9, 41);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(28, 13);
            this.textLabel.TabIndex = 2;
            this.textLabel.Text = "Text";
            // 
            // captionTextBox
            // 
            this.captionTextBox.Location = new System.Drawing.Point(58, 12);
            this.captionTextBox.Name = "captionTextBox";
            this.captionTextBox.Size = new System.Drawing.Size(214, 20);
            this.captionTextBox.TabIndex = 3;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(58, 41);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(214, 20);
            this.textBox.TabIndex = 4;
            // 
            // changeBackColorOfEveryControlButton
            // 
            this.changeBackColorOfEveryControlButton.Location = new System.Drawing.Point(126, 215);
            this.changeBackColorOfEveryControlButton.Name = "changeBackColorOfEveryControlButton";
            this.changeBackColorOfEveryControlButton.Size = new System.Drawing.Size(146, 35);
            this.changeBackColorOfEveryControlButton.TabIndex = 5;
            this.changeBackColorOfEveryControlButton.Text = "Change BackColor of every control on form";
            this.changeBackColorOfEveryControlButton.UseVisualStyleBackColor = true;
            this.changeBackColorOfEveryControlButton.Click += new System.EventHandler(this.ChangeBackColorOfEveryControlButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.changeBackColorOfEveryControlButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.captionTextBox);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.captionLabel);
            this.Controls.Add(this.showMessageBoxButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showMessageBoxButton;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.TextBox captionTextBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button changeBackColorOfEveryControlButton;
    }
}

