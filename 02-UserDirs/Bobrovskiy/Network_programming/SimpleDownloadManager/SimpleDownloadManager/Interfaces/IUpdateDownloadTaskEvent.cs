using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDownloadManager.Interfaces
{
    public interface IUpdateDownloadTaskEvent
    {
        event Action<List<DownloadItem> > GetDownloadTaskState;
    }
}
