using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TetrisLib
{
    public class Square : GameItem
    {

        public Square(Color fore, Color back, Size size)
        {
            this.fore = fore;
            this.back = back;
            this.size = size;
        }

        public void Show(IntPtr hwnd)
        {

            Graphics surface = Graphics.FromHwnd(hwnd);
            Rectangle rectangle = new Rectangle(location.X,location.Y,size.Width,size.Height);

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rectangle);

            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = fore;
            brush.SurroundColors = new Color[] { back };

            surface.FillPath(brush,path);

        }

        public void Hide(IntPtr hwnd)
        {

            Graphics surface = Graphics.FromHwnd(hwnd);
            Rectangle rectangle = new Rectangle(location.X, location.Y, size.Width, size.Height);

            surface.FillRectangle(new SolidBrush(GameField.BackColor),rectangle);
        }

        public Size SgureSize
        {
            get { return size; }
        }

        public void Down()
        {
            location.Y += GameField.SquareSize;
        }
    }
}
