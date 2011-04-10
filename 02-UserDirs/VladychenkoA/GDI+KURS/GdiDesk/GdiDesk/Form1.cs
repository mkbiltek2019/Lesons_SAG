using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace GdiDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.CopyFromScreen(new Point(0,0),new Point(0,0),new Size(ClientSize.Width, ClientSize.Height));
            graphics.DrawLine(Pens.Azure, 0, 0, 10, 10);
        }

      

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer("gun1.wav");
            soundPlayer.Play();
            Graphics graphics = Graphics.FromHwnd(Handle);
            Image image = Image.FromFile("pill.png");
            graphics.DrawImage(image, e.X - image.Width / 2, e.Y - image.Height / 2, image.Width, image.Height);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
