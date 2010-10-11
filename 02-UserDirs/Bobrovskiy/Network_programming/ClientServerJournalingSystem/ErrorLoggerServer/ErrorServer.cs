using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ErrorLoggerServer
{
    public class ErrorServer
    {
        private string serverIp = "127.0.0.1";
        private int serverPort = 34348;

        private int maxQueue = 10;
        private int maxMessageSize = 1024; // 1024 bytes
        private int socketCloseTimeOut = 1000;//miliseconds
        private bool IsClosed = true;

        private static object sync = new object();

        private IPEndPoint endPoint;
        private Socket socket;

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

        public ErrorServer()
        {
            endPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
        }

        public void StartServer()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Bind(endPoint);

            socket.Listen(maxQueue);
            IsClosed = false;
        }

        public string GetMessage()
        {
            lock (sync)
            {
                byte[] buffer = new byte[] { 0 };

                if (socket.IsBound && !IsClosed)
                {
                    Socket receiveSocket = socket.Accept();

                    buffer = new byte[maxMessageSize];
                    receiveSocket.Receive(buffer);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        public void StopServer()
        {
            lock (sync)
            {
                socket.Close();
                IsClosed = true;
            }
        }

    }
}