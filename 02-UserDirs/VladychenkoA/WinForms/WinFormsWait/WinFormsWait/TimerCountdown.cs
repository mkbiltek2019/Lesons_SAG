using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsWait
{
    class CountdownTimer:FormCountdown
    {
         private DateTime _timeStartTimer;
        private DateTime _timeStopTimer;

        public CountdownTimer()
        {
             numericUpDownMinutes.Maximum = 59;
            numericUpDownMinutes.Minimum = 0;
            numericUpDownMinutes.TabStop = false;

            numericUpDownSeconds.Maximum = 59;
            numericUpDownSeconds.Minimum = 0;
            numericUpDownSeconds.TabStop = false;

        }
        public void Acces()
        {
            if ((numericUpDownMinutes.Value == 0) && (numericUpDownSeconds.Value == 0))
                buttonStart.Enabled = false;
            else
                buttonStart.Enabled = true;
        }

        public void Start()
        {
            if (!timer.Enabled)
            {
                _timeStartTimer = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, DateTime.Now.Day);
                _timeStopTimer = _timeStartTimer.AddMinutes((double)numericUpDownMinutes.Value);
                _timeStopTimer = _timeStopTimer.AddSeconds((double)numericUpDownSeconds.Value);

               
                buttonStart.Text = "Стоп";

                if (_timeStopTimer.Minute <= 9)
                    labelTimer.Text = "0" + _timeStopTimer.Minute.ToString() + ":";
                else
                    labelTimer.Text = _timeStopTimer.Minute.ToString() + ":";

                if (_timeStopTimer.Second <= 9)
                    labelTimer.Text += "0" + _timeStopTimer.Second.ToString();
                else
                    labelTimer.Text += _timeStopTimer.Second.ToString();

                timer.Interval = 1000;
                timer.Enabled = true;
            }
            else
            {
                timer.Enabled = false;
                buttonStart.Text = "Пуск";
                numericUpDownMinutes.Value = _timeStopTimer.Minute;
                numericUpDownSeconds.Value = _timeStopTimer.Second;
            }
        }
        public void Stop()
        {
             _timeStopTimer = _timeStopTimer.AddSeconds((double)-1);

            if (_timeStopTimer.Minute <= 9)
                labelTimer.Text = "0" + _timeStopTimer.Minute.ToString() + ":";
            else
                labelTimer.Text += _timeStopTimer.Minute.ToString() + ":";

            if (_timeStopTimer.Second <= 9)
                labelTimer.Text += "0" + _timeStopTimer.Second.ToString();
            else
                labelTimer.Text += _timeStopTimer.Second.ToString();

            if (Equals(_timeStartTimer, _timeStopTimer))
            {
                timer.Enabled = false;
                System.Windows.Forms.MessageBox.Show(
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
