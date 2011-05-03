using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class LogManager
    {
        private static object sync = new object();
        private static LogManager instance = null;
        private static Socket socket;
        public static LogManager Instance
        {
            get
            {
                lock (sync)
                {
                    if (instance == null)
                    {
                        instance = new LogManager();
                    }
                   // using ()
                  //  {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socket.Connect("127.0.0.1", 34477);

                        string messageToServer = "Hello world!";
                        char[] buffer = messageToServer.ToCharArray();

                        
                       // Console.WriteLine("Message sent");
                   // }
                    return instance;
                }
            }

        }

        protected LogManager()
        {
        }

        public void PutMessage(string message)
        {
            lock (sync)
            {
                socket.Send(Encoding.Unicode.GetBytes(message));
               
                //socket.Close();
            }
        } 
    }
}
