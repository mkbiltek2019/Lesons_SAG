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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartTimer = new System.Windows.Forms.Button();
            this.GetTime = new System.Windows.Forms.Button();
            this.StopTimer = new System.Windows.Forms.Button();
            this.TimerValueList = new System.Windows.Forms.ListBox();
            this.ClearResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartTimer
            // 
            this.StartTimer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartTimer.Location = new System.Drawing.Point(24, 60);
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.Size = new System.Drawing.Size(75, 23);
            this.StartTimer.TabIndex = 1;
            this.StartTimer.Text = "Start timer";
            this.StartTimer.UseVisualStyleBackColor = true;
            this.StartTimer.Click += new System.EventHandler(this.StartTimer_Click);
            // 
            // GetTime
            // 
            this.GetTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GetTime.Location = new System.Drawing.Point(124, 60);
            this.GetTime.Name = "GetTime";
            this.GetTime.Size = new System.Drawing.Size(75, 23);
            this.GetTime.TabIndex = 2;
            this.GetTime.Text = "Get time";
            this.GetTime.UseVisualStyleBackColor = true;
            this.GetTime.Click += new System.EventHandler(this.GetTime_Click);
            // 
            // StopTimer
            // 
            this.StopTimer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopTimer.Location = new System.Drawing.Point(226, 60);
            this.StopTimer.Name = "StopTimer";
            this.StopTimer.Size = new System.Drawing.Size(75, 23);
            this.StopTimer.TabIndex = 3;
            this.StopTimer.Text = "Stop timer";
            this.StopTimer.UseVisualStyleBackColor = true;
            this.StopTimer.Click += new System.EventHandler(this.StopTimer_Click);
            // 
            // TimerValueList
            // 
            this.TimerValueList.BackColor = System.Drawing.SystemColors.Info;
            this.TimerValueList.ColumnWidth = 50;
            this.TimerValueList.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerValueList.ForeColor = System.Drawing.Color.Crimson;
            this.TimerValueList.FormattingEnabled = true;
            this.TimerValueList.ItemHeight = 19;
            this.TimerValueList.Location = new System.Drawing.Point(24, 107);
            this.TimerValueList.Name = "TimerValueList";
            this.TimerValueList.Size = new System.Drawing.Size(277, 156);
            this.TimerValueList.TabIndex = 4;
            // 
            // ClearResults
            // 
            this.ClearResults.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearResults.Location = new System.Drawing.Point(113, 271);
            this.ClearResults.Name = "ClearResults";
            this.ClearResults.Size = new System.Drawing.Size(104, 23);
            this.ClearResults.TabIndex = 5;
            this.ClearResults.Text = "Clear Results";
            this.ClearResults.UseVisualStyleBackColor = true;
            this.ClearResults.Click += new System.EventHandler(this.ClearResults_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(333, 303);
            this.Controls.Add(this.ClearResults);
            this.Controls.Add(this.TimerValueList);
            this.Controls.Add(this.StopTimer);
            this.Controls.Add(this.GetTime);
            this.Controls.Add(this.StartTimer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(341, 330);
            this.MinimumSize = new System.Drawing.Size(341, 330);
            this.Name = "MainForm";
            this.Text = "Simple timer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartTimer;
        private System.Windows.Forms.Button GetTime;
        private System.Windows.Forms.Button StopTimer;
        private System.Windows.Forms.ListBox TimerValueList;
        private System.Windows.Forms.Button ClearResults;
    }
}

