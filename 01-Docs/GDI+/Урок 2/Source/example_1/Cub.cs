using System.Drawing;
using System.Drawing.Drawing2D;

namespace example_1
{
    public static class Cub
    {
        public static void Create(Graphics g)
        {
            Cub.BrushesExampleMethod(g);
            Cub.Draw(g);
            Cub.PensExampleMethod(g);

int x = 15, y = 20, h = 70, w = 200;
Rectangle rect0 = new Rectangle(x, y, w, h); // или
Rectangle rect1 = new Rectangle(new Point(x, y), new Size(w, h));
        }

        public static void BrushesExampleMethod(Graphics g)
        {
            Color pink = Color.FromArgb(241, 105, 190);
            SolidBrush sldBrush = new SolidBrush(pink);
            g.FillRectangle(sldBrush, 300, 150, 70, 70);

            HatchBrush hBrush = new HatchBrush(HatchStyle.NarrowVertical, Color.Pink, Color.Blue);
            g.FillRectangle(hBrush, 370, 150, 70, 70);

            sldBrush = new SolidBrush(Color.Orchid);
            g.FillRectangle(sldBrush, 440, 150, 70, 70);

            LinearGradientBrush lgBrush = new LinearGradientBrush(new Rectangle(0, 0, 20, 20), Color.Violet, Color.LightSteelBlue, LinearGradientMode.Vertical);
            g.FillRectangle(lgBrush, 300, 220, 70, 70);

            g.FillRectangle(Brushes.Indigo, 370, 220, 70, 70);

            sldBrush = new SolidBrush(Color.Orange);
            g.FillRectangle(sldBrush, 440, 220, 70, 70);

            lgBrush = new LinearGradientBrush(new RectangleF(0, 0, 90, 90), Color.BlueViolet, Color.LightPink, LinearGradientMode.BackwardDiagonal);

            g.FillRectangle(lgBrush, 300, 290, 70, 70);

            TextureBrush tBrush = new TextureBrush(Image.FromFile(@"Images\csharp.jpg"));
            g.FillRectangle(tBrush, 370, 290, 70, 70);

            tBrush = new TextureBrush(Image.FromFile(@"Images\003.jpg"));
            g.FillRectangle(tBrush, 440, 290, 70, 70);
        }

        public static void Draw(Graphics g)
        {
            Point[] p = { new Point(240, 110), new Point(440, 110), new Point(510, 150), new Point(300, 150) };
            TextureBrush tBrush = new TextureBrush(Image.FromFile(@"Images\0073.jpg"));
            g.FillPolygon(tBrush, p);

            Point[] p1 = { new Point(240, 110), new Point(300, 150), new Point(300, 360), new Point(240, 310) };
            HatchBrush hBrush = new HatchBrush(HatchStyle.DashedDownwardDiagonal, Color.Violet, Color.White);
            g.FillPolygon(hBrush, p1);
        }

        public static void PensExampleMethod(Graphics g)
        {
            Pen p = new Pen(Color.White, 1);
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(p, 300 + 70 * i, 150, 300 + 70 * i, 360);
            }

            p = new Pen(Color.White, 1);
            p.DashStyle = DashStyle.DashDot;
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(p, 300, 150 + 70 * i, 510, 150 + 70 * i);
            }

            p = new Pen(Color.White, 1);
            p.StartCap = LineCap.DiamondAnchor;
            p.EndCap = LineCap.DiamondAnchor;
            for (int i = 0; i < 3; i++)
            {
                g.DrawLine(p, 240 + 70 * i, 110, 300 + 70 * i, 150);
            }
        }
    }
}
