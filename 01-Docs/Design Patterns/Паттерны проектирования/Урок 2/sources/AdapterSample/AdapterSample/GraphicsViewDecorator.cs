using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    public interface GraphicsViewDecorator : GraphicsView
    {
        GraphicsView View { get; set; }
    }
}
