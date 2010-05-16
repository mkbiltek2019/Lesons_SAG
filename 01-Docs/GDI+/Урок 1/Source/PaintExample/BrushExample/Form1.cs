using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PaintExample
{
    public partial class Form1 : Form
    {
        private int paintCount;
        public Form1()
        {
            InitializeComponent();
            paintCount = 0;
            this.Show();
            Graphics g = this.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Rectangle rect = new Rectangle(0, 0, 250, 140);
            g.FillRectangle(redBrush, rect);


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // с помощью этого условия определим зону отсечения
            //   140 и 250 это размеры нашего прямоугольника
            if (e.ClipRectangle.Top < 140 && e.ClipRectangle.Left < 250)
            {
                Graphics g = e.Graphics;
                SolidBrush redBrush = new SolidBrush(Color.Red);
                Rectangle rect = new Rectangle(0, 0, 250, 140);
                g.FillRectangle(redBrush, rect);
               

                this.label1.Text = String.Format("paintCount: {0}", paintCount++);
            }
        }
    }
}
