using System;
using System.ComponentModel;
using SimpleDownloadManager.Interfaces;

namespace SimpleDownloadManager.Classes
{
    public class BackgroundFileLoader : BackgroundWorker
    {
        private Func<int> downloadMethod = null;

        public BackgroundFileLoader(Func<int> currentMethod)
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
                int porgress = downloadMethod.Invoke();
                ReportProgress(porgress, TaskState.Processing);
            }
            finally
            {
                e.Result = TaskState.Completed;
            }
        }

    }
}
