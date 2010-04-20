using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sekynds
{
    public partial class Form1 : Form
    {
        Timer vTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

            //определяем обработчик события для таймера
            vTimer.Tick += new EventHandler(ShowTimer);
        }

        private void ShowTimer(object vObject, EventArgs e)
        {
            //останавливаем таймер
            vTimer.Stop();

            button2.Enabled = false;

            MessageBox.Show("Таймер отработал!", "Таймер");
        }

        

        
        private void button1_Click(object sender, EventArgs e)
        {
            //проверяем введенное количество секунд для таймера
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Количество секунд должно быть больше 0!");
                return;
            }
            //разрешаем прервать таймер
            button2.Enabled = true;

            //интервал задается в милисекундах, поэтому секунды умножаем на 1000
            //и задаем интервал таймера
            vTimer.Interval = Decimal.ToInt32(numericUpDown1.Value) * 1000;

            //запуск таймера
            vTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //останавливаем таймер
            vTimer.Stop();

            MessageBox.Show("Таймер не успел отработать!", "Таймер");

            button2.Enabled = false;
        }
    }
}
