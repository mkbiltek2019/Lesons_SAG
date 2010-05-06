using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Webbrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void goToolStripButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://" + toolStripTextBox1.Text);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
            tabPage1.Text = webBrowser1.DocumentTitle;
            toolStripStatusLabel1.Text = webBrowser1.StatusText;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = (int) e.CurrentProgress;
        }

        private void prewToolStripButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void nextToolStripButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void refrenchToolStripButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);
        }

       

       
    }
}
