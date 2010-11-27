using System;
using System.ComponentModel;

namespace Background
{
    public class BackgroundMethodExecutor : BackgroundWorker
    {
        public Action Method
        {
            get;
            set;
        }

        private object sync = new object();

        public BackgroundMethodExecutor()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            lock (sync)
            {
                try
                {
                    Method.Invoke();
                }
                catch
                {
                    throw new Exception("Some error in backgroundworker at method execute.");
                }
            }
        }

    }
}
