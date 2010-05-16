using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GlobalTransformation
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
            Rectangle rect = new Rectangle(30, 30, 60, 60);
            Pen penB = new Pen(Brushes.Blue, 2);
            Pen penR = new Pen(Brushes.Red, 2);
            // примитивы до глобального преобразования
            g.DrawRectangle(penB, rect);
            g.DrawLine(penR, 30, 200, 200, 170);
            g.FillEllipse(Brushes.Brown, new Rectangle(100, 30, 100, 100));

            Matrix X = new Matrix();
            X.Scale(1.4f, 1.4f, MatrixOrder.Append);
            X.RotateAt(-10, new PointF(0.0f, 0.0f), MatrixOrder.Append);
            g.Transform = X;
            /// альтернативный способ
            //g.RotateTransform(-10, MatrixOrder.Append);
            //g.ScaleTransform(1.4f, 1.4f);
            // примитивы после глобального преобразования
            g.DrawRectangle(penB, rect);
            g.DrawLine(penR, 30, 200, 200, 170);
            g.FillEllipse(Brushes.Brown, new Rectangle(100, 30, 100, 100));
        }
    }
}
