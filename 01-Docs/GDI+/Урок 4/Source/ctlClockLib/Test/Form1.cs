using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dtpTest_ValueChanged(object sender, System.EventArgs e)
        {
            ctlAlarmClock1.AlarmTime = dtpTest.Value;
            ctlAlarmClock1.AlarmSet = true;
            lblTest.Text = "Alarm Time is " +
                ctlAlarmClock1.AlarmTime.ToShortTimeString();
        }
    }
}
