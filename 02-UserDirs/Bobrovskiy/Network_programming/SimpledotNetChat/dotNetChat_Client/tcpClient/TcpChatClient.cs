using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Collections;

namespace dotNetChatClient.udpClient
{
    public class TcpChatClient
    {
        private string serverIp = "127.0.0.1";
        private int serverPort = 8080;
        private static object sync = new object();

        private const int maxUsersCountAtTime = 30;

        // This hash table stores users and connections (browsable by user)
        private Hashtable htUsers = new Hashtable(maxUsersCountAtTime);

        private StreamWriter swSender = null;
        private StreamReader srReceiver = null;
        private TcpClient tcpServer = null;
        private Thread thrMessaging = null;
        private IPAddress ipAddr = null;
        private bool Connected = false;

        private const int minSimbolCountInMessage = 1;
        private const string successfullConnection = "Connected Successfully!";
        // private const char one= '1';
        //private const string notConnected = "Not Connected: ";
        private const string notConnected = "Can't read and write to NetworkStreem";

        public event Action<string> UpdateLogCallback = null;
        public event Action<string, string> AddUsersCallback = null;
        public event Action<string> CloseConnectionCallback = null;

        private Message mess = new Message();

        public bool IsConnected
        {
            get
            {
                return Connected;
            }
        }

        public void InitializeConnection(string message, string serverIPAddress)
        {
            if (!string.IsNullOrEmpty(serverIPAddress))
            {
                ipAddr = IPAddress.Parse(serverIPAddress);
            }
            else
            {
                ipAddr = IPAddress.Parse(serverIp);
            }

            // Start a new TCP connections to the chat server
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddr, serverPort);
            // Helps us track whether we're connected or not
            Connected = true;

            //UserName = userName;
            // Send the desired username to the server
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(message);
            swSender.Flush();

            // Start the thread for receiving messages and further communication
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }

        private void AddUser(string userName, string smileName)
        {
            if (!htUsers.Contains(userName))
            {
                htUsers.Add(userName, smileName);
                AddUsersCallback.Invoke(userName, smileName);
            }

        }

        private void ReceiveMessages()
        {
            // Receive the response from the server
            if (ReciveServerResponce())
            {
                // While we are successfully connected, read incoming lines from the server
                AddMessageToListBox();
            }
        }

        private void AddMessageToListBox()
        {
            while (Connected)
            {
                lock (sync)
                {
                    if (Connected == false)
                    {
                        break;
                    }
                    // Show the messages in the log TextBox
                    string message = srReceiver.ReadLine();
                    mess = mess.Deserialize(message);
                    AddUser(mess.UserName, mess.SmileName);

                    UpdateLogCallback.Invoke(mess.CurrentMessage);
                }
            }
        }

        private bool ReciveServerResponce()
        {
            lock (sync)
            {
                bool response = false;

                NetworkStream netstream = tcpServer.GetStream();
                srReceiver = new StreamReader(netstream);

                if (netstream.CanRead && netstream.CanWrite)
                {
                    response = true;
                }
                else
                {
                    CloseConnectionCallback.Invoke(notConnected);
                }

                string message = srReceiver.ReadLine();
                mess = mess.Deserialize(message);
                AddUser(mess.UserName, mess.SmileName);

                return response;
            }
        }

        public void SendMessage(string message)
        {
            if (message.Length >= minSimbolCountInMessage)
            {
                swSender.WriteLine(message);
                swSender.Flush();
            }
        }

        public void CloseConnection()
        {
            // Close the objects
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
            thrMessaging.Abort();
            //thrMessaging.Join();
        }

    }
}
