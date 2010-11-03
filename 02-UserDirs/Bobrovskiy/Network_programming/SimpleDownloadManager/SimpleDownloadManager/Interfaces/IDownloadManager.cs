using System;

namespace SimpleDownloadManager.Interfaces
{
    public interface IDownloadManager : ITaskManager, IUpdateDownloadTaskEvent
    {
    }
}
