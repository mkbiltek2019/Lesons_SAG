namespace Test
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
            this.dtpTest = new System.Windows.Forms.DateTimePicker();
            this.lblTest = new System.Windows.Forms.Label();
            this.ctlAlarmClock1 = new ctlClockLib.ctlAlarmClock();
            this.SuspendLayout();
            // 
            // dtpTest
            // 
            this.dtpTest.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTest.Location = new System.Drawing.Point(84, 148);
            this.dtpTest.Name = "dtpTest";
            this.dtpTest.Size = new System.Drawing.Size(102, 20);
            this.dtpTest.TabIndex = 0;
            this.dtpTest.ValueChanged += new System.EventHandler(this.dtpTest_ValueChanged);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(81, 185);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(10, 13);
            this.lblTest.TabIndex = 1;
            this.lblTest.Text = " ";
            // 
            // ctlAlarmClock1
            // 
            this.ctlAlarmClock1.AlarmSet = false;
            this.ctlAlarmClock1.AlarmTime = new System.DateTime(((long)(0)));
            this.ctlAlarmClock1.ClockBackColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.ClockForeColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.Location = new System.Drawing.Point(62, 12);
            this.ctlAlarmClock1.Name = "ctlAlarmClock1";
            this.ctlAlarmClock1.Size = new System.Drawing.Size(146, 130);
            this.ctlAlarmClock1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.ctlAlarmClock1);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.dtpTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTest;
        private System.Windows.Forms.Label lblTest;
        private ctlClockLib.ctlAlarmClock ctlAlarmClock1;
    }
}

