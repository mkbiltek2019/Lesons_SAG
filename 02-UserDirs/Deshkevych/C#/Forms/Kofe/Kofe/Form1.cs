using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kofe
{
    public partial class Form1 : Form
    {
        private double summ;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox3.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) summ += 54.00;
            else summ -= 54.00;

            label1.Refresh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                summ += 24.50;
                if (!checkBox3.Enabled) checkBox3.Enabled = true;
            }
            else
            {
                summ -= 24.50;

                if (checkBox3.Checked) checkBox3.Checked = false;
                checkBox3.Enabled = false;
            }
            label1.Refresh();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) summ += 10.50;
            else
            {
                summ -= 10.50;
            }
            label1.Refresh();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) summ += 18.00;
            else summ -= 18.00;
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = summ.ToString("C");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked &&
                checkBox3.Checked && checkBox4.Checked)
            {
                MessageBox.Show("Вам предоставляется скидка 10%\n" + "Стоимость заказа: "
                    + (summ*0.9).ToString("C"),
                                "Кафе");
            }
            else
            {
                if (checkBox1.Checked || checkBox2.Checked 
                    || checkBox3.Checked || checkBox4.Checked)
                    MessageBox.Show("Стоимость заказа : " + summ.ToString("C"), "Кафе");
                else
                {
                    MessageBox.Show("Вы ничего не заказали !", "Кафе");
                }
            }
        }




    }
}
