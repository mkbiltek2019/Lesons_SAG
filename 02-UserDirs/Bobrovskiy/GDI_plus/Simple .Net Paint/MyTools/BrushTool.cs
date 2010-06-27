using System.Drawing;
using System.Drawing.Drawing2D;
using MyTools;

namespace MyTools
{
    public class BrushTool : BaseTool
    {
        public BrushTool()
        {
            PenStrength = 1;
            MainColor = Color.Black;
            PenEndLineStyle = LineCap.Round;
            PenStartLineStyle = LineCap.RoundAnchor;
        }

        #region BaseTool Members

        public override Image Draw(Image currentImage)
        {
            Pen pen = new Pen(MainColor, PenStrength);
            pen.StartCap = PenStartLineStyle;
            pen.EndCap = PenEndLineStyle;

            if (!startPosition.IsEmpty && !endPosition.IsEmpty)
            {
                using (Graphics g = Graphics.FromImage(currentImage))
                {
                    g.DrawLine(pen, startPosition.X, startPosition.Y, endPosition.X, endPosition.Y);
                }
            }

            return currentImage;  
        }

        public new string ToString()
        {
            return this.GetType().ToString();
        }

        #endregion
    }
}
