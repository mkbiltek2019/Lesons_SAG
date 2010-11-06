using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    public interface GraphicsView
    {
        Panel Parent { get; set; }
        int Offset { get; set; }
        void Paint(System.Drawing.Graphics e, Rectangle updateRectangle);
    }
}
