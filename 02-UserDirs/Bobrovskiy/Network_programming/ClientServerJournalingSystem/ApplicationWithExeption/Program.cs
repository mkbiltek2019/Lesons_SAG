using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErrorLogger_Client;

namespace ApplicationWithExeption
{

    /// <summary>
    /// For real not big projects better use Dot4Net.dll
    /// usage the same like realized in this home task
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {         
            Logger.AddAppender(new TCPLogger());
            Logger.AddAppender(new FileLogger());

            try
            {
                throw new Exception("1:First debug Exception");
            }
            catch (Exception e)
            {
                Logger.Debug("D: {0}", e.Message);               
            }

            try
            {
                throw new Exception("2:Second Info Exception..");
            }catch(Exception e)
            {
                Logger.Info ("I: {0}", e.Message);            
            }

            try
            {
                throw new Exception("3:Third Fatal Exception..");
            }
            catch (Exception e)
            {
                Logger.Fatal("F: {0}", e.Message);             
            }
        }
    }
}
