using System;
using System.Windows.Forms;

namespace MDIExample
{
    public class ChildForm : Form
    {
        virtual public DialogResult OpenFile()
        {
            return DialogResult.OK;
        }

        virtual public void SaveFile()
        {
            
        }

        virtual public void SaveFileAs()
        {

        }

   }
}
