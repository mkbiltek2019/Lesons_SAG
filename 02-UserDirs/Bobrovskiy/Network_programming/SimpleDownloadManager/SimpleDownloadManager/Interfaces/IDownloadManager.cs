using System;
using System.Collections.Generic;

namespace SimpleDownloadManager.Interfaces
{
    public interface IDownloadManager : ITaskManager, IUpdateDownloadTaskEvent
    {
        List<DownloadItem> DownloadList
        { 
            get;
        }

        DownloadItem SelectedItem
        { 
            get;
            set;
        }
    }
}
