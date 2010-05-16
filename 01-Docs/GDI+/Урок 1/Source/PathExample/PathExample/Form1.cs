using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PathExample
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

            //Создаем массив точек
            Point[] points = {
                    new Point(5, 10),
                    new Point(23, 130),
                    new Point(130, 57)};

            GraphicsPath path = new GraphicsPath();
            //рисуем первую траекторию
            path.StartFigure();
            path.AddEllipse(170, 170, 100, 50);
            // заливаем траекторию цветом
            g.FillPath(Brushes.Aqua, path);
            //рисуем вторую траекторию
            path.StartFigure();
            path.AddCurve(points, 0.5F);
            path.AddArc(100, 50, 100, 100, 0, 120);
            path.AddLine(50, 150, 50, 220);
            // Закрываем траекторию
            path.CloseFigure();
            //рисуем четвертую траекторию
            path.StartFigure();
            path.AddArc(180, 30, 60, 60, 0, -170);

            g.DrawPath(new Pen(Color.Blue, 3), path);
            g.Dispose();
        }
    }
}
