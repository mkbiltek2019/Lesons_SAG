using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    public class TextArea
    {
        public delegate void TextChangedHandler(object sender, EventArgs e);
        public event TextChangedHandler TextChanged = new TextChangedHandler(TextArea_TextChanged);
        string __text = "";
        public int Pointer { get; set; }
        public string Text 
        {
            get
            {
                return __text;
            }
            set
            {
                __text = value;
                TextChanged(this, new EventArgs());
            }
        }
        static void TextArea_TextChanged(object sender, EventArgs e)
        {
        }
        public virtual void KeyPressEventHeandler(object sender, KeyPressEventArgs arg)
        {
            if ((int)arg.KeyChar == 8)
            {
                if (Text.Length > 0)
                {
                    Text = Text.Remove(Pointer-1, 1);
                    Pointer--;
                }
            }
            else if (!Char.IsControl(arg.KeyChar))
            {
                Text = Text.Insert(Pointer++, arg.KeyChar.ToString());
            }
        }
        public void KeyDownEventHandler(object sender, KeyEventArgs arg)
        {
            switch (arg.KeyData)
            {
                case Keys.Left:
                    if (Pointer > 0)
                        Pointer--;
                    break;
                case Keys.Right:
                    if (Pointer < Text.Length)
                        Pointer++;
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
            }
        }
    }
}
