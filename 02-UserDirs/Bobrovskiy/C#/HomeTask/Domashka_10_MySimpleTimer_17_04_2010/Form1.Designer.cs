namespace MySimpleTimer_10_04_2010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartTimer = new System.Windows.Forms.Button();
            this.GetTime = new System.Windows.Forms.Button();
            this.StopTimer = new System.Windows.Forms.Button();
            this.TimerValueList = new System.Windows.Forms.ListBox();
            this.ClearResults = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.TimerValueLabel = new System.Windows.Forms.Label();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.CurrentTimerStateLabel = new System.Windows.Forms.Label();
            this.TitleBlinkingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StartTimer
            // 
            this.StartTimer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartTimer.Location = new System.Drawing.Point(3, 66);
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.Size = new System.Drawing.Size(75, 23);
            this.StartTimer.TabIndex = 1;
            this.StartTimer.Text = "Start timer";
            this.StartTimer.UseVisualStyleBackColor = true;
            this.StartTimer.Click += new System.EventHandler(this.StartTimerClick);
            // 
            // GetTime
            // 
            this.GetTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetTime.Location = new System.Drawing.Point(103, 66);
            this.GetTime.Name = "GetTime";
            this.GetTime.Size = new System.Drawing.Size(75, 23);
            this.GetTime.TabIndex = 2;
            this.GetTime.Text = "Get time";
            this.GetTime.UseVisualStyleBackColor = true;
            this.GetTime.Click += new System.EventHandler(this.GetTimeClick);
            // 
            // StopTimer
            // 
            this.StopTimer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopTimer.Location = new System.Drawing.Point(205, 66);
            this.StopTimer.Name = "StopTimer";
            this.StopTimer.Size = new System.Drawing.Size(75, 23);
            this.StopTimer.TabIndex = 3;
            this.StopTimer.Text = "Stop timer";
            this.StopTimer.UseVisualStyleBackColor = true;
            this.StopTimer.Click += new System.EventHandler(this.StopTimerClick);
            // 
            // TimerValueList
            // 
            this.TimerValueList.BackColor = System.Drawing.SystemColors.Info;
            this.TimerValueList.ColumnWidth = 50;
            this.TimerValueList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerValueList.ForeColor = System.Drawing.Color.Crimson;
            this.TimerValueList.FormattingEnabled = true;
            this.TimerValueList.ItemHeight = 19;
            this.TimerValueList.Location = new System.Drawing.Point(3, 128);
            this.TimerValueList.Name = "TimerValueList";
            this.TimerValueList.Size = new System.Drawing.Size(277, 137);
            this.TimerValueList.TabIndex = 4;
            // 
            // ClearResults
            // 
            this.ClearResults.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearResults.Location = new System.Drawing.Point(88, 268);
            this.ClearResults.Name = "ClearResults";
            this.ClearResults.Size = new System.Drawing.Size(104, 23);
            this.ClearResults.TabIndex = 5;
            this.ClearResults.Text = "Clear Results";
            this.ClearResults.UseVisualStyleBackColor = true;
            this.ClearResults.Click += new System.EventHandler(this.ClearResultsClick);
            // 
            // PauseButton
            // 
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseButton.Location = new System.Drawing.Point(205, 97);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 23);
            this.PauseButton.TabIndex = 6;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // TimerValueLabel
            // 
            this.TimerValueLabel.AutoSize = true;
            this.TimerValueLabel.Font = new System.Drawing.Font("Arial", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerValueLabel.Location = new System.Drawing.Point(-1, 6);
            this.TimerValueLabel.Name = "TimerValueLabel";
            this.TimerValueLabel.Size = new System.Drawing.Size(287, 56);
            this.TimerValueLabel.TabIndex = 7;
            this.TimerValueLabel.Text = "00:00:00.00";
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // CurrentTimerStateLabel
            // 
            this.CurrentTimerStateLabel.AutoSize = true;
            this.CurrentTimerStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentTimerStateLabel.Location = new System.Drawing.Point(0, 102);
            this.CurrentTimerStateLabel.Name = "CurrentTimerStateLabel";
            this.CurrentTimerStateLabel.Size = new System.Drawing.Size(121, 13);
            this.CurrentTimerStateLabel.TabIndex = 8;
            this.CurrentTimerStateLabel.Text = "Current timerState : ";
            // 
            // TitleBlinkingTimer
            // 
            this.TitleBlinkingTimer.Tick += new System.EventHandler(this.TitleBlinkingTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(284, 293);
            this.Controls.Add(this.CurrentTimerStateLabel);
            this.Controls.Add(this.TimerValueLabel);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.ClearResults);
            this.Controls.Add(this.TimerValueList);
            this.Controls.Add(this.StopTimer);
            this.Controls.Add(this.GetTime);
            this.Controls.Add(this.StartTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(292, 320);
            this.MinimumSize = new System.Drawing.Size(292, 320);
            this.Name = "MainForm";
            this.Text = "Simple timer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartTimer;
        private System.Windows.Forms.Button GetTime;
        private System.Windows.Forms.Button StopTimer;
        private System.Windows.Forms.ListBox TimerValueList;
        private System.Windows.Forms.Button ClearResults;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label TimerValueLabel;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Label CurrentTimerStateLabel;
        private System.Windows.Forms.Timer TitleBlinkingTimer;
    }
}

