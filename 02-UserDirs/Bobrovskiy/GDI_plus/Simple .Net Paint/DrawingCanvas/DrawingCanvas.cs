using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace ClassicPaint
{
    public class DrawingCanvas : Panel
    {
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

        public Image Contents
        {
            get
            {
                return contents;
            }
            set
            {
                contents = value;
            }
        }

        private Image contents;
        private Size drawingArea;
        private bool press;
        private bool resizeMode = false;
        private const int borderSquareSize = 6;
        private const int doubleBorder = borderSquareSize * 2;
        private Point mouseStartPosition;

        private Size drawingAreaStart = new Size(0, 0);

        public Color mainColor = Color.Black;
        public Color backGroundColor = Color.Black;
        public Color foregroundColor = Color.White;

        private Size moove = new Size(0, 0);
        private readonly int mooveStep = 20;

        #region mouse events handlers

        public void DrawingCanvasMouseDown(Point mousePosition)
        {
            mouseStartPosition = mousePosition;

            press = true;

            Point startPos =
                new Point(drawingArea.Width + borderSquareSize + moove.Width,
                          drawingArea.Height + borderSquareSize + moove.Height);

            Size squareSize = new Size(borderSquareSize, borderSquareSize);

            if (new Rectangle(startPos, squareSize).Contains(mousePosition))
            {
                resizeMode = true;
            }

            Point squareSize2 = new Point(mousePosition.X  - moove.Width ,
                                          mousePosition.Y  - moove.Height);

            Action(mousePosition, squareSize2);

            Refresh();
        }

        public void DrawingCanvasMouseUp(Point mousePosition)
        {
            if (resizeMode)
            {
                if (Contents != null)
                {
                    Contents = ResizeImage(contents, drawingArea);
                }

                CropBitmap(mousePosition.X + borderSquareSize + moove.Width,
                           mousePosition.Y + borderSquareSize + moove.Height);

                Refresh();
            }

            press = false;
            resizeMode = false;
        }

        private bool HugeComparisonOperator(Point mousePosition)
        {
            if ((mousePosition.X - moove.Width) >= borderSquareSize &&
                     (mousePosition.X - moove.Width) < DrawWidth + borderSquareSize &&
                     (mousePosition.Y - moove.Height) >= borderSquareSize &&
                     (mousePosition.Y - moove.Height) < DrawHeight + borderSquareSize)
            {
                return true;
            }
            return false;
        }

        public void DrawingCanvasMouseMove(Point mousePosition)
        {
            Point squareSize = new Point(mousePosition.X - moove.Width ,
                                         mousePosition.Y - moove.Height);

            if (!resizeMode)
            {
                if (HugeComparisonOperator(mousePosition))
                {
                    if (press)
                    {
                        try
                        {
                            Action(mousePosition, squareSize); // this is main event !!!

                            Refresh();

                            mouseStartPosition = squareSize;
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
                    Pen pen = new Pen(SystemColors.Highlight);
                    pen.DashStyle = DashStyle.Solid;
                    Point start = new Point(borderSquareSize + moove.Width,
                                            borderSquareSize + moove.Height);
                    Size end = new Size(squareSize.X, squareSize.Y);

                    g.DrawRectangle(pen, new Rectangle(start, end));
                }

                Refresh();
            }
        }

        private void Action(Point mousePosition, Point squareSize)
        {  // here we set all needed parameter to selected ToolControl
            if (Host.Global.SlectedTool!=null)
            {
                Host.Global.SlectedTool.StartXY =
                 new Point(mousePosition.X - moove.Width, mousePosition.Y - moove.Height);

                Host.Global.SlectedTool.EndXY =
                    new Point(squareSize.X - moove.Width, squareSize.Y - moove.Height);

                Host.Global.SlectedTool.MainColor = this.mainColor;

                contents = Host.Global.SlectedTool.Draw(contents);
            }   
        }

        #endregion


        #region do not use autoscroll

        //protected override void OnScroll(ScrollEventArgs se)
        //{  // using AutoScroll is bad Need fast  area update it sad
        //    base.OnScroll(se);
        //    this.Refresh();
        //}
        #endregion

        public DrawingCanvas()
        {
            const int defaultCancasWidth = 40;
            const int defaultCanvasHeight = 30;

            ResizeRedraw = true;

            #region do not use autoscroll
            //this.HorizontalScroll.SmallChange = 10;
            //this.HorizontalScroll.LargeChange = 10;
            //this.VerticalScroll.LargeChange = 10;
            //this.VerticalScroll.SmallChange = 10;
            //this.AutoScrollMinSize = new Size(10000,10000);
            #endregion

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
            hScrollBar1.Location = new Point(0, this.Height - 25);
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
            contents = new Bitmap(drawingArea.Width, drawingArea.Height);

            using (Graphics g = Graphics.FromImage(contents))
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
            base.OnPaint(e);
            Graphics g = e.Graphics;

            int wd = drawingArea.Width + borderSquareSize + moove.Width;
            int ht = drawingArea.Height + borderSquareSize + moove.Height;

            SolidBrush sb = new SolidBrush(Color.Red);

            g.DrawImage(contents, borderSquareSize + moove.Width,
                                  borderSquareSize + moove.Height,
                                  drawingArea.Width, drawingArea.Height);

            #region do not use autoscroll
            //g.DrawImage(Contents,this.AutoScrollPosition.X,
            //                      this.AutoScrollPosition.Y,
            //                      drawingArea.Width, drawingArea.Height);
            #endregion

            g.FillRectangle(sb, moove.Width, moove.Height, borderSquareSize, borderSquareSize);
            g.FillRectangle(sb, wd, moove.Height, borderSquareSize, borderSquareSize);
            g.FillRectangle(sb, moove.Width, ht, borderSquareSize, borderSquareSize);
            g.FillRectangle(sb, wd, ht, borderSquareSize, borderSquareSize);
        }

        #region  Canvas public methods

        public Image ResizeImage(Image imgToResize, Size newSize)
        {
            if ((newSize.Width > 0) && (newSize.Height > 0))
            {
                Image b = new Bitmap(newSize.Width, newSize.Height);
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

        public void DrawImage(Image currentImage)
        {
            if (currentImage != null)
            {
                drawingArea.Width = currentImage.Width;
                drawingArea.Height = currentImage.Height;

                Contents = currentImage;
            }
        }

        public void CropBitmap(int width, int height)
        {
            // cut a part of image if it is out of drawRectangle
            drawingArea.Width = width;
            drawingArea.Height = height;

            try
            {
                contents = ((Bitmap)contents).
                           Clone(new Rectangle(drawingAreaStart.Width,
                                               drawingAreaStart.Height,
                                               width, height),
                                 Contents.PixelFormat);
            }
            catch
            {
                Image oldc = contents;
                if ((width > 0) && (height > 0))
                {
                    contents = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(contents))
                    {
                        g.FillRectangle(Brushes.White, drawingAreaStart.Width,
                                        drawingAreaStart.Height, width, height);

                        g.DrawImage(oldc, drawingAreaStart.Width,
                                          drawingAreaStart.Height);
                    }
                }
            }

        }

        public void ClearBitmap()
        {
            contents = new Bitmap(drawingArea.Width, drawingArea.Height);
            using (Graphics g = Graphics.FromImage(contents))
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

        #endregion

    }

}
