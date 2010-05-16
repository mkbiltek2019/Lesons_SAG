using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegionExample
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
            g.Clear(this.BackColor);
            // Создаем два прямоугольника
            Rectangle rect1 = new Rectangle(40, 40, 140, 140);
            Rectangle rect2 = new Rectangle(100, 100, 140, 140);
            // Создаем два региона
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Blue, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // определяем область пересеченияния
            rgn1.Intersect(rgn2);
            // заливаем ее красным цветом
            g.FillRegion(Brushes.Red, rgn1);
            g.Dispose();

        }
    }
}
