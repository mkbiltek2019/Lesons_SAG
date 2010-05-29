using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomButtonControlLibrary
{
    public partial class UserControl1 : UserControl
    {
        public new event EventHandler Click;

        private bool mouseHover;
        private bool mouseDown;

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

        #endregion

        public UserControl1()
        {
            InitializeComponent();

            GradientColorStart = SystemColors.Control;
            GradientColorEnd= SystemColors.Control;
            GradientAngle = 1;

            PenThickness = 1;
            PenColor = Color.Black;
            BorderRadius = 1;

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
                    new Point(PenThickness * 2, PenThickness * 2),
                    new Size(this.ClientRectangle.Size.Width - PenThickness * 3, this.ClientRectangle.Size.Height - PenThickness * 3));
            }
            else
            {
                targetRectangle = new Rectangle(
                    new Point(PenThickness, PenThickness),
                    new Size(this.ClientRectangle.Size.Width - PenThickness * 2, this.ClientRectangle.Size.Height - PenThickness * 2));
            }

            Color startColor = GradientColorStart;
            Color endColor = GradientColorEnd;

            if (mouseHover)
            {
                startColor = ControlPaint.Light(startColor, 25f);
                endColor = ControlPaint.Light(endColor, 25f);
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
            GraphicsPath gPath = new GraphicsPath();

            gPath.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            gPath.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            gPath.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            gPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            gPath.AddLine(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius, rectangle.X, rectangle.Y + cornerRadius / 2);
                        
            g.FillPath(brush, gPath);
            g.DrawPath(pen, gPath);
        }

        private void UserControl1_MouseEnter(object sender, EventArgs e)
        {
            mouseHover = true;
            this.Invalidate();
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            mouseHover = false;
            this.Invalidate();
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            this.Invalidate();
        }

        private void UserControl1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Invalidate();

            if (mouseHover && Click != null)
                Click.Invoke(this, new EventArgs());
        }
    }
}
