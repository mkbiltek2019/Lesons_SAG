using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawRectangle
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
            int x = 20;
            int y = 30;
            int height = 60;
            int width = 60;
            // Создаем начальную точку
            Point pt = new Point(10, 10);
            // Создаем размер
            Size sz = new Size(160, 140);
            // Создаем два прямоугольника
            Rectangle rect1 = new Rectangle(pt, sz);
            Rectangle rect2 = new Rectangle(x, y, width, height);
            // Отображаем прямоугольники
            g.FillRectangle(Brushes.Black, rect1);
            g.DrawRectangle(new Pen(Brushes.Red, 2), rect2);
        }
    }
}
