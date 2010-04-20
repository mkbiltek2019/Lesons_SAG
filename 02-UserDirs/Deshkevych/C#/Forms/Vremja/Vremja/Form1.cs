using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vremja
{
    public partial class Form1 : Form
    {
        //создаем таймер
        private static Timer vTimer = new Timer();
        //Обработчик тика для таймера
        private void ShowTime(object vObj, EventArgs e)
        {
            //преобразование к строке
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();

        }
        public Form1()
        {
            InitializeComponent();
            //преобразование к строке
            labelTime.Text = DateTime.Now.ToLongTimeString();
            //закрепление обработчика
            vTimer.Tick += new EventHandler (ShowTime);
            //установка интервала времени
            vTimer.Interval = 500;
            //стартуем таймер
            vTimer.Start();
        }
    }
}
