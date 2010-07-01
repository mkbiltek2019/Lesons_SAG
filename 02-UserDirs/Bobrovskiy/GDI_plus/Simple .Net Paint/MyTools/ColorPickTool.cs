using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyTools
{
    public class ColorPickTool : BaseTool
    {
        public ColorPickTool()
        {
        }

        #region BaseTool Members

        public override Image Draw(Image currentImage)
        {
            if ((this.startPosition.X <= currentImage.Width) &&
                (this.startPosition.Y <= currentImage.Height)&&
                (this.startPosition.Y >= 6)&&
                (this.startPosition.Y >= 6))
            {
              ColorPikerColor =
                 ((Bitmap)currentImage).GetPixel(this.startPosition.X, startPosition.Y);
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
