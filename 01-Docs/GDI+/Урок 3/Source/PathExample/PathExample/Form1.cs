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
            using (Graphics g = e.Graphics)
            {
                // Создаем траекторию
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(20, 20, 150, 150);
                path.AddRectangle(rect);
                // Создаем градиентную кисть
                PathGradientBrush pgBrush =
                    new PathGradientBrush(path.PathPoints);
                // Уснинавливаем цвета кисти
                pgBrush.CenterColor = Color.Red;
                pgBrush.SurroundColors = new Color[] { Color.Blue };
                // Создаем объект Matrix
                Matrix X = new Matrix();
                // Translate
                X.Translate(30.0f, 10.0f, MatrixOrder.Append);
                // Rotate
                X.Rotate(10.0f, MatrixOrder.Append);
                // Scale
                X.Scale(1.2f, 1.0f, MatrixOrder.Append);
                // Shear
                X.Shear(.2f, 0.03f, MatrixOrder.Prepend);
                // Применяем преобразование к траектории и кисти
                path.Transform(X);
                pgBrush.Transform = X;
                // Выполняем визуализацию
                g.FillPath(pgBrush, path);
            }

        }
    }
}
