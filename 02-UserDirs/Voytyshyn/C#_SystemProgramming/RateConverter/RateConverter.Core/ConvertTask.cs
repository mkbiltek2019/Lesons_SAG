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

        private void DoTask(object fileName)
        {
            try
            {
                RateFileReader rateFileReader = new RateFileReader();
                List<RateItem> rateItems = rateFileReader.Read(fileName.ToString());
                ExcelApp.Instance.Write(rateItems);
            }
            catch (Exception e)
            {
                LogManager.Instance.PutMessage("Error: " + e.Message);
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
