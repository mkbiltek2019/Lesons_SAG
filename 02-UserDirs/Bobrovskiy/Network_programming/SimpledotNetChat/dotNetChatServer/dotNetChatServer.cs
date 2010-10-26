using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dotNetChatServer.udpServer;
using System.Net;

namespace dotNetChatServer
{
    public partial class dotNetChatServer : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);

        public dotNetChatServer()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            IPAddress ipAddr = IPAddress.Any;// .Parse("127.0.0.1");        

            ChatServer mainServer = new ChatServer(ipAddr);

            // Hook the StatusChanged event handler to mainServer_StatusChanged

            ChatServer.StatusChanged += new Action<string>(mainServer_StatusChanged);

            // Start listening for connections

            mainServer.StartListening();          
        }

        public void mainServer_StatusChanged(string message)
        {
            // Call the method that updates the form
            this.Invoke( new Action<string>(UpdateStatus), message);
        }

        private void UpdateStatus(string strMessage)
        {
            // Updates the log with the message
            connectedUsersListBox.Items.Add(strMessage);
        }


        private void killConnectionButton_Click(object sender, EventArgs e)
        {
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
