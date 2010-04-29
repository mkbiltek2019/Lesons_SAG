using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Steklopaket
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

            radioButton1.Checked = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&
                !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString()==",")&&
                    (textBox1.Text.IndexOf(",")==-1)))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                !(Char.IsControl(e.KeyChar)))
            {
                if (!((e.KeyChar.ToString() == ",") &&
                    (textBox2.Text.IndexOf(",") == -1)))
                {
                    e.Handled = true;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label1.Text = string.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text != string.Empty)
            {
                label1.Text = string.Empty;
            }
            //проверка на блокировку ок
            if ((textBox1.TextLength == 0)||
                (textBox2.TextLength == 0)||
                (textBox1.Text == ",")||
                (textBox2.Text == ","))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Single w,
                   h,
                   s,
                   c,
                   cst ;

            w = Convert.ToSingle(textBox1.Text);
            h = Convert.ToSingle(textBox2.Text);
            s = w*h/10000;

            if (radioButton1.Checked)
            {
                c = 5000;
            }
            else
            {
                c = 6000;
            }

            cst = s*c;

            if (checkBox1.Checked)
            {
                label1.Text = "Размер окна: " + w.ToString("N") +
                              " x " + h.ToString("N") + " см\n" +
                              "Стеклопакет: " + radioButton1.Text +
                              "\nСтоимость: " + cst.ToString("C");
            }
            else
            {
                label1.Text = "Размер окна: " + w.ToString("N") +
                              " x " + h.ToString("N") + " см\n" +
                              "Стеклопакет: " + radioButton2.Text +
                              "\nСтоимость: " + cst.ToString("C");
            }
        }

    }
}
