using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using dotNetChatClient;
using System.Net;
using System.Collections;
using System.Threading;
using System.IO;

namespace dotNetChatServer.udpServer
{
    public class ChatServer
    {
        //  private string serverIp = "127.0.0.1";
        private int serverPort = 8080;
        private static object sync = new object();
        private const int maxUsersCountAtTime = 30;

        // This hash table stores users and connections (browsable by user)
        public static Hashtable htUsers = new Hashtable(maxUsersCountAtTime); // 30 users at one time limit
        // This hash table stores connections and users (browsable by connection)
        public static Hashtable htConnections = new Hashtable(maxUsersCountAtTime); // 30 users at one time limit
        public static Hashtable htUserNameSmileName = new Hashtable(maxUsersCountAtTime); // 30 users at one time limit
        // Will store the IP address passed to it
        private IPAddress ipAddress = null;
        private TcpClient tcpClient = null;

        // The event and its argument will notify the form when a user has connected, disconnected, send message, etc.
        public static event Action<string> StatusChanged;
        public static event Action<string, string> UserStatusChanged;

        // The thread that will hold the connection listener
        private Thread thrListener;
        // The TCP object that listens for connections
        private TcpListener tlsClient;
        // Will tell the while loop to keep monitoring for connections
        bool ServRunning = false;
        // Add the user to the hash tables

        private const string userJoinUs = " has joined us";
        private const string userLeftUs = " has left us";
        private const string administrator = "Administrator: ";
        private const string say = " says: ";
        private const string none = "none";

        private static Message message = new Message();

        // The constructor sets the IP address to the one retrieved by the instantiating object
        public ChatServer(IPAddress address)
        {
            ipAddress = address;
        }

        public static void AddUser(TcpClient tcpUser, string curentMessage)
        {
            // First add the username and associated connection to both hash tables            
            message = message.Deserialize(curentMessage);

            ChatServer.htUsers.Add(message.UserName, tcpUser);
            ChatServer.htConnections.Add(tcpUser, message.UserName);
            ChatServer.htUserNameSmileName.Add(message.UserName, message.SmileName);

            OnUserStatusChanged(message.UserName, message.SmileName);
            // Tell of the new connection to all other users and to the server form
            SendAdminMessage(htConnections[tcpUser] + userJoinUs, (string)htConnections[tcpUser]);
        }

        // Remove the user from the hash tables
        public static void RemoveUser(TcpClient tcpUser)
        {
            if (htConnections.Count > 0)
            {
                string uname = htConnections[tcpUser].ToString();

                htUsers.Remove(htConnections[tcpUser]);
                htConnections.Remove(tcpUser);
                SendAdminMessage(uname + userLeftUs, uname);
            }
        }

        // This is called when we want to raise the StatusChanged event
        public static void OnStatusChanged(string status)
        {
            StatusChanged.Invoke(status);
        }

        public static void OnUserStatusChanged(string name, string imageName)
        {
            UserStatusChanged.Invoke(name, imageName);
        }

        // Send administrative messages
        public static void SendAdminMessage(string currentMessage, string userName)
        {
            string format = administrator + "{0}";

            string result = string.Format(format, currentMessage);
            OnStatusChanged(result);

            message.CurrentMessage = result;
            message.UserName = userName;
            if (htUserNameSmileName.Contains(userName)) 
            {
                message.SmileName = (string)htUserNameSmileName[userName];
            }

            message.FriendName = none;
            message.NewUser = none;
            message.PrivateChat = none;

            SendMessageToAllClients(currentMessage, message.Serialize(message));
        }

        // Send messages from one user to all the others
        public static void SendMessage(string currentUser, string currentMessage)
        {
            string format = currentUser + say + "{0}";

            string result = string.Format(format, currentMessage);
            OnStatusChanged(result);

            message.CurrentMessage = result;
            message.UserName = currentUser;
            if (htUserNameSmileName.Contains(currentUser))
            {
                message.SmileName = (string)htUserNameSmileName[currentUser];
            }

            message.FriendName = none;
            message.NewUser = none;
            message.PrivateChat = none;


            SendMessageToAllClients(currentMessage, message.Serialize(message));
        }

        private static void SendMessageToAllClients(string format, string currentMessage)
        {
            lock (sync)
            {
                //message = message.Deserialize(currentMessage);

                //string result = string.Format(format, currentMessage);                

                StreamWriter swSenderSender = null;
                TcpClient[] tcpClients = new TcpClient[ChatServer.htUsers.Count];
                // Copy the TcpClient objects into the array
                ChatServer.htUsers.Values.CopyTo(tcpClients, 0);
                // Loop through the list of TCP clients

                for (int i = 0; i < tcpClients.Length; i++)
                {
                    // Try sending a message to each
                    try
                    {
                        // If the message is blank or the connection is null, break out
                        if (string.IsNullOrEmpty(format.Trim()) || tcpClients[i] == null)
                        {
                            continue;
                        }
                        // Send the message to the current user in the loop
                        swSenderSender = new StreamWriter(tcpClients[i].GetStream());

                       // message.CurrentMessage = result;
                       // message.UserName = htConnections[tcpClients[i]].ToString();
                       // //if (htUserNameSmileName.Contains(message.UserName)) 
                       //// {
                       //     message.SmileName = (string)htUserNameSmileName[message.UserName];
                       // //}
                        
                       // message.FriendName = none;
                       // message.NewUser = none;
                       // message.PrivateChat = none;


                        swSenderSender.WriteLine(currentMessage);
                        swSenderSender.Flush();
                        swSenderSender = null;
                    }
                    catch // If there was a problem, the user is not there anymore, remove him
                    {
                        RemoveUser(tcpClients[i]);
                    }
                }

            }
        }

        public void StartListening()
        {
            // Get the IP of the first network device, however this can prove unreliable on certain configurations
            IPAddress ipaLocal = ipAddress;
            // Create the TCP listener object using the IP of the server and the specified port
            if (!ServRunning)
            {
                tlsClient = new TcpListener(ipaLocal, serverPort);
                // Start the TCP listener and listen for connections

                tlsClient.Start();
                // The while loop will check for true in this before checking for connections
                ServRunning = true;
                // Start the new tread that hosts the listener
                thrListener = new Thread(KeepListening);
                thrListener.Start();
            }
        }

        private void KeepListening()
        {
            // While the server is running
            while (ServRunning == true)
            {
                // Accept a pending connection
                tcpClient = tlsClient.AcceptTcpClient();
                // Create a new instance of Connection
                Connection newConnection = new Connection(tcpClient);
            }
        }

    }
}
