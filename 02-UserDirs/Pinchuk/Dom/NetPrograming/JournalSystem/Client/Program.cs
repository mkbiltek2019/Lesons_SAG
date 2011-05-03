using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LogManager.Instance.PutMessage("Start program");
                //Console.ReadLine();
                LogManager.Instance.PutMessage("End program");


            }
            catch (Exception exception)
            {
               LogManager.Instance.PutMessage("Error:"+exception.Message);
                
            }
        }
    }
}
