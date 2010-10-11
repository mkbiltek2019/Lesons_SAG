using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ErrorLoggerServer
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private ErrorServer _errorServer = new ErrorServer();
        private Thread thread = null;

        private void StartServerButton_Click(object sender, EventArgs e)
        {
             this.errorLogListBox.Items.Clear();

            _errorServer.StartServer();
            thread = new Thread(AddText);
            thread.Start();
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            _errorServer.StopServer();
            thread.Join();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private delegate void AddItemToList(string s);
      
        private void AddItemToListBox(string s)
        {
            this.errorLogListBox.Items.Add(s);
        }

        private void AddText()
        {
            while(true)
            {
                this.errorLogListBox.BeginInvoke(new AddItemToList(AddItemToListBox), _errorServer.GetMessage());
                Thread.Sleep(1);
            }
        }

    }
}
