using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ErrorLogger_Client
{
    public class ErrorLogClient
    {
        //TODO: moove serverIP address and port number to app.config file
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

        public void SendMessageToServer(string messageToServer)
        {
            lock (sync)
            {
               // AsyncCallback callBackFunction = new AsyncCallback(EndMessageSend);
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(serverIp, serverPort);
                    if(socket.Connected)
                    {
                        byte[] buff = Encoding.UTF8.GetBytes(messageToServer);

                        //Object openedSocket = new Object();
                        //openedSocket = socket;
                       socket.Send(Encoding.UTF8.GetBytes(messageToServer));
                        //socket.BeginSend(buff, 0, buff.Length,
                        //                 SocketFlags.MaxIOVectorLength,
                        //                 callBackFunction,
                        //                 openedSocket);
                    }

                    //  Send(Encoding.UTF8.GetBytes(messageToServer));
                }
            }
        }

        //private void EndMessageSend(IAsyncResult ar)
        //{
        //    Socket s = (Socket) ar.AsyncState;
        //    s.EndConnect(ar);
        //}
    }
}
