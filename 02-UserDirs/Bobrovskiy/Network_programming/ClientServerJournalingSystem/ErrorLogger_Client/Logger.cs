using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorLogger_Client
{
    public static class Logger
    {
        private static List<ILogAppender> logAppenders = null;
       
        static Logger()
        {
            Intitalize();
        }

        static void Intitalize()
        {
            logAppenders = new List<ILogAppender>();          
        }

        public static void AddAppender(ILogAppender appender)
        {
            logAppenders.Add(appender);
        }

        public static void Debug(string format, string message)
        {
            foreach (ILogAppender appender in logAppenders)
            {
                appender.Debug(format, message);
            }
        }

        public static void Debug(string message)
        {
            Debug(string.Empty, message);
        }

        public static void Info(string format, string message) 
        {
            foreach (ILogAppender appender in logAppenders)
            {
                appender.Info(format, message);
            }
        }

        public static void Info(string message)
        {
            Info(string.Empty, message);
        }

        public static void Fatal(string format, string message) 
        {
            foreach (ILogAppender appender in logAppenders)
            {
                appender.Fatal(format, message);
            }
        }

        public static void Fatal(string message) 
        {
            Fatal(string.Empty, message);
        }
    }
}
