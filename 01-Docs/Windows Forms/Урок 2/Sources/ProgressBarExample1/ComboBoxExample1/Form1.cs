using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace ProgressBarExample1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            progressBar1.Minimum = 0;           
            progressBar1.Maximum = 50;           
            progressBar1.Step = 1;
           
            for (int i = 0; i <= 50; i++)
            {

                progressBar1.PerformStep();

                label1.Text = "Value = " + progressBar1.Value.ToString();
                this.Update();
                Thread.Sleep(50);
                
            }
        }
    }
}
