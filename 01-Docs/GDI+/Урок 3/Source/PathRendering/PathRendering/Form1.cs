using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PathRendering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                GraphicsPath path = new GraphicsPath();

                path.AddLine(20, 20, 170, 20);
                path.AddLine(20, 20, 20, 100);
                // рисуем новую фигуру
                path.StartFigure();
                path.AddLine(240, 140, 240, 50);
                path.AddLine(240, 140, 80, 140);
                path.AddRectangle(new Rectangle(30, 30, 200, 100));
                // локальное преобразование траектории
                //Matrix X = new Matrix();
                //X.RotateAt(45, new PointF(60.0f, 100.0f));
                //path.Transform(X);
                // рисуем  path
                Pen redPen = new Pen(Color.Red, 2);
                g.FillPath(new SolidBrush(Color.Bisque), path);
                g.DrawPath(redPen, path);

            }

        }
    }
}
