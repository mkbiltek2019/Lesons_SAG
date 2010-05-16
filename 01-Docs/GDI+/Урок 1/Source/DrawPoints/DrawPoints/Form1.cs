using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawPoints
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // рисуем все точки в коллекции
            foreach (Point p in points)
                g.FillEllipse(Brushes.Black, p.X, p.Y, 10F, 10F);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // добавляем в коллекцию новую точку
            points.Add(new Point(e.X, e.Y));
            // выполняем перерисовку клиентской области
            Invalidate();
        }
    }
}
