using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _10._04._2010
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random =new Random();
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);
            BackColor = Color.FromArgb(r, g, b);
            MessageBox.Show(String.Format("Колір змінений:\nR={0}\nG={1}\nB={2}",r,g,b), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
