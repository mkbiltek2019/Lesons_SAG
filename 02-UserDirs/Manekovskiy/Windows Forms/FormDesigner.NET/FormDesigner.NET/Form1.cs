using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormDesigner.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
            }

            DialogResult result2 = fontDialog1.ShowDialog();
            fontDialog1.Font
            //if(string.IsNullOrEmpty(textBox1.Text))
            //{
            //    Point location = new Point(textBox1.Location.X, textBox1.Location.Y - textBox1.Height);

            //    toolTip.Show("Необхідно заповнити поле textBox1", textBox1, textBox1.PointToClient(splitContainer1.Panel1.PointToScreen(location)));
            //}
        }
    }
}
