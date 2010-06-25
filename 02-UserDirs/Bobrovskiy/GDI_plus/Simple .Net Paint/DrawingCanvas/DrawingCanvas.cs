using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using PluginInterface;

namespace ClassicPaint
{
    public class DrawingCanvas : Panel
    {
        public int PenThick
        {
            get; 
            set;
        }

        public LineCap PenEndLineStyle
        {
            get; 
            set;
        }
        
        public string TextToDraw
        {
            get; 
            set;
        }
        
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
        
        public Bitmap Contents;
 
        private Size drawingArea;
        
        private bool press;
        private int mouseStartPositionX;
        private int mouseStartPositionY;

        private Size drawingAreaStart = new Size(0,0);
        private Size moove = new Size(0, 0);
        private readonly int mooveStep = 20;
        
        public Color mainColor = Color.Black;
        public Color backGroundColor = Color.Black;
        public Color foregroundColor = Color.White;

        private bool resizeMode = false;

        private const int borderSquareSize = 6;
        private const int doubleBorder = borderSquareSize * 2;

        
        #region mouse events handlers

        public void DrawingCanvasMouseDown(Point mousePosition, Tool.BasicTools tool)
        {  
            mouseStartPositionX = mousePosition.X;
            mouseStartPositionY = mousePosition.Y;

            press = true;

            int startX = drawingArea.Width + borderSquareSize+ moove.Width;
            int startY = drawingArea.Height + borderSquareSize+ moove.Height;

            if (new Rectangle(startX, startY, borderSquareSize, borderSquareSize).Contains(mousePosition))
            {
                resizeMode = true;
            }
           
            #region some action by selected tool 

            if (tool == Tool.BasicTools.Pencil)
            {
              PaintPixel(mousePosition.X + moove.Width, mousePosition.Y + moove.Height, mainColor, PenThick);
            }
                     
            if (tool == Tool.BasicTools.Text)
            {
                DrawText(mousePosition.X , mousePosition.Y, this.TextToDraw);
            }

            #endregion

            Refresh();
        }
        
        public void DrawingCanvasMouseUp(Point mousePosition)
        { 
           if (resizeMode)
            {
                if (Contents != null)
                {
                    Contents = ResizeImage(Contents, drawingArea);
                }

                CropBitmap(mousePosition.X + borderSquareSize + moove.Width, mousePosition.Y + borderSquareSize + moove.Height);
                
                Refresh();
            }
            
            press = false;
            resizeMode = false;
        }

        public void DrawingCanvasMouseMove(Point mousePosition, Tool.BasicTools tool)
        { 
            int x1 = mousePosition.X - borderSquareSize;
            int y1 = mousePosition.Y - borderSquareSize;

            if (tool != Tool.BasicTools.MouseCursor && (tool != Tool.BasicTools.Text))
            {
                if (!resizeMode)
                {
                    if ((mousePosition.X - moove.Width) >= borderSquareSize &&
                        (mousePosition.X - moove.Width) < DrawWidth + borderSquareSize &&
                        (mousePosition.Y - moove.Height) >= borderSquareSize &&
                        (mousePosition.Y - moove.Height) < DrawHeight + borderSquareSize)
                    {
                        if (press)
                        {
                            try
                            {
                                InterpolatePixel(mouseStartPositionX - moove.Width, 
                                                 mouseStartPositionY - moove.Height,
                                                 x1 - moove.Width, y1 - moove.Height, mainColor, PenThick);
                                Refresh();

                                mouseStartPositionX = x1;
                                mouseStartPositionY = y1;
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
                        pn.DashStyle = DashStyle.Solid;
                        g.DrawRectangle(pn, borderSquareSize, borderSquareSize, x1, y1);
                    }

                    Refresh();
                }
            }
        }
       
        #endregion 

        public Bitmap ResizeImage(Bitmap imgToResize, Size newSize)
        {
            if ((newSize.Width > 0) && (newSize.Height > 0))
            {
                Bitmap b = new Bitmap(newSize.Width, newSize.Height);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.DrawImage(imgToResize, 
                                drawingAreaStart.Width, drawingAreaStart.Height,
                                newSize.Width, newSize.Height);
                }
                
                return b;
            }

            return imgToResize; 
        }

        public DrawingCanvas()
        {
            TextToDraw = string.Empty;
            PenThick = 1;
            PenEndLineStyle = LineCap.Round;

            const int defaultCancasWidth = 40;
            const int defaultCanvasHeight = 30;
            
            ResizeRedraw = true;
            
            this.HorizontalScroll.SmallChange = 1;
            this.HorizontalScroll.LargeChange = 1;
            
            this.Focus();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.ContainerControl, true);

            VScrollBar vScrollBar1 = new VScrollBar();
            // Dock the scroll bar to the right side of the form.
            vScrollBar1.Dock = DockStyle.Right;
           
            vScrollBar1.LargeChange = 5;
            vScrollBar1.SmallChange = 5;
            vScrollBar1.Value = 0;
            vScrollBar1.Maximum = 100;
            vScrollBar1.Minimum = 1;
            vScrollBar1.Scroll += new ScrollEventHandler(vScrollBar1_Scroll);
            // Add the scroll bar to the form.
            Controls.Add(vScrollBar1);
            HScrollBar hScrollBar1 = new HScrollBar();
            // Dock the scroll bar to the right side of the form.
            hScrollBar1.Location = new Point(0, this.Height -25);
            hScrollBar1.Dock = DockStyle.Bottom;
            
            hScrollBar1.LargeChange = 5;
            hScrollBar1.SmallChange = 5;
            hScrollBar1.Value = 0;
            hScrollBar1.Maximum = 100;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Scroll += new ScrollEventHandler(hScrollBar1_Scroll);
            // Add the scroll bar to the form.
            Controls.Add(hScrollBar1);

            this.Bounds = 
                new Rectangle(borderSquareSize, borderSquareSize, 
                              drawingArea.Width, drawingArea.Height); 

            BackgroundImageLayout = ImageLayout.Tile;

            drawingArea = new Size(defaultCancasWidth, defaultCanvasHeight);
            Contents = new Bitmap(drawingArea.Width, drawingArea.Height);
          
            using (Graphics g = Graphics.FromImage(Contents))
            {
               g.FillRectangle(Brushes.White, drawingAreaStart.Width, drawingAreaStart.Height,
                                               drawingArea.Width, drawingArea.Height);
            }
        }

