
namespace SimpleDownloadManager.Interfaces
{
    public interface ITaskManager
    {
        void AddTask(DownloadItem downloadItem);
        void RemooveTask();
        void PauseTask();
        void StartTask();
        void StopTask();
    }
}
