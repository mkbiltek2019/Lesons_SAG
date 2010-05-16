using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LocalTransformation
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
                // создаем путь
                GraphicsPath path = new GraphicsPath();
                path.AddLine(20, 50, 200, 50);
                path.AddArc(50, 50, 100, 50, 10, -220);

                Matrix X = new Matrix();
                // вращаем на 20 градусов
                X.Rotate(20);
                // применяем преобразование к  GraphicsPath
                path.Transform(X);
                // Визуализируем прямоугольник
                g.DrawRectangle(new Pen(Brushes.Green,2), 10, 10, 60, 60);
                // Визуализируем путь
                g.DrawPath(new Pen(Color.Blue, 4), path);
                // Освобождаем ресурсы
            }

        }
    }
}
