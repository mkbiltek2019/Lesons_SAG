using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyTools
{
    public class BaseTool : IDisposable
    {
        #region common tool properties

        protected Point startPosition;
        protected Point endPosition;

        public Point StartXY
        {
            get
            {
                return startPosition;
            }
            set
            {
                startPosition = value;
            }
        }

        public Point EndXY
        {
            get
            {
                return endPosition;
            }
            set
            {
                endPosition = value;
            }
        }

        public Color MainColor
        {
            get;
            set;
        }

        #endregion

        #region Pencil specific properties

        public int PenStrength
        {
            get;
            set;
        }

        public int PenLength
        {
            get;
            set;
        }

        public LineCap PenEndLineStyle
        {
            get;
            set;
        }

        public LineCap PenStartLineStyle
        {
            get;
            set;
        }

        #endregion

        public virtual System.Drawing.Image Draw(System.Drawing.Image currentImage)
        {
            return currentImage;
        }

        #region  Common Methods

        public new string ToString()
        {
            return this.GetType().ToString();
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~BaseTool()
        {
            this.Dispose();
        }

        #endregion
    }
}
