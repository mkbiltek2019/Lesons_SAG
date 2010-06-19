using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InteractionWithJavascriptDemo
{
    public partial class MainForm : Form
    {
        Communicator communicator = new Communicator();

        public MainForm()
        {
            InitializeComponent();

            communicator.OnResultReceived += new AddCompletedEventHandler(commucator_OnResultReceived);
            webBrowser.ObjectForScripting = communicator;
        }

        void commucator_OnResultReceived(object sender, decimal result)
        {
            resultTextBox.Text = result.ToString();
        }

        private void goToGoogleButton_Click(object sender, EventArgs e)
        {
            string executablePath = Application.StartupPath;
            string htmlFileName = "SampleHtnlWithJavascript.html";

            webBrowser.Navigate(Path.Combine(executablePath, htmlFileName));
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal a = aNumericUpDown.Value;
            decimal b = bNumericUpDown.Value;

            webBrowser.Document.InvokeScript("add", new object[] { (object)a, (object)b });
        }
    }
}
