using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MatrixAndTransform
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
            string matrix1 = null;
            System.Drawing.Drawing2D.Matrix X1 = g.Transform;
            // производим чтение из матрицы X1
            for (int i = 0; i < X1.Elements.Length; i++)
            {
                matrix1 += X1.Elements[i].ToString();
                matrix1 += ", ";
            }
            lblBefore.Text = "before - " + matrix1.Trim(' ', ',');
            // рисуем линию
            g.DrawLine(new Pen(Brushes.Red, 3), 0, 10, 100, 50);
            // смещаем начало координат для страницы относительно мировых
            g.TranslateTransform(10, 50);

            string matrix2 = null;
            System.Drawing.Drawing2D.Matrix X2 = g.Transform;
            // производим чтение из матрицы X1
            for (int i = 0; i < X2.Elements.Length; i++)
            {
                matrix2 += X2.Elements[i].ToString();
                matrix2 += ", ";
            }
            lblAfter.Text = "after - " + matrix2.Trim(' ', ',');
            // рисуем линию
            g.DrawLine(new Pen(Brushes.Red, 3), 0, 10, 100, 50);

        }
    }
}
