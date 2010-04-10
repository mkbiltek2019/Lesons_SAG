using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class StopWatch : Form
    {
        int m, s;

        public StopWatch()
        {

            InitializeComponent();

            timerStopWatch.Interval = 500;
            timerDateTimeNow.Interval = 1000;

            m = 0;
            s = 0;
            

            labelColon.Visible = true;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
           if(timerStopWatch.Enabled)
           {
               timerStopWatch.Enabled = false;
               buttonStart.Text = "Пуск";
               buttonReset.Enabled = true;
           }
           else
           {
               timerStopWatch.Enabled = true;
               buttonStart.Text = "Стоп";
               buttonReset.Enabled = false;
           }
           timerDateTimeNow.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            m = 0;
            s = 0;
            labelMinutes.Text = "00";
            labelSeconds.Text = "00";
        }

        private void timerStopWatch_Tick(object sender, EventArgs e)
        {
            if (labelColon.Visible)
            {
                if (s < 59)
                {
                    s++;
                    if (s < 10)
                        labelSeconds.Text = "0" + s.ToString();
                    else
                        labelSeconds.Text = s.ToString();
                }
                else
                {
                    if (m < 59)
                    {
                        m++;
                        if (m < 10)
                            labelMinutes.Text = "0" + m.ToString();
                        else
                            labelMinutes.Text = m.ToString();
                        s = 0;
                        labelSeconds.Text = "00";
                    }
                    else
                    {
                        m = 0;
                        labelMinutes.Text = "00";
                    }
                }
                labelColon.Visible = false;
            }
            else
                labelColon.Visible = true;
        }

        private void timerDateTimeNow_Tick(object sender, EventArgs e)
        {
            textBoxDateTimeNow.Text = DateTime.Now.ToString();
        }
    }
}
