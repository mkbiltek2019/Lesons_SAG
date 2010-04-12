using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calc_
{
    public partial class FormCalc : Form
    {
        public FormCalc()
        {
            InitializeComponent();
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            int a, b, sum;
            a = Convert.ToInt32(textBoxA.Text);
            b = Convert.ToInt32(textBoxB.Text);
            sum = a + b;
            textBoxSum.Text = sum.ToString();
        }

       
    }
}
