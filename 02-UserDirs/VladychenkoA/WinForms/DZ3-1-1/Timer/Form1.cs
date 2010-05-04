using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        private DateTime timeStartTimer;
        private DateTime timeStopTimer;

        public Form1()
        {
            InitializeComponent();

            numericUpDownMinutes.Maximum = 59;
            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.TabStop = false;

            numericUpDownSeconds.Maximum = 59;
            numericUpDownSeconds.Minimum = 0;
            numericUpDownSeconds.TabStop = false;

            buttonStart.Enabled = false;
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
                timeStartTimer = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, DateTime.Now.Day);
                timeStopTimer = timeStartTimer.AddMinutes((double) numericUpDownMinutes.Value);
                timeStopTimer = timeStopTimer.AddSeconds((double) numericUpDownSeconds.Value);

                groupBoxInput.Enabled = false;
                buttonStart.Text = "Стоп";

                if (timeStopTimer.Minute <= 9)
                    labelTimer.Text = "0" + timeStopTimer.Minute.ToString() + ":";
                else
                    labelTimer.Text = timeStopTimer.Minute.ToString() + ":";

                if (timeStopTimer.Second <= 9)
                    labelTimer.Text += "0" + timeStopTimer.Second.ToString();
                else
                    labelTimer.Text += timeStopTimer.Second.ToString();

                timer.Interval = 1000;
                timer.Enabled = true;
                Text = "Таймер работает";
               

                groupBoxInput.Enabled = false;
            }
            else
            {
                timer.Enabled = false;
                buttonStart.Text = "Пуск";
                groupBoxInput.Enabled = true;
                numericUpDownMinutes.Value = timeStopTimer.Minute;
                numericUpDownSeconds.Value = timeStopTimer.Second;
                Text = "Таймер остановлен";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeStopTimer = timeStopTimer.AddSeconds(-1);

            if (timeStopTimer.Minute <= 9)
                labelTimer.Text = "0" + timeStopTimer.Minute.ToString() + ":";
            else
                labelTimer.Text += timeStopTimer.Minute.ToString() + ":";

            if (timeStopTimer.Second <= 9)
                labelTimer.Text += "0" + timeStopTimer.Second.ToString();
            else
                labelTimer.Text += timeStopTimer.Second.ToString();

            if (timeStopTimer.Second <= 5 && timeStopTimer.Second > 0)
            {
                Microsoft.VisualBasic.Interaction.Beep();
            }

            if(Equals(timeStartTimer, timeStopTimer))
            {
                timer.Enabled = false;
                MessageBox.Show(
                    "Заданный интервал времени истек.", "Таймер.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Text = "Отсчет окончен";
                buttonStart.Text = "Пуск";
                groupBoxInput.Enabled = true;
                numericUpDownMinutes.Value = 0;
                numericUpDownSeconds.Value = 0;
                groupBoxInput.Enabled = true;
            }

        }
    }
}
