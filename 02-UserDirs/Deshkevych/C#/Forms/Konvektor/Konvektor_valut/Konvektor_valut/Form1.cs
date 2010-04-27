using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Konvektor_valut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //нажатие клавиши в поле Цена
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&& !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;
            }
        }
        
        
        //Нажатие на кнопке Пересчет
        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&& !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",")&&
                    (textBox2.Text.IndexOf(",")== -1)))
                    e.Handled = true;
            }
        }

        //Щелчек на кнопке пересчет
        private void button1_Click(object sender, EventArgs e)
        {
            double k;
            double usd;
            double rub;

            label4.Text = " ";
            

            try
            {
                
                usd = System.Convert.ToDouble(textBox1.Text);
                k = System.Convert.ToDouble(textBox2.Text);

                
                rub = usd*k;

                
                label4.Text = usd.ToString("N") + " USD = " + rub.ToString("C");
                
            }
            catch
            {
                if ((textBox1.Text == "") | (textBox2.Text==""))
                {
                    MessageBox.Show("Ошибка исходных данных.\n" + 
                        "Необходимо ввести данные в оба поля.",
                        "Конвектор", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ошибка исходных данных.\n" + 
                        "Неверный формат данных в одном из полей.",
                        "Конвертер", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Щелчек на кнопке Завершить
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
