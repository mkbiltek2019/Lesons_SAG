using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicsExample
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
            Font f = new Font("Verdana", 30, FontStyle.Italic);
            g.DrawString("Hello World!", f, Brushes.Blue, 10, 10);

        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics g = e.Graphics;
        //    Font f = new Font("Verdana", 30, FontStyle.Italic);
        //    g.DrawString("Hello World!", f, Brushes.Blue, 10, 10);
        //}


    }
}
