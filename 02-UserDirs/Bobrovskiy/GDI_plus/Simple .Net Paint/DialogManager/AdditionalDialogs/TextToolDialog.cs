using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DialogManger.ImageManger;

namespace DialogManger.AdditionalDialogs
{
    public partial class TextToolDialog : Form
    {
        public string TextToDraw
        {
            get;
            set;
        }

        public Font TextFont
        {
            get;
            set;
        }

        public LinearGradientBrush TextGradientBrush
        {
            get;
            set;
        }

        public SolidBrush TextSolidBrush
        {
            get;
            set;
        }

        public bool TextGradientFlag
        {
            get;
            set;
        }

        public Color StartColor
        {
            get;
            set;
        }

        public Color EndColor
        {
            get;
            set;
        }

        public Image ResultImage
        {
            get;
            set;
        }

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

        public TextToolDialog()
        {
            InitializeComponent();
        } 

        public TextToolDialog(string text)
        {
            InitializeComponent();

            this.TextToDraw = text;

            TextFont = new Font("Roman", 20);
            TextGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.Gray, Color.LightCyan, 90);
            TextSolidBrush = new SolidBrush(Color.Black);
            TextGradientFlag = false;

            StartColor = Color.LightGray;
            EndColor = Color.DarkGray;

            this.mainTextBox.Text = text;
            this.gradientCheckBox.Checked = false;

            this.gradientDomainUpDown.Items.Add(LinearGradientMode.BackwardDiagonal);
            this.gradientDomainUpDown.Items.Add(LinearGradientMode.ForwardDiagonal);
            this.gradientDomainUpDown.Items.Add(LinearGradientMode.Horizontal);
            this.gradientDomainUpDown.Items.Add(LinearGradientMode.Vertical);

            Invalidate(true);

        }

        private void SetButton_Click(object sender, EventArgs e)
        { //set data and close form 

            this.TextToDraw = this.mainTextBox.Text;
            this.TextGradientFlag = this.gradientCheckBox.Checked;

            Close();
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.TextFont = fontDialog.Font;
                }
            }
            Invalidate(true);
        }

        private void textColorButton_Click(object sender, EventArgs e)
        {
            this.StartColor = (new ColorDialogManager()).BackGroundColor;
            Invalidate(true);
        }

        private void EndColorButton_Click(object sender, EventArgs e)
        {
            this.EndColor = (new ColorDialogManager()).BackGroundColor;
            Invalidate(true);
        }

        private void TextToolDialog_Paint(object sender, PaintEventArgs e)
        {
            int zoom = (int)this.zoomNumericUpDown.Value;

            Bitmap contents = 
                new Bitmap(mainPanel.Width, mainPanel.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(contents))
            {
                g.Clear(Color.White);
                Rectangle r = mainPanel.ClientRectangle;

                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
               
                int width = (int)(this.TextFont.Size * zoom);
                Size shapeSize = new Size(width, width);

                Point shapeCenter =
                        new Point((int)(mainPanel.Width / 2 - width / 2),
                                  (int)(mainPanel.Height / 2 - width / 2));

                SizeF stringSize = g.MeasureString(this.mainTextBox.Text, TextFont);

                Point center = new Point((int)mainPanel.Width / 2, (int)mainPanel.Height / 2);

                Rectangle rect = new Rectangle(shapeCenter, shapeSize);

                if (textureCheckBox.Checked && CustomBrush != null)
                {
                    TextureBrush textureBrush = new TextureBrush(CustomBrush);
                    textureBrush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                 
                    g.DrawString(this.mainTextBox.Text,
                                 TextFont,
                                 textureBrush,
                                 (int)(center.X - stringSize.Width / 2),
                                 (int)(center.Y - stringSize.Height / 2));
                }

                if (this.gradientCheckBox.Checked && (gradientDomainUpDown.SelectedItem != null))
                {
                    TextGradientBrush
                        = new LinearGradientBrush(rect,
                                                  StartColor,
                                                  EndColor,
                                                  (LinearGradientMode)gradientDomainUpDown.SelectedItem);
                    
                    //TextGradientBrush.SetBlendTriangularShape(0.5f, 1.0f);

                    g.DrawString(this.mainTextBox.Text,
                                 TextFont,
                                 TextGradientBrush,
                                 (int)(center.X - stringSize.Width / 2),
                                 (int)(center.Y - stringSize.Height / 2));

                }

                if (this.SolidCheckBox.Checked)
                {
                    TextSolidBrush = new SolidBrush(StartColor);

                    g.DrawString(this.mainTextBox.Text,
                                 TextFont,
                                 TextSolidBrush,
                                (int)(center.X - stringSize.Width / 2),
                                (int)(center.Y - stringSize.Height / 2));

                }
                ResultImage = contents;
                ((Bitmap)ResultImage).MakeTransparent(Color.White);
            }
        }

        private void zoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void gradientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void mainTextBox_Leave(object sender, EventArgs e)
        {
            Invalidate(true);
            //mainPanel.Invalidate();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(ResultImage, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textureCheckBox.Checked)
            {
                ImageManager imageManager = new ImageManager();
                CustomBrush = imageManager.Open();
                if (CustomBrush != null)
                {
                    this.texturePictureBox.Image = CustomBrush;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(ResultImage!=null)
            {
              ImageManager imageManager = new ImageManager();
              imageManager.Save(ResultImage);
            }
            
        }
    }
}
