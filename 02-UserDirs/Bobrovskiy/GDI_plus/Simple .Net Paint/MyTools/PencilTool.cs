using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyTools
{
    public class PencilTool : BaseTool
    {
        public PencilTool()
        {
            Initialize();
        }

        private void Initialize()
        {
            PenStrength = 1;
            PenLength = 1;
            MainColor = Color.Black;
            PenEndLineStyle = LineCap.Round;
            PenStartLineStyle = LineCap.Round;
        }

        #region BaseTool Members

        private Point Previous
        {
            get;
            set;
        }

        public override Image Draw(Image currentImage)
        {
            Pen pen = new Pen(this.MainColor, PenStrength);
            pen.StartCap = PenStartLineStyle;
            pen.EndCap = PenEndLineStyle;
            pen.Alignment = PenAlignment.Center;
            pen.LineJoin = LineJoin.Round;

            if (!startPosition.IsEmpty && !endPosition.IsEmpty)
            {
                using (Graphics g = Graphics.FromImage(currentImage))
                {
                    if (this.Solid)
                    {
                        if (Previous.IsEmpty)
                        {
                            g.DrawLine(pen, startPosition.X, startPosition.Y,
                                            endPosition.X, endPosition.Y);
                        }
                        else
                        {
                            g.DrawLine(pen, Previous.X, Previous.Y,
                                            startPosition.X, startPosition.Y);
                        }
                        Previous = startPosition;
                    }
                    else
                    {
                        g.DrawLine(pen, startPosition.X, startPosition.Y,
                                        endPosition.X, endPosition.Y);
                    } 
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
