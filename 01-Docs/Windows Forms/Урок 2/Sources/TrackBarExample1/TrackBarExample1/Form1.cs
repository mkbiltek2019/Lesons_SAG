using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrackBarExample1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateColor();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            Color c = Color.FromArgb(this.trackBar1.Value, this.trackBar2.Value, this.trackBar3.Value);
            this.BackColor = c;
        }
    }
}
