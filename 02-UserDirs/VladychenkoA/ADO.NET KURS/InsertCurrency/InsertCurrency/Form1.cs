using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertCurrency
{
    public partial class Form1 : Form
    {
        public int Num = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = null;
            digitalCodeTextBox.Text = null;
            letterCodeTextBox.Text = null;
            nunberUnitTextBox.Text = null;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num += 1;
            Currency currency = new Currency
            {
                Number = Num,
                Name = nameTextBox.Text,
                DigitalCode = digitalCodeTextBox.Text,
                LetterCode = letterCodeTextBox.Text,
                NumberUnit = Convert.ToInt32( nunberUnitTextBox.Text)

            };

            currency.Save();
            button1.Enabled = false;
        }


    }
}
