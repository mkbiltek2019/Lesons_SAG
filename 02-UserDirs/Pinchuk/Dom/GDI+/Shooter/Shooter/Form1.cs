using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Shooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.CopyFromScreen(new Point(0, 0),
        new Point(0, 0), new Size(ClientSize.Width, ClientSize.Height));
            graphics.DrawLine(Pens.Aqua, 0, 0, 10, 10);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics graphics = Graphics.FromHwnd(this.Handle);
            Image imagePill = Image.FromFile("pill.png");
            graphics.DrawImage(imagePill, e.X - imagePill.Width / 2, e.Y - imagePill.Height / 2, imagePill.Width, imagePill.Height);
            SoundPlayer simpleSound = new SoundPlayer(@"c:\users\admin\documents\visual studio 2010\Projects\Shooter\Shooter\smallfarrifle2.wav");
            simpleSound.Play();

           

        }
    }
}
