using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using dotNetChatClient;

namespace dotNetChatServer.udpServer
{
   public class Connection
    {
        TcpClient tcpClient;
        // The thread that will send information to the client
        private Thread thrSender;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private string currUser;
        private string strResponse;
        private Message strMessage = new Message();
        private object sync = new object();
        // The constructor of the class takes in a TCP connection

        private const string userExistsMessage = "This username already exists.";
        private const string adminNameReserved = "Administrator";
        private const string userNameReserved = "This username is reserved.";
        private const string successfullConnection = "Connected successfully.";
        private const string none = "none";

        public Connection(TcpClient tcpCon)
        {
            tcpClient = tcpCon;
            // The thread that accepts the client and awaits messages
            thrSender = new Thread(AcceptClient);
            // The thread calls the AcceptClient() method
            thrSender.Start();
        }

        private void CloseConnection()
        {
            // Close the currently open objects
            tcpClient.Close();
            srReceiver.Close();
            swSender.Close();
            thrSender.Abort();
           // thrSender.Join();
        }

        // Occures when a new client is accepted
        private void AcceptClient()
        {
            srReceiver = new System.IO.StreamReader(tcpClient.GetStream());
            swSender = new System.IO.StreamWriter(tcpClient.GetStream());
            // Read the account information from the client

            string m = srReceiver.ReadLine();
            strMessage = strMessage.Deserialize(m);

            currUser = strMessage.UserName; // srReceiver.ReadLine();
            // We got a response from the client

            if (IsSuccessfullyConnected()) 
            {
                try
                {
                    // Keep waiting for a message from the user 
                    while (!string.IsNullOrEmpty((strResponse = srReceiver.ReadLine())))
                    {
                        lock (sync)
                        {
                            // If it's invalid, remove the user
                            if (strResponse == null)
                            {
                                ChatServer.RemoveUser(tcpClient);
                            }
                            else
                            {
                                // Otherwise send the message to all the other users                        
                                strMessage = strMessage.Deserialize(strResponse);

                                ChatServer.SendMessage(currUser, strMessage.CurrentMessage);
                            }
                        } 
                    }
                }
                catch
                {
                    // If anything went wrong with this user, disconnect him
                    ChatServer.RemoveUser(tcpClient);
                }

            }

        }

        private bool IsSuccessfullyConnected()
        {
            bool result = false;

            if (!string.IsNullOrEmpty(currUser))
            {
                // Store the user name in the hash table
                if (ChatServer.htUsers.Contains(currUser) == true)
                {
                    strMessage.CurrentMessage = userExistsMessage;
                    strMessage.UserName = currUser;
                    strMessage.FriendName = none;
                    strMessage.NewUser = none;
                    strMessage.PrivateChat = none;
                    strMessage.SmileName = none;
                   
                    swSender.WriteLine(strMessage.Serialize(strMessage));
                    swSender.Flush();
                    CloseConnection();                    
                }
                else if (currUser == adminNameReserved)
                {
                    strMessage.CurrentMessage = userNameReserved;
                    strMessage.UserName = currUser;
                    strMessage.FriendName = none;
                    strMessage.NewUser = none;
                    strMessage.PrivateChat = none;
                    strMessage.SmileName = none;

                    swSender.WriteLine(strMessage.Serialize(strMessage));
                    swSender.Flush();
                    CloseConnection();                    
                }
                else
                {
                    strMessage.CurrentMessage = successfullConnection;
                    strMessage.UserName = currUser;
                    strMessage.FriendName = none;
                    strMessage.NewUser = none;
                    strMessage.PrivateChat = none;
                    strMessage.SmileName = none;

                    swSender.WriteLine(strMessage.Serialize(strMessage));                    
                    swSender.Flush();
                    // Add the user to the hash tables and start listening for messages from him
                    ChatServer.AddUser(tcpClient, strMessage.Serialize(strMessage));
                    result = true;
                }
            }
            else
            {
                CloseConnection();                
            }

            return result;
        }

    }
}
