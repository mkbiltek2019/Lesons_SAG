using System.Drawing;
using System.Drawing.Drawing2D;
using MyTools;

namespace MyTools
{
    public class TextTool : BaseTool
    {
        public TextTool()
        {
            TextToDraw = string.Empty;
            PenStrength = 1;
            MainColor = Color.Black;
        }

        #region BaseTool Members

        public override Image Draw(Image currentImage)
        {
            if (currentImage != null)
            {
                if (!startPosition.IsEmpty && !endPosition.IsEmpty)
                {
                    using (Graphics g = Graphics.FromImage(currentImage))
                    {
                        if (!string.IsNullOrEmpty(TextToDraw))
                        {
                            g.DrawImage(this.TextResultImage, 
                                 startPosition.X - this.TextResultImage.Width/2, 
                                 startPosition.Y- this.TextResultImage.Height/2);
                        } 
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
