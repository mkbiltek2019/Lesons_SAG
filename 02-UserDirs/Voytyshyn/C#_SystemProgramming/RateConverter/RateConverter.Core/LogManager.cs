using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RateConverter.Core
{
    public class LogManager
    {
        private static object sync = new object();
        private static LogManager instance = null; 

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
            lock (sync)
            {
                using (StreamWriter writer =
                    new StreamWriter(
                        new FileStream("log.txt", FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine("{0}: {1}", DateTime.Now, message);
                }
            }
        } 
    }
}
