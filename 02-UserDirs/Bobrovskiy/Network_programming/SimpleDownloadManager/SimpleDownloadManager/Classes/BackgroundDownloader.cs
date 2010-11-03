using System;
using System.ComponentModel;
using SimpleDownloadManager.Interfaces;

namespace SimpleDownloadManager.Classes
{
    public class BackgroundFileLoader : BackgroundWorker
    {
        private Action downloadMethod = null;

        public BackgroundFileLoader(Action currentMethod)
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            downloadMethod = currentMethod;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            e.Result = TaskState.Start;
            try
            {
                downloadMethod.Invoke();
            }
            finally
            {
                e.Result = TaskState.Completed;
            }
        }

    }
}
