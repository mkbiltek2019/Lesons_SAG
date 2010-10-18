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
   
}
