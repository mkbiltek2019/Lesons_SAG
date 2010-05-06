using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebBrouser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://" + textBox1.Text);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox2.Text = webBrowser1.DocumentTitle;
            toolStripStatusLabel1.Text = webBrowser1.StatusText;
            textBox3.Text = webBrowser1.Url.ToString();
            //toolStripProgressBar1.Value = webBrowser1.ProgressChanged;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value += (int)e.CurrentProgress;
            toolStripProgressBar1.Text = e.CurrentProgress.ToString();
        }

       
    }
}
