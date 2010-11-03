
using System;

namespace SimpleDownloadManager.Interfaces
{
    public interface IDownloadTask
    {
        event Action<DownloadItem> ReportProgress; 

        DownloadItem CurrentDownloadItem
        {
            get; 
            set;
        }

        void Start();
        void Pause();
        void Stop();
    }
    
}
