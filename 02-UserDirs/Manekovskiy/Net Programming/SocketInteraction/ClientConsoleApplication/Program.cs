using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ClientConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Connect("127.0.0.1", 34477);
                
                string messageToServer = "Hello world!";
                char[] buffer = messageToServer.ToCharArray();
                
                socket.Send(Encoding.UTF8.GetBytes(messageToServer));
                Console.WriteLine("Message sent");
            }

            Console.ReadLine();
        }
    }
}
