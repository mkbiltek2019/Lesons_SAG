using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ErrorLogger_Client
{
    public class TCPLogger : ILogAppender
    {
        private string serverIp = "127.0.0.1";
        private int serverPort = 34348;
        private static object sync = new object();

        public string ServerIP
        {
            get
            {
                return serverIp;
            }
            set
            {
                serverIp = value;
            }
        }

        public int ServerPort
        {
            get
            {
                return serverPort;
            }
            set
            {
                serverPort = value;
            }
        }

        private void SendMessageToServer(string messageToServer)
        {
            lock (sync)
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(serverIp, serverPort);
                    if (socket.Connected)
                    {
                        byte[] buff = Encoding.UTF8.GetBytes(messageToServer);

                        socket.Send(Encoding.UTF8.GetBytes(messageToServer));
                    }
                }
            }
        }

        private string FormatMessage(string format, string message)
        {
            string messageToServer = string.Empty; 

            if (string.IsNullOrEmpty(format))
            {
                messageToServer = message;
            }
            else
            {
                messageToServer = string.Format(format, message);
            }

            return messageToServer;
        }

        #region ILogAppender implementation

        public void Debug(string format, string message)
        {
            SendMessageToServer(FormatMessage(format, message));
        }

        public void Debug(string message)
        {
            Debug(string.Empty, message);
        }

        public void Info(string format, string message)
        {
            SendMessageToServer(FormatMessage(format, message));
        }

        public void Info(string message)
        {
            Info(string.Empty, message);
        }

        public void Fatal(string format, string message)
        {
            SendMessageToServer(FormatMessage(format, message));
        }

        public void Fatal(string message)
        {
            Fatal(string.Empty, message);
        }

        #endregion
    }
}
