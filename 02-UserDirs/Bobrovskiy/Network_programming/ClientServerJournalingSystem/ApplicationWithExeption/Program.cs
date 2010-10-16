using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErrorLogger_Client;

namespace ApplicationWithExeption
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add initialization for ErrorLogger_Client.Logger
            //Logger.AddAppender(new UdpAppender());

            try
            {
                throw new Exception("1:First Exception");
            }
            catch (Exception e)
            {
                ErrorLogger_Client.Logger.Debug("Something happened");

                LogManager.Core.LogManager.Instance.UseRemoteErrorLogServer = true;
                LogManager.Core.LogManager.Instance.PutMessage(e.Message);
            }

            try
            {
                throw new Exception("2:Second Exception..");
            }catch(Exception e)
            {
                LogManager.Core.LogManager.Instance.UseRemoteErrorLogServer = true;
                LogManager.Core.LogManager.Instance.PutMessage(e.Message);
            }

            try
            {
                throw new Exception("3:Third Exception..");
            }
            catch (Exception e)
            {
                LogManager.Core.LogManager.Instance.UseRemoteErrorLogServer = false;
                LogManager.Core.LogManager.Instance.PutMessage(e.Message);
            }
        }
    }
}
