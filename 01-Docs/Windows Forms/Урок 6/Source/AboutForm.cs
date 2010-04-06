using System;
using System.Windows.Forms;

namespace MDIExample
{
    public partial class AboutForm : ChildForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
