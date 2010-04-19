// не стоит усложнять приложение наследованием, лучше сделать независимый класс у которого будет одно поле Timer _timer и два метода - Start(), Stop() + конструктор где _timer будет инициализироваться, в частности будет привязка к обработчику события Tick.
// в качестве значений для сохранения промежутка времени лучше использовать класс TimeSpan, DateTime предназначен для работы с датой, т.е. с конкретным календарем и конкретными часовыми поясами, а TimeSpan - просто кусок времени в общепринятых терминах(год, месяц, день...)
// ну и при использовании TimeSpan проще форматировать вывод времени, пример - приложение которое мы на занятии делали.
// чтобы отловить на форме факт завершения времени нужно использовать событие на которое класс формы будет подписан, там же и будет выводиться сообщение MessageBox
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsWait
{
    class CountdownTimer 
        //: FormCountdown
    {
        private Timer _timer = new Timer();
        public CountdownTimer()
        {
            _timer = _timer;
        }
        public void Start(Timer timer)
        {
            Label label;
            timer.Start();
        }
        public void Stop(Timer timer)
        {
            timer.Stop();
        }
        // private DateTime _timeStartTimer;
        //private DateTime _timeStopTimer;

        //public CountdownTimer()
        //{
        //     numericUpDownMinutes.Maximum = 59;
        //    numericUpDownMinutes.Minimum = 0;
        //    numericUpDownMinutes.TabStop = false;

        //    numericUpDownSeconds.Maximum = 59;
        //    numericUpDownSeconds.Minimum = 0;
        //    numericUpDownSeconds.TabStop = false;

        //}
        //public void Acces()
        //{
        //    if ((numericUpDownMinutes.Value == 0) && (numericUpDownSeconds.Value == 0))
        //        buttonStart.Enabled = false;
        //    else
        //        buttonStart.Enabled = true;
        //}

        //public void Start()
        //{
        //    if (!timer.Enabled)
        //    {
        //        _timeStartTimer = new DateTime(DateTime.Now.Year,
        //            DateTime.Now.Month, DateTime.Now.Day);
        //        _timeStopTimer = _timeStartTimer.AddMinutes((double)numericUpDownMinutes.Value);
        //        _timeStopTimer = _timeStopTimer.AddSeconds((double)numericUpDownSeconds.Value);

               
        ////        buttonStart.Text = "Стоп";

        //        if (_timeStopTimer.Minute <= 9)
        //            labelTimer.Text = "0" + _timeStopTimer.Minute.ToString() + ":";
        //        else
        //            labelTimer.Text = _timeStopTimer.Minute.ToString() + ":";

        //        if (_timeStopTimer.Second <= 9)
        //            labelTimer.Text += "0" + _timeStopTimer.Second.ToString();
        //        else
        //            labelTimer.Text += _timeStopTimer.Second.ToString();

        //        timer.Interval = 1000;
        //        timer.Enabled = true;
        //    }
        //    else
        //    {
        //        timer.Enabled = false;
        //        buttonStart.Text = "Пуск";
        //        numericUpDownMinutes.Value = _timeStopTimer.Minute;
        //        numericUpDownSeconds.Value = _timeStopTimer.Second;
        //    }
        //}
        //public void Stop()
        //{
        //     _timeStopTimer = _timeStopTimer.AddSeconds((double)-1);

        //    if (_timeStopTimer.Minute <= 9)
        //        labelTimer.Text = "0" + _timeStopTimer.Minute.ToString() + ":";
        //    else
        //        labelTimer.Text += _timeStopTimer.Minute.ToString() + ":";

        //    if (_timeStopTimer.Second <= 9)
        //        labelTimer.Text += "0" + _timeStopTimer.Second.ToString();
        //    else
        //        labelTimer.Text += _timeStopTimer.Second.ToString();

        //    if (Equals(_timeStartTimer, _timeStopTimer))
        //    {
        //        timer.Enabled = false;
        //        System.Windows.Forms.MessageBox.Show(
        //            "Заданный интервал времени истек.", "Таймер.",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);

        //        buttonStart.Text = "Пуск";

        //        numericUpDownMinutes.Value = 0;
        //        numericUpDownSeconds.Value = 0;
        //    }
        //}

    }
}
