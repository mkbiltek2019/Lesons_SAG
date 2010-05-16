using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BrushesExample
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
            Rectangle rect = new Rectangle(20, 20, 200, 40);
            LinearGradientBrush lgBrush =
                 new LinearGradientBrush(
                 rect, Color.Red, Color.Green, 0.0f, true);
            g.FillRectangle(lgBrush, rect);
            Rectangle rect2 = new Rectangle(20, 80, 200, 40);
            HatchBrush htchBrush = new HatchBrush(HatchStyle.Cross, Color.Blue);
            g.FillRectangle(htchBrush, rect2);
            TextureBrush txBrush = new TextureBrush(new Bitmap("Background.bmp"));
            Rectangle rect3 = new Rectangle(20, 140, 200, 40);
            g.FillRectangle(txBrush, rect3);
            g.Dispose();
        }
    }
}
