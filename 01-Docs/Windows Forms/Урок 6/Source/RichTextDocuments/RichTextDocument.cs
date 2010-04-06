using System;
using System.Collections.Generic;
using System.Text;

namespace MDIExample
{
    public class RichTextDocument
    {
        public event EventHandler TextChanged;

        private String location = "";
        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        public Boolean isSaved = true;
        public Boolean IsSaved
        {
            get { return isSaved; }
        }

        private String text = "";
        public String Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    isSaved = false;
                    if (TextChanged != null) TextChanged(this, EventArgs.Empty);
                }
            }
        }
    }
}
