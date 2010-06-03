using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomButtonControlLibrary
{
    public partial class UserControl1 : UserControl
    {
        public new event EventHandler Click;

        private bool mouseHover;
        private bool mouseDown;
        private GraphicsPath gPath;

        #region Properties

        public string Text
        {
            get;
            set;
        }

        public Color GradientColorStart
        {
            get;
            set;
        }

        public Color GradientColorEnd
        {
            get;
            set;
        }

        public Color PenColor
        {
            get;
            set;
        }

        public int PenThickness
        {
            get;
            set;
        }

        public int BorderRadius
        {
            get;
            set;
        }

        public float GradientAngle
        {
            get;
            set;
        }

        public int ClickDepth
        {
            get; 
            set;
        }

        #endregion

        public UserControl1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            GradientColorStart = Color.MidnightBlue;
            GradientColorEnd = Color.RoyalBlue;
            GradientAngle = 270;

            PenThickness = 1;
            PenColor = Color.DarkSlateBlue;
            BorderRadius = 1;
            ClickDepth = 2;

            mouseHover = false;
            mouseDown = false;
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle targetRectangle; 

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (mouseDown)
            {
                targetRectangle = new Rectangle(
                    new Point(PenThickness * ClickDepth, PenThickness * ClickDepth),
                    new Size(ClientRectangle.Size.Width - PenThickness * (ClickDepth+1),
                             ClientRectangle.Size.Height - PenThickness * (ClickDepth + 1)));
            }
            else
            {
                targetRectangle = new Rectangle(
                    new Point(PenThickness, PenThickness),
                    new Size(ClientRectangle.Size.Width - PenThickness * ClickDepth,
                             ClientRectangle.Size.Height - PenThickness * ClickDepth));
            }

            Color startColor = GradientColorStart;
            Color endColor = GradientColorEnd;

            if (mouseHover)
            {
                startColor = ControlPaint.Light(startColor, 0.50f);
                endColor = ControlPaint.Dark(endColor, 0.5f);
            }

            Brush brush = new LinearGradientBrush(
                targetRectangle,
                startColor,
                endColor,
                GradientAngle);
            Pen pen = new Pen(PenColor, PenThickness);

            DrawRoundedRectangle(e.Graphics, targetRectangle, BorderRadius, pen, brush);
        }

        public void DrawRoundedRectangle(
            Graphics g, 
            Rectangle rectangle, 
            int cornerRadius, 
            Pen pen, 
            Brush brush)
        {
            gPath = new GraphicsPath();

            gPath.AddArc(rectangle.X, rectangle.Y, 
                         cornerRadius, 
                         cornerRadius, 180, 90);
            gPath.AddArc(rectangle.X + rectangle.Width - cornerRadius, 
                         rectangle.Y, cornerRadius, 
                         cornerRadius, 270, 90);
            gPath.AddArc(rectangle.X + rectangle.Width - cornerRadius, 
                         rectangle.Y + rectangle.Height - cornerRadius, 
                         cornerRadius, cornerRadius, 0, 90);
            gPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius, 
                         cornerRadius, cornerRadius, 90, 90);
            gPath.AddLine(rectangle.X, 
                          rectangle.Y + rectangle.Height - cornerRadius, 
                          rectangle.X, rectangle.Y + cornerRadius / 2);
                        
            g.FillPath(brush, gPath);
            g.DrawPath(pen, gPath);
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            mouseHover = false;
            Invalidate();
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            Invalidate();
        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Invalidate();

            if (mouseHover && Click != null)
                Click.Invoke(this, new EventArgs());
        }

        private void UserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            Region region = new Region(gPath);
            if (region.IsVisible(PointToClient(MousePosition)))
            {
                mouseHover = true;
                this.Invalidate();
            }
        }
    }
}
