using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;

using System.Windows.Forms;

namespace Screen_Breaker
{
    public partial class mainForm : Form
    {
        private Image ShootImage = null;
        private Graphics globalGraphics = null;
        private SoundPlayer Player = new SoundPlayer();

        public mainForm()
        {
            InitializeComponent();
           
            globalGraphics = CreateGraphics();

            this.Player.SoundLocation = "Gun6q01.wav";
            this.Player.LoadAsync();
        }

        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Random rand = new Random();
            ShootImage = imageList.Images[rand.Next(imageList.Images.Count)];
          
            globalGraphics.DrawImage(ShootImage,
                 new Point(e.Location.X - ShootImage.Width / 2, 
                           e.Location.Y - ShootImage.Height / 2));
            if (this.Player.IsLoadCompleted)
            {
                this.Player.Play();
            }

        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(this.Location, new Point(0, 0),
                        new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.C)
            {
                Invalidate();
            }
        }

      
        
    }
}
