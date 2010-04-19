using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CountdownTimer
{
    public partial class MyForm : Form
    {
        private CountdownTimer countdownTimer;
        public MyForm()
        {
            InitializeComponent();
            Text = "Stop";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int minutes = (int)numericUpDown1.Value;
            int secundes = (int)numericUpDown2.Value;
            countdownTimer = new CountdownTimer(new TimeSpan(0,0, minutes, secundes, 0));
            countdownTimer.Start(timer1);
            Text = "Start";
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            countdownTimer.Stop(timer1);
            Text = "Stop";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdownTimer.UdateTime(timer1, totalTime);
            if (Text == "Start")
            {
                Text = "";
            }
            else
            {
                Text = "Start";
            }
        }

    }
}
