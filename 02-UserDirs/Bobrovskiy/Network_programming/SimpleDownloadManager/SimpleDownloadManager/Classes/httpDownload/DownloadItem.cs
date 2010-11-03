
using System;

namespace SimpleDownloadManager.Interfaces
{
    public enum TaskState
    {
        Start = 1,
        Pause = 2,
        Stop = 3,
        Processing = 4,
        Completed = 5
    }

    public class DownloadItem
    {
        private Guid id = Guid.NewGuid();
        
        public Guid ID
        {
            get
            {
                return id;
            }
        }

        public string SourceName
        {
            get;
            set;
        }

        public string DestinationName
        {
            get;
            set;
        }

        public int Persentage
        {
            get;
            set;
        }

        public TaskState State
        {
            get;
            set;
        }
    }
}
