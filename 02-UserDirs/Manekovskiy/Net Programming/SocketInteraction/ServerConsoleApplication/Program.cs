using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace ServerConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(new IPEndPoint(new IPAddress(new byte[] {127, 0, 0, 1}), 34477));
                int maxQueue = 10;
                socket.Listen(maxQueue);

                Socket receiveSocket = socket.Accept();

                int maxMessageSize = 1024; // 1024 bytes
                byte[] buffer = new byte[maxMessageSize];
                receiveSocket.Receive(buffer);

                string message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("Received message: {0}", message);
            }

            Console.ReadLine();
        }
    }
}
