using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormColorPlusMessage1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetRandomBackGroundColor();
            MessageBox.Show("Some message", "Simple message on windows startup..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetRandomBackGroundColor()
        {   
            Random random = new Random();
            BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
