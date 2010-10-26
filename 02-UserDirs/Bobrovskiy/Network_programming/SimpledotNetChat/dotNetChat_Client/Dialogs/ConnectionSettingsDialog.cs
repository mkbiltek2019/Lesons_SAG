using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dotNetChatClient.Dialogs
{
    public partial class ConnectionSettingsDialog : Form
    {
        public ConnectionSettingsDialog()
        {
            InitializeComponent();
        }

        public string ServerIPAddress
        {
            get
            {
                return this.serverAddressTextBox.Text;
            }            
        }

        public string ServerPort
        {
            get
            {
                return this.portTextBox.Text;
            }
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
