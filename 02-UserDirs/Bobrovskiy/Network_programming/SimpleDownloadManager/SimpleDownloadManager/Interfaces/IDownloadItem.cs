
using System;

namespace SimpleDownloadManager.Interfaces
{
    public enum TaskState
    {
        Start = 1,
        Pause = 2,
        Stop = 3
    }

    public interface IDownloadItem
    {
        string SourceName
        {
            get;
            set;
        }

        string DestinationName
        {
            get;
            set;
        }

        int Persentage
        {
            get;
            set;
        }

        TaskState State
        {
            get; 
            set;
        }
    }
}
