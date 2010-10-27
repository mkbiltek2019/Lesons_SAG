using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dotNetChatClient.Dialogs;
using dotNetChatClient.udpClient;
using System.Threading;

namespace dotNetChatClient
{
    public partial class dotNetChatClient : Form
    {
        public dotNetChatClient()
        {
            InitializeComponent();           
        }

        private TcpChatClient chatClient = null;
        private Message message = new Message();

        private void AddMessageToList(string message)
        {
            this.messageLogListBox.BeginInvoke(new Action<string>(AddListItem), message);
        }       

        private void AddListItem(string text)
        {
            this.messageLogListBox.Items.Add(text);
        }        
        
        private void setConnetionParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionSettingsDialog connectionDialog = new ConnectionSettingsDialog();
            connectionDialog.ShowDialog();
            CurrentUserData.ServerIpAddress = connectionDialog.ServerIPAddress;
            CurrentUserData.ServerPort = connectionDialog.ServerPort;
        }

        private void setUserDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettingsDialog connectionSettingsDialog = new UserSettingsDialog();
            connectionSettingsDialog.ShowDialog();
            CurrentUserData.UserName = connectionSettingsDialog.UserName;
            CurrentUserData.SmileImagePath = connectionSettingsDialog.SaveFileName;

            this.nameLabel.Text = CurrentUserData.UserName;
            this.smilePictureBox.ImageLocation = connectionSettingsDialog.ImagePath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (chatClient == null) 
            {
                chatClient = new TcpChatClient();

                message.UserName = CurrentUserData.UserName;
                message.SmileName = CurrentUserData.SmileImagePath;
                message.CurrentMessage = "connect";               
                message.FriendName = "none";
                message.PrivateChat = "none";
                message.NewUser = "old";         

                string buffer = message.Serialize(message);

                chatClient.InitializeConnection(buffer, CurrentUserData.ServerIpAddress);

                chatClient.CloseConnectionCallback += new Action<string>(AddMessageToList);
                chatClient.UpdateLogCallback += new Action<string>(AddMessageToList);
                chatClient.AddUsersCallback += new Action<string, string>(UserStatusChanged);
               
            }            
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (chatClient.IsConnected)
            {
                chatClient.CloseConnection();
            }
        }

        private void privateChatButton_Click(object sender, EventArgs e)
        {
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            message.UserName = CurrentUserData.UserName;
            message.SmileName = CurrentUserData.SmileImagePath;
            message.CurrentMessage = messageTextBox.Text;
            message.FriendName = "none";
            message.PrivateChat = "none";
            message.NewUser = "old";
         
            string buffer = message.Serialize(message);

            if (chatClient.IsConnected) 
            {
                chatClient.SendMessage(buffer);
            }            
        }

        private void UserStatusChanged(string name, string smile)
        {
            this.Invoke(new Action<string, string>(AddUsers), name, smile);
        }

        private void AddUsers(string name, string smile)
        {
            userImageListBox.AddUserToFile(name, smile);
            userImageListBox.LoadDataFromFile();
        }
        
    }
}
