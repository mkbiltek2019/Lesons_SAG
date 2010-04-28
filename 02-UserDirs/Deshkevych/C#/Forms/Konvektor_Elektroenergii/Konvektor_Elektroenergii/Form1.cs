using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Konvektor_Elektroenergii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&
                !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",") &&
                    (textBox1.Text.IndexOf(",") == -1)))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar.Equals((char)13))
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&
                !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",") &&
                    (textBox2.Text.IndexOf(",") == -1)))
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar.Equals((char)13))
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&
                !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",")&&
                    (textBox3.Text.IndexOf(",") == -1)))
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar.Equals((char)13))
            {
                button1.Focus();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((textBox1.Text.Length > 0)&&
                (textBox2.Text.Length > 0)&&
                (textBox3.Text.Length > 0))
            {
                button1.Enabled = true;
            }
            else button1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float curr; //текущее показание счетчика
            float prev; //предыдущее показание счетчика
            float traf; //цена за кВт
            float price; //сумма к оплате

            label5.Text = "";

            try
            {
                prev = Convert.ToSingle(textBox1.Text);
                curr = Convert.ToSingle(textBox2.Text);
                traf = Convert.ToSingle(textBox3.Text);

                if (curr >= prev)
                {
                    price = (curr - prev)*traf;

                    label5.Text = "Сумма к оплате : " + price.ToString("C");
                }
                else
                {
                    MessageBox.Show("Ошибка исходных данных.\n"
                        + "Текущее значение показания счетчика \n" 
                        + "меньше предыдущего.", "Электроэнергия",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch(Exception exc)
            {
                MessageBox.Show("Ошибка исходных данных.\n" + "Исходные данные имеют неверный формат.\n"
                                + exc.Message, "Электроэнергия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
