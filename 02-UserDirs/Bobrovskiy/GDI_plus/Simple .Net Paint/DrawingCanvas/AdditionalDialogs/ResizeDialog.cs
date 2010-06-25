using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simple.Net_Paint.AdditionalDialogs
{
    public partial class ResizeDialog : Form
    {
        public int imageWidth;
        public int imageHeight;

        public ResizeDialog()
        {
            InitializeComponent();
        }

        public ResizeDialog(Size currentSize)
        {   
            InitializeComponent();
            imageWidth = currentSize.Width;
            imageHeight = currentSize.Height;
            widthNumericUpDown.Value = imageWidth;
            heightNumericUpDown.Value = imageHeight;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            imageWidth = (int)widthNumericUpDown.Value;
            imageHeight = (int)heightNumericUpDown.Value;
            Close();
        }
    }
}
