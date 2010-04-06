using System;
using System.Windows.Forms;

namespace FourthSample
{
    public partial class Form1 : Form
    {
        // создаём таймер
        private static Timer vTimer = new Timer();
        // Обработчик тика для таймера
        private void ShowTime(object vObj, EventArgs e)
        {
            // преобразование к строке
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        public Form1()
        {
            InitializeComponent();
            // преобразование к строке
            labelTime.Text = DateTime.Now.ToLongTimeString();
            // закрепление обработчика
            vTimer.Tick += new EventHandler(ShowTime);
            // установка интервала времени
            vTimer.Interval = 500;
            // стартуем таймер
            vTimer.Start();
        }
    }
}
