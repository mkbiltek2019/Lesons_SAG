using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisLib
{
    public class GameItem
    {

        protected Color fore, back;
        protected Point location;
        protected Size size;

        public Color ForeColor
        {
            get { return fore; }
        }

        public Color BackColor
        {
            get { return back;}
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

    }
}
