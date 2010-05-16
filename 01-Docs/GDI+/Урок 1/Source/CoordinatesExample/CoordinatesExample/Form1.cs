using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoordinatesExample
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
            // сдвигаем начало координат страницы
            g.TranslateTransform(10, 50);
            Point A = new Point(0, 0);
            Point B = new Point(120, 120);
            g.DrawLine(new Pen(Brushes.Blue, 3), A, B);
        }
    }
}
