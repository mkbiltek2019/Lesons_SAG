namespace BackgroundWorkerDemo
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
            this.startSortingButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.currentSortingStateLabel = new System.Windows.Forms.Label();
            this.ArrayListBox = new System.Windows.Forms.ListBox();
            this.ShowResultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startSortingButton
            // 
            this.startSortingButton.Location = new System.Drawing.Point(12, 12);
            this.startSortingButton.Name = "startSortingButton";
            this.startSortingButton.Size = new System.Drawing.Size(75, 23);
            this.startSortingButton.TabIndex = 0;
            this.startSortingButton.Text = "Start sorting";
            this.startSortingButton.UseVisualStyleBackColor = true;
            this.startSortingButton.Click += new System.EventHandler(this.startSortingButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 238);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(268, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(9, 222);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(68, 13);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "Progress: 0%";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // currentSortingStateLabel
            // 
            this.currentSortingStateLabel.AutoSize = true;
            this.currentSortingStateLabel.Location = new System.Drawing.Point(9, 209);
            this.currentSortingStateLabel.Name = "currentSortingStateLabel";
            this.currentSortingStateLabel.Size = new System.Drawing.Size(108, 13);
            this.currentSortingStateLabel.TabIndex = 4;
            this.currentSortingStateLabel.Text = "Current Sorting State:";
            // 
            // ArrayListBox
            // 
            this.ArrayListBox.FormattingEnabled = true;
            this.ArrayListBox.HorizontalScrollbar = true;
            this.ArrayListBox.Location = new System.Drawing.Point(140, 12);
            this.ArrayListBox.Name = "ArrayListBox";
            this.ArrayListBox.Size = new System.Drawing.Size(140, 186);
            this.ArrayListBox.TabIndex = 5;
            // 
            // ShowResultButton
            // 
            this.ShowResultButton.Location = new System.Drawing.Point(12, 114);
            this.ShowResultButton.Name = "ShowResultButton";
            this.ShowResultButton.Size = new System.Drawing.Size(75, 23);
            this.ShowResultButton.TabIndex = 6;
            this.ShowResultButton.Text = "ShowResult";
            this.ShowResultButton.UseVisualStyleBackColor = true;
            this.ShowResultButton.Click += new System.EventHandler(this.ShowResultButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.ShowResultButton);
            this.Controls.Add(this.ArrayListBox);
            this.Controls.Add(this.currentSortingStateLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startSortingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startSortingButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label currentSortingStateLabel;
        private System.Windows.Forms.ListBox ArrayListBox;
        private System.Windows.Forms.Button ShowResultButton;
    }
}

