using System;
using System.Drawing;
using System.Windows.Forms;
using DialogManger.ImageManger;

namespace DialogManger.AdditionalDialogs
{
    public partial class BrushDialog : Form
    {
        public Image CustomBrush
        {
            get; 
            set;
        }

        public int BrushWidth
        {
            get; 
            set;
        }

        public int BrushHeight
        {
            get;
            set;
        }

        public BrushDialog()
        {
            InitializeComponent();
            if (CustomBrush!=null)
            {
               this.brushPictureBox.BackgroundImage =  CustomBrush;
            }     

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageManager imageManager = new ImageManager();
            CustomBrush = imageManager.Open();
            if (CustomBrush != null)
            {
                this.brushPictureBox.Image = CustomBrush;

                this.widthNumericUpDown.Value = CustomBrush.Width;
                this.heightNumericUpDown.Value = CustomBrush.Height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CustomBrush != null)
            {
                BrushHeight = Convert.ToInt32(this.heightNumericUpDown.Value);
                BrushWidth = Convert.ToInt32(this.widthNumericUpDown.Value);
            }

            Close();
        }
    }
}
