using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TextEditor
{
    public class ScrollDecorator : GraphicsViewDecorator
    {
        VScrollBar VScroll { get; set; }
        public GraphicsView View { get; set; }
        public Panel Parent { get; set; }
        public int Offset { get; set; }
        public ScrollDecorator(GraphicsView view)
        {
            View = view;
            Parent = View.Parent;
            VScroll = new VScrollBar();
            Parent.Controls.Add(VScroll);
            Parent.Resize += Parent_Resize;
            Parent_Resize(this, new EventArgs());
        }

        public void SetScrollHandler(ScrollEventHandler handler)
        {
            VScroll.Scroll += handler;
        }

        void Parent_Resize(object sender, EventArgs e)
        {
            VScroll.Location = new Point(Parent.ClientRectangle.Width - VScroll.Width - View.Offset, View.Offset);
            VScroll.Height = Parent.ClientRectangle.Height - View.Offset*2;
        }

        public int ScrollPosition { get; set; }

        public void ScrollTo(int location)
        {
            ScrollPosition = location;
            Paint(View.Parent.CreateGraphics(),View.Parent.ClientRectangle);
        }
        public void SetScrollRange(int max)
        {
            VScroll.Maximum = max;
        }
        public void Paint(System.Drawing.Graphics e, Rectangle rect)
        {
            View.Paint(e, View.Parent.ClientRectangle);
        }
    }
}
