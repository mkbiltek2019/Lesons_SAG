namespace ctlClockLib
{
    partial class ctlAlarmClock
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
            this.lblAlarm = new System.Windows.Forms.Label();
            this.btnAlarmOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlarm.Location = new System.Drawing.Point(22, 25);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(100, 24);
            this.lblAlarm.TabIndex = 1;
            this.lblAlarm.Text = "Wake up!!!";
            this.lblAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlarm.Visible = false;
            // 
            // btnAlarmOff
            // 
            this.btnAlarmOff.Location = new System.Drawing.Point(17, 86);
            this.btnAlarmOff.Name = "btnAlarmOff";
            this.btnAlarmOff.Size = new System.Drawing.Size(110, 23);
            this.btnAlarmOff.TabIndex = 2;
            this.btnAlarmOff.Text = "Turn off the alarm";
            this.btnAlarmOff.UseVisualStyleBackColor = true;
            this.btnAlarmOff.Click += new System.EventHandler(this.btnAlarmOff_Click);
            // 
            // ctlAlarmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnAlarmOff);
            this.Controls.Add(this.lblAlarm);
            this.Name = "ctlAlarmClock";
            this.Size = new System.Drawing.Size(147, 133);
            this.Controls.SetChildIndex(this.lblAlarm, 0);
            this.Controls.SetChildIndex(this.btnAlarmOff, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Button btnAlarmOff;

    }
}
