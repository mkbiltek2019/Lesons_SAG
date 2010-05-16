using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageTransformation
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
                try
                {
                    // рисуем изображение без трасформаций 
                    g.DrawImage(new Bitmap(@"Boxs.bmp"), 0, 0, 100, 100);
                }
                catch { }
                // Создаем матрицу
                Matrix X = new Matrix();
                // Установка трансформаций
                X.RotateAt(45,new Point(150,150));
                X.Translate(100, 100);
                g.Transform = X;
                try
                {
                    // рисуем изображение
                    g.DrawImage(new Bitmap(@"Rings.bmp"), 0, 0, 100, 100);
                }
                catch { }

                // Сброс трансформаций
                X.Reset();
                // Установка трансформаций
                X.RotateAt(25, new Point(50, 150));
                X.Translate(150, 10);
                X.Shear(0.5f, 0.3f);
                g.Transform = X;
                try
                {
                    // рисуем изображение
                    g.DrawImage(new Bitmap(@"Cells.bmp"), 0, 0, 100, 100);
                }
                catch { }

            }

        }
    }
}
