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


        private TimeSpan _totalTimeLeft;
        private TimeSpan _totalTimerRight;

        public FormCountdown()
        {
            InitializeComponent();
            numericUpDownMinutes.Maximum = 59;
            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.TabStop = false;

            numericUpDownSeconds.Maximum = 59;
            numericUpDownSeconds.Minimum = 0;
            numericUpDownSeconds.TabStop = false;
            
        }

        private void numericUpDownMinutes_ValueChanged(object sender, EventArgs e)
        {
             if ((numericUpDownMinutes.Value == 0) && (numericUpDownSeconds.Value == 0))
                 buttonStart.Enabled = false;
             else
                 buttonStart.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                int minutesLeft = (int)numericUpDownMinutes.Value;
                int secondsLeft = (int)numericUpDownSeconds.Value;

                _totalTimeLeft = new TimeSpan(0, minutesLeft, secondsLeft);
                _totalTimerRight = new TimeSpan(0, 0, 0);
                
                buttonStart.Text = "Стоп";
                timer.Enabled = true;
                int d = (int) DateTime.Now.DayOfWeek;
                DayOfWeek k = (DayOfWeek)DateTime.Now.DayOfWeek;
                DayOfTheWeek dayOfTheWeek = new DayOfTheWeek();
               
                label1.Text = dayOfTheWeek.Day(k);
                label4.Text = d.ToString();
                //label1.Text = k.ToString()
            }
            else
            {
                timer.Enabled = false;
                buttonStart.Text = "Пуск";
            }
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = string.Format("{0:00}:{1:00}.{2:00}",
                                 _totalTimeLeft.Minutes,
                                 _totalTimeLeft.Seconds,
                                 _totalTimeLeft.Milliseconds / 10);
            Text = string.Format("{0:00}:{1:00}.{2:00}",
                                 _totalTimerRight.Minutes,
                                 _totalTimerRight.Seconds,
                                 _totalTimerRight.Milliseconds / 10);
            
           

            _totalTimeLeft -= TimeSpan.FromMilliseconds(timer.Interval);
            _totalTimerRight += TimeSpan.FromMilliseconds(timer.Interval);
            if (_totalTimeLeft.Seconds <= 5 && _totalTimeLeft.Seconds >= 1 )
            {
                if (_totalTimeLeft.Seconds %1 == 0 && _totalTimeLeft.Milliseconds == 0)
                {
                    Microsoft.VisualBasic.Interaction.Beep();
                }
             }
            if (_totalTimeLeft < TimeSpan.Zero)
            {
                timer.Enabled = false;

                MessageBox.Show(
                   "Заданный интервал времени истек.", "Таймер.",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                buttonStart.Text = "Пуск";

                numericUpDownMinutes.Value = 0;
                numericUpDownSeconds.Value = 0;
            }
            
        }
    }
}
