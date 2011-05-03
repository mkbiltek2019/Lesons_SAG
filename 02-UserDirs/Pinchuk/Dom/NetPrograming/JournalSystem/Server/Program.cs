using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
           // using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
           // {
           //     //while (socket!=null)
           //     //{
           //         socket.Bind(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 34477));
           //         int maxQueue = 10;
           //         socket.Listen(maxQueue);

           //         Socket receiveSocket = socket.Accept();

           //         int maxMessageSize = 1024; // 1024 bytes
           //         byte[] buffer = new byte[maxMessageSize];
           //         receiveSocket.Receive(buffer);

           //         string message = Encoding.UTF8.GetString(buffer);
           //         Console.WriteLine("Received message: {0}", message); 
           //    // }
           // }

           //// Console.ReadLine();
          
            
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 34477);

            s.Bind(ep);
            s.Listen(10);

            try
            {
                while (true)
                {
                    Socket ns = s.Accept();

                    int maxMessageSize = 1024; // 1024 bytes
                    byte[] buffer = new byte[maxMessageSize];
                    ns.Receive(buffer);
                    string message =BitConverter.ToString(buffer);
                    Console.WriteLine("Received message: {0}", message);


                    Console.WriteLine(ns.RemoteEndPoint.ToString());

                    //ns.Send(System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString()));
                    ns.Shutdown(SocketShutdown.Both);
                    ns.Close();

                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
