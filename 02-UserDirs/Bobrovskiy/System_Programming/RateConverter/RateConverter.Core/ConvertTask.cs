using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RateConverter.Core
{
    public class ConvertTask
    {
        private Thread thread = null;

        public ConvertTask()
        {
        }

        // private object sync = new object();
        private object sync1 = new object();
        private int index = 2;

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        private void DoTask(object fileName)
        {
            try
            {
                Monitor.TryEnter(sync1, 1000);
                RateFileReader rateFileReader = new RateFileReader();
                List<RateItem> rateItems = rateFileReader.Read(fileName.ToString());

                ExcelApp.Instance.Write(rateItems, index++);
            }
            catch (Exception e)
            {
                LogManager.Instance.PutMessage("ConvertTask.DoTask:> Error: " + e.Message);
            }
            finally
            {
                Monitor.Exit(sync1);
            }
        }

        public void Execute(string fileName)
        {
            thread = new Thread(DoTask);
            thread.Start(fileName);
        }

        public bool IsAlive
        {
            get
            {
                return thread != null && thread.IsAlive;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return !thread.IsAlive;
            }
        }
    }
}
