using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsWait
{
    public partial class FormCountdown : Form
    {

       
       

        public FormCountdown()
        {
            InitializeComponent();
           
            
        }

        private void numericUpDownMinutes_ValueChanged(object sender, EventArgs e)
        {
            CountdownTimer countdownTimer = new CountdownTimer();
            countdownTimer.Acces();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CountdownTimer countdownTimer = new CountdownTimer();
            countdownTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CountdownTimer countdownTimer = new CountdownTimer();
            countdownTimer.Stop();
        }
    }
}
