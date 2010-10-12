using System;
using System.Windows.Forms;

namespace SimpleTaskManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetStyle(
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.ResizeRedraw |
               ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.SupportsTransparentBackColor,
               true
               );
        }

        private void UpdateButtonClick(object sender, System.EventArgs e)
        {
            processView.Update();
        }

        private void KillProcessButtonClick(object sender, EventArgs e)
        {
           processView.KillSelectedProcess();
        }

    }
}
