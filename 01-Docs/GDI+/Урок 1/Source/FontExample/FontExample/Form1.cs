using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FontExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font f = new Font("Verdana", 14, FontStyle.Bold |
                                       FontStyle.Italic);
            g.DrawString("Hello Font!", f, Brushes.Blue, 30, 55);

        }
    }
}
