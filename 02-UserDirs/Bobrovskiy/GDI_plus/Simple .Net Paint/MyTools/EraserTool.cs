using System.Drawing;
using MyTools;

namespace MyTools
{
    // use canvas.Clear(Color.White)
    public class EraserTool : BaseTool
    {
        public EraserTool()
        {
            PenStrength = 1;
            MainColor = Color.White;
        }

        #region BaseTool Members

        public override Image Draw(Image currentImage)
        {
            if(CustomBrush!=null)
            {
               if (!startPosition.IsEmpty && !endPosition.IsEmpty)
                {
                    using (Graphics g = Graphics.FromImage(currentImage))
                    {
                       g.DrawImage(CustomBrush, 
                           new Rectangle(startPosition.X, startPosition.Y, 
                                         CustomBrushWidth, CustomBrushWidth));
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
