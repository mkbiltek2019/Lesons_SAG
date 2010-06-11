using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Game
{
    public partial class MainForm : Form
    {
        private Size size = new Size();
        private Point point = new Point();
        private Graphics gr;
        public MainForm()
        {
            InitializeComponent();
            
            size.Width = SystemInformation.VirtualScreen.Width;
            size.Height = SystemInformation.VirtualScreen.Height;
            this.Size = size;
         
        }

        

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            gr.CopyFromScreen(this.Location,new Point(0, 0), size);
            
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            point = System.Windows.Forms.Cursor.Position;
            Bitmap bmp = new Bitmap(@"../../Images/4.jpg");
            bmp.MakeTransparent(Color.White);
            TextureBrush tbr = new TextureBrush(bmp);
            g.FillRectangle(tbr, point.X, point.Y, 100, 100);

        }
    }
}
