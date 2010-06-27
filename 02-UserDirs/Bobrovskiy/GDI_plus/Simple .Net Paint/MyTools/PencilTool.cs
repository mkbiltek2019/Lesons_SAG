using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyTools
{
    public class PencilTool: BaseTool
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

        public override Image Draw(Image currentImage)
        {
            Pen pen = new Pen(MainColor, PenStrength);
            pen.StartCap = PenStartLineStyle;
            pen.EndCap = PenEndLineStyle;
            pen.Alignment = PenAlignment.Center;
            
            if (!startPosition.IsEmpty && !endPosition.IsEmpty)
            {
                using (Graphics g = Graphics.FromImage(currentImage))
                {
                    g.DrawLine(pen, startPosition.X, startPosition.Y,
                                    endPosition.X - PenLength, endPosition.Y);
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
