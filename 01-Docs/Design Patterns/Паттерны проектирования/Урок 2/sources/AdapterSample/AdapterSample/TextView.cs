using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    public class TextView : TextArea, GraphicsView
    {
        public Panel Parent { get; set; }
        public int Offset { get; set; }
        private Font TextFont { get; set; }
        public TextView(string Text, Panel parent)
            :base()
        {
            Parent = parent;
            this.Text = Text;
            TextFont = new Font("Verdana", 10, FontStyle.Regular);
        }
        public SizeF GetBoundingRect(Graphics e)
        {
            return e.MeasureString(Text, TextFont, Parent.ClientRectangle.Width, StringFormat.GenericDefault);
        }
        public void DrawText(Graphics e,Rectangle rect)
        {
            e.DrawString(Text, TextFont, Brushes.Black, new Rectangle(rect.X, rect.Y - Offset, rect.Width, rect.Height + Offset));
        }
        public void Paint(System.Drawing.Graphics e,Rectangle updateRectangle)
        {
            DrawText(e, updateRectangle);
        }
    }
}
