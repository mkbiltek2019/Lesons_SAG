using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePhoneBook
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxPhone.Text = "";
            textBoxSurname.Text = "";
            textBoxName.Text = "";
            textBoxEMaill.Text = "";
        }
    }
}
