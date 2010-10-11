using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using ErrorLogger_Client;

namespace LogManager.Core
{
    public class LogManager
    {
        private string defaultLogFileName = "log.txt";
        private bool useRemoteErrorLogServer = false;

        private static object sync = new object();
        private static LogManager instance = null;
        private ErrorLogClient errorLogClient = new ErrorLogClient();

        public bool UseRemoteErrorLogServer
        { 
            get
            {
                return useRemoteErrorLogServer;
            }
            set
            {
                useRemoteErrorLogServer = value;
            }
        }

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
                    return instance;
                }
            }

        } 

        protected LogManager()
        {
        }

        public void PutMessage(string message)
        {
            if (useRemoteErrorLogServer)
            {
                errorLogClient.SendMessageToServer(message);
            }
            else
            {
                PutMessageToLogFile(message);
            }
        }

        private void PutMessageToLogFile(string message)
        {
            lock (sync)
            {
                using (StreamWriter writer =
                    new StreamWriter(
                        new FileStream(defaultLogFileName, FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine("{0}: {1}", DateTime.Now, message);
                }
            }
        }

       
    }
}