        #region vertical and horizontal scroll handlers

        void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                moove.Width += mooveStep;
                moove = new Size(moove.Width, moove.Height);
            }
            if (e.Type == ScrollEventType.SmallDecrement)
            {
                moove.Width -= mooveStep;
                moove = new Size(moove.Width, moove.Height);
            }

            Refresh();
        }

        void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallIncrement)
            {
                moove.Height += mooveStep;
                moove = new Size(moove.Width, moove.Height);
            }
            if (e.Type == ScrollEventType.SmallDecrement)
            {
                moove.Height -= mooveStep;
                moove = new Size(moove.Width, moove.Height);
            }

            Refresh();
        }
        
        #endregion

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnPaint(PaintEventArgs e)
        {
            this.Focus();
            base.OnPaint(e);
            Graphics g = e.Graphics;

            int wd = drawingArea.Width + borderSquareSize+ moove.Width;
            int ht = drawingArea.Height + borderSquareSize + moove.Height;

            SolidBrush sb = new SolidBrush(Color.Red);
            
            g.DrawImage(Contents, borderSquareSize+moove.Width,
                                  borderSquareSize+moove.Height,
                                  drawingArea.Width, drawingArea.Height);

            g.FillRectangle(sb, moove.Width, moove.Height, borderSquareSize, borderSquareSize);
            g.FillRectangle(sb, wd, moove.Height, borderSquareSize, borderSquareSize);
            g.FillRectangle(sb, moove.Width, ht, borderSquareSize, borderSquareSize);
            g.FillRectangle(sb, wd , ht , borderSquareSize, borderSquareSize);
        }

        public void InterpolatePixel(int x, int y, int x1, int y1, Color color, int width)
        {
            Pen pn = new Pen(color, width);
            pn.StartCap = PenEndLineStyle;
            pn.EndCap = PenEndLineStyle;

            using (Graphics g = Graphics.FromImage(Contents))
            {
                g.DrawLine(pn, x, y, x1, y1);
            }
        }

        public void PaintPixel(int x, int y, Color color, int width)
        {
            Pen pn = new Pen(color, width);
            pn.StartCap = PenEndLineStyle;
            pn.EndCap = PenEndLineStyle;
            
            using (Graphics g = Graphics.FromImage(Contents))
            {
               g.DrawLine(pn, x, y, x, y);
            }  
        }

        public void DrawImage(Image currentImage)
        {
            if (currentImage!=null)
            {
                drawingArea.Width = currentImage.Width;
                drawingArea.Height = currentImage.Height;

                Contents = (Bitmap)currentImage; 
            }         
        }

        public void CropBitmap(int width, int height)
        {
            drawingArea.Width = width;
            drawingArea.Height = height;

            try
            {
                Contents = 
                    Contents.Clone(new Rectangle(drawingAreaStart.Width, drawingAreaStart.Height, 
                                                 width, height),
                                    Contents.PixelFormat);
            }
            catch
            {
                Bitmap oldc = Contents;
                if ((width > 0) && (height > 0))
                {
                    Contents = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(Contents))
                    {
                        g.FillRectangle(Brushes.White, drawingAreaStart.Width, drawingAreaStart.Height, width, height);
                        g.DrawImage(oldc, drawingAreaStart.Width, drawingAreaStart.Height);
                    }
                }
            }

        }

        public void ClearBitmap()
        {
            Contents = new Bitmap(drawingArea.Width, drawingArea.Height);
            using (Graphics g = Graphics.FromImage(Contents))
            {  
                g.FillRectangle(Brushes.White, 
                    drawingAreaStart.Width, drawingAreaStart.Height,
                    drawingArea.Width, drawingArea.Height);
            }

        }

        public override void Refresh()
        {
            Invalidate();
            Update();
        }

        public void SetDrawSize(Size size)
        {
            DrawHeight = size.Height;
            DrawWidth = size.Width;
            Refresh();
        }

        private void DrawText(int x, int y, string text)
        {
            using (Graphics g = Graphics.FromImage(Contents))
            {
                g.DrawString(text, Font, new SolidBrush(foregroundColor), x, y);
            }

        }
    }

}
