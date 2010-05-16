using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PageCoordinates
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
            // смещаем начало координат для страницы относительно мировых
            g.TranslateTransform(10, 30);
            // рисуем прямоугольник
            g.DrawRectangle(new Pen(Brushes.Blue,4), 0, 0, 80, 80);
        }
    }
}
