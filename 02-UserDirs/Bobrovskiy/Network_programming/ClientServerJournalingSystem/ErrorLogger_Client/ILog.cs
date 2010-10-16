using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorLogger_Client
{
    public interface ILogAppender
    {
        void Debug(string format, string message);
        void Debug(string message);

        void Info(string format, string message);
        void Info(string message);

        void Fatal(string format, string message);
        void Fatal(string message);
    }

    public static class Logger
    {
        private static List<ILogAppender> logAppenders;

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
            Debug(message, string.Empty);
        }

        public static void Info(string format, string message) { }
        public static void Info(string message) { }

        public static void Fatal(string format, string message) { }
        public static void Fatal(string message) { }
    }
}
