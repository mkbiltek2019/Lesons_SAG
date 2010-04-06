using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatusStripExample1
{
    public partial class Form1 : Form
    {
        public enum DateTimeFormat { ShowClock, ShowDate };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string str;
            str = DateTime.Now.ToShortDateString();
            this.toolStripStatusLabel1.Text = str;
            str = DateTime.Now.DayOfWeek.ToString();
            this.toolStripMenuItem1.Text = str;

            if (format == DateTimeFormat.ShowClock)
            {
                this.toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
                format = DateTimeFormat.ShowDate;
            }
            else
            {
                this.toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
                format = DateTimeFormat.ShowClock;
            }
        }
    }
}
