using System.Drawing;

namespace MyTools
{
    public class BrushTool : BaseTool
    {
        public BrushTool()
        {
            PenStrength = 1;
            MainColor = Color.Black;
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
                            new Rectangle((startPosition.X - CustomBrush.Width/2),
                                          (startPosition.Y - CustomBrush.Height/2),
                                          CustomBrush.Width, CustomBrush.Height));
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
