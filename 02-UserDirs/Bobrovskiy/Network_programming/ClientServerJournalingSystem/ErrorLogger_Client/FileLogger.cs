using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ErrorLogger_Client
{
    public class FileLogger : ILogAppender
    {
        private string defaultLogFileName = "log.txt";
        private static object sync = new object();

        private void PutMessageToLogFile(string message)
        {
            lock (sync)
            {
                using (StreamWriter writer =
                    new StreamWriter(
                        new FileStream(defaultLogFileName, FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine(message);
                }
            }
        }

        private string FormatMessage(string format, string message)
        {
            string messageToServer = string.Empty;

            if (string.IsNullOrEmpty(format))
            {
                messageToServer = message;
            }
            else
            {
                messageToServer = string.Format(format, message);
            }

            return messageToServer;
        }

        #region ILogAppender implemantation

        public void Debug(string format, string message)
        {
            PutMessageToLogFile(FormatMessage(format, message));
        }

        public void Debug(string message)
        {
            Debug(string.Empty, message);
        }

        public void Info(string format, string message)
        {
            PutMessageToLogFile(FormatMessage(format, message));
        }

        public void Info(string message)
        {
            Info(string.Empty, message);
        }

        public void Fatal(string format, string message)
        {
            PutMessageToLogFile(FormatMessage(format, message));
        }

        public void Fatal(string message)
        {
            Fatal(string.Empty, message);
        }

        #endregion
    }
}
