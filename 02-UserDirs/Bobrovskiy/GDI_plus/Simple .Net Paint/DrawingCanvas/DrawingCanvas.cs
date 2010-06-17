using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace ClassicPaint
{
    public class DrawingCanvas : Panel
    {
        private Size drawingArea;
        private Bitmap contents; 
        private Bitmap image;

        private bool press;
        private int mouseStartPositionX;
        private int mouseDownStartPosotionY;

        private Color mainColor = Color.Black;
        private bool resizeMode = false;

        private const int border = 6;
        private const int doubleBorder = border * 2;

        public int DrawWidth
        {
            get
            {
                return drawingArea.Width;
            }
            set
            {
                drawingArea.Width = value;
            }
        }

        public int DrawHeight
        {
            get
            {
                return drawingArea.Height;
            }
            set
            {
                drawingArea.Height = value;
            }
        }

        public void DrawingCanvasMouseDown(int mouseX, int mouseY, int penThick)
        {
            mouseStartPositionX = mouseX;
            mouseDownStartPosotionY = mouseY;

            PaintPixel(mouseX, mouseY, mainColor, penThick);
            press = true;

            if (mouseX >= DrawWidth + border && mouseX < DrawWidth + doubleBorder
                && mouseY >= DrawHeight + border && mouseY < DrawHeight + doubleBorder)
            {
                resizeMode = true;
            }

            Refresh();
        }

        public void DrawingCanvasMouseUp(int mouseX, int mouseY)
        {
            if (resizeMode)
            {
                CropBitmap(mouseX + border, mouseY + border);
                if (image != null)
                { 
                    DrawImage(ResizeImage(image, drawingArea));
                }
                Refresh();
            }

            press = false;
            resizeMode = false;
        }

        public Bitmap ResizeImage(Bitmap imgToResize, Size newSize)
        {
            Bitmap b = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawImage(imgToResize, 0, 0, newSize.Width, newSize.Height);
                g.Dispose();
            }

            return b;
        }

        public void DrawingCanvasMouseMove(int mouseX, int mouseY, int thick)
        {
            int x1 = mouseX - border;
            int y1 = mouseY - border;

            if (!resizeMode)
            {
                if (mouseX >= border && mouseX < DrawWidth + border &&
                    mouseY >= border && mouseY < DrawHeight + border)
                {
                    if (press)
                    {
                        try
                        {
                            InterpolatePixel(mouseStartPositionX, mouseDownStartPosotionY, x1, y1, mainColor, thick);
                            Refresh();
                            mouseStartPositionX = x1;
                            mouseDownStartPosotionY = y1;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            else
            {
                using (Graphics g = CreateGraphics())
                {
                    Pen pn = new Pen(SystemColors.Highlight);
                    pn.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

                    g.DrawRectangle(pn, border, border, x1, y1);
                }

                Refresh();
            }
        }

        public DrawingCanvas()
        {
            const int defaultCancasWidth = 400;
            const int defaultCanvasHeight = 300;

            DoubleBuffered = true;
            ResizeRedraw = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, true);
          
            this.Bounds = new Rectangle(border, border, drawingArea.Width, drawingArea.Height); 

            BackgroundImageLayout = ImageLayout.Stretch;

            drawingArea = new Size(defaultCancasWidth, defaultCanvasHeight);
            contents = new Bitmap(drawingArea.Width, drawingArea.Height);

            using (Graphics g = Graphics.FromImage(contents))
            {
                g.FillRectangle(Brushes.White, 0, 0, drawingArea.Width, drawingArea.Height);
            }
        }

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            int wd = drawingArea.Width + border;
            int ht = drawingArea.Height + border;

            SolidBrush sb = new SolidBrush(Color.Red);

            g.DrawImage(contents, border, border, drawingArea.Width, drawingArea.Height);
            g.FillRectangle(sb, 0, 0, border, border);
            g.FillRectangle(sb, wd, 0, border, border);
            g.FillRectangle(sb, 0, ht, border, border);
            g.FillRectangle(sb, wd, ht, border, border);
            g.FillRectangle(sb, wd, ht / 2, border, border);
            g.FillRectangle(sb, wd / 2, ht, border, border);
        }

        public void InterpolatePixel(int x, int y, int x1, int y1, Color color, int width)
        {
            Pen pn = new Pen(color, width);
            pn.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pn.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics.FromImage(contents).DrawLine(pn, x, y, x1, y1);
        }

        public void PaintPixel(int x, int y, Color color, int width)
        {
            Pen pn = new Pen(color, width);
            pn.StartCap = LineCap.Round;
            Graphics.FromImage(contents).DrawLine(pn, x, y, x, y);
        }

        public void DrawImage(Image currentImage)
        {
            image = (Bitmap)currentImage;

            if (currentImage != null)
            {
                contents = new Bitmap(currentImage);
                CropBitmap(currentImage.Width, currentImage.Height);
                Refresh();
            }
        }

        public void CropBitmap(int width, int height)
        {
            drawingArea.Width = width;
            drawingArea.Height = height;
            try
            {
                contents = contents.Clone(new Rectangle(0, 0, width, height),
                           contents.PixelFormat);
            }
            catch
            {
                Bitmap oldc = contents;
                contents = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(contents))
                {
                    g.FillRectangle(Brushes.White, 0, 0, width, height);
                    g.DrawImage(oldc, 0, 0);
                }
            }

        }

        public void ClearBitmap()
        {
            contents = new Bitmap(drawingArea.Width, drawingArea.Height);
            using (Graphics g = Graphics.FromImage(contents))
            {
                g.FillRectangle(Brushes.White, 0, 0, drawingArea.Width, drawingArea.Height);
            }

        }

        public override void Refresh()
        {
            Invalidate();
            Update();
        }    

    }

}
