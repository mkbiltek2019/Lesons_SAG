using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PenExample
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
            Pen pn = new Pen(Brushes.Blue, 5);
            pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawEllipse(pn, 50, 100, 170, 40);

        }
    }
}
