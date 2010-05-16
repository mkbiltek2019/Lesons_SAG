using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicsExample2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap myBitmap = new Bitmap(@"Background.bmp");
                // получаем объект Graphics
                Graphics gFromImage = Graphics.FromImage(myBitmap);
                Font f = new Font("Verdana", 8, FontStyle.Italic);
                string helloStr = "Hello World!";
                // меряем "Hello World!" с помошью метода MeasureString
                SizeF sz = gFromImage.MeasureString(helloStr, f);
                gFromImage.DrawString("Hello World!", f, Brushes.Blue, 10, 10);
                gFromImage.DrawRectangle(new Pen(Color.Red, 2),
                 10.0F, 10.0F, sz.Width, sz.Height);
                // сохроняем изображение на диск
                myBitmap.Save(@"NewFon.bmp");
                Rectangle regionRec = new Rectangle(new Point(0, 0), myBitmap.Size);
                myBitmap.Dispose();
                gFromImage.Dispose();
                // этот метод выполняет перерисовку клиентской области
                this.Invalidate(regionRec);
            }
            catch { }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                Bitmap myBitmap = new Bitmap(@"NewBackground.bmp");
                Graphics g = e.Graphics;
                g.DrawImage(myBitmap, 0, 0, 300, 200);
                myBitmap.Dispose();
                g.Dispose();
            }
            catch { }
        }
    }
}
