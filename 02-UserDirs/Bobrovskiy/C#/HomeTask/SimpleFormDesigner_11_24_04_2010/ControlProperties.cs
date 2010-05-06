using System;
using System.Drawing;

namespace SimpleFormDesigner
{
    [Serializable]
    public class ControlProperties
    {
        public Color BackColor
        {
            get;
            set;
        }

        public Color ForeColor
        {
            get;
            set;
        }

        public Point Location
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Size ControlSize
        {
            get;
            set;
        }

        public int TabIndex
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string ControlType
        {
            get;
            set;
        }
    }
}
