using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    public class BorderDecorator : GraphicsViewDecorator
    {
        public GraphicsView View { get; set; }
        public Panel Parent { get; set; }
        public int Offset { get; set; }
        
        public BorderDecorator(GraphicsView view)
        {
            View = view;
            Parent = View.Parent;
            BorderWidth = 2;
            Offset += BorderWidth;
        }
        public int BorderWidth { get; set; }

        public void Paint(System.Drawing.Graphics e, Rectangle rect)
        {
            View.Paint(e, View.Parent.ClientRectangle);
            DrawBorder(e);
        }

        public void DrawBorder(Graphics e)
        {
            e.DrawRectangle(new Pen(Brushes.LightGray,BorderWidth), Parent.ClientRectangle);
        }
    }
}
