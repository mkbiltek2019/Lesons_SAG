using System;
using System.Collections.Generic;
using SimpleDownloadManager.Classes.httpDownload;
using SimpleDownloadManager.Interfaces;

namespace SimpleDownloadManager.Classes
{
    public class HttpDownloadManager : IDownloadManager
    {
        public event Action<List<DownloadItem>> GetDownloadTaskState = null;

        private List<IDownloadTask> downloadTaskList = null;
        private DownloadItem selectedTask = null;

        public List<IDownloadTask> DownloadTaskList
        {
            get
            {
                return downloadTaskList;
            }
        }

        public List<DownloadItem> DownloadList
        {
            get
            {
                List<DownloadItem> downloadList = new List<DownloadItem>();

                foreach (IDownloadTask downloadItem in downloadTaskList)
                {
                    downloadList.Add(downloadItem.CurrentDownloadItem);
                }

                return downloadList;
            }
        }

        public DownloadItem SelectedItem
        {
            get
            {
                return selectedTask;
            }
            set
            {
                selectedTask = value;
            }
        }

        public HttpDownloadManager()
        {
            downloadTaskList = new List<IDownloadTask>();
        }

        public void AddTask(DownloadItem downloadItem)
        {
            IDownloadTask downloadTask = new HttpDownloadTask(downloadItem);
            downloadTask.ReportProgress += new Action<DownloadItem>(downloadTask_ReportProgress);
            downloadTaskList.Add(downloadTask);

            GetDownloadTaskState.Invoke(DownloadList);
        }

        private void downloadTask_ReportProgress(DownloadItem downloadItem)
        {
            for (int i = 0; i < downloadTaskList.Count; i++)
            {
                if (downloadTaskList[i].CurrentDownloadItem.ID.Equals(downloadItem.ID))
                {
                    downloadTaskList[i].CurrentDownloadItem = downloadItem;
                    break;
                }
            }

            GetDownloadTaskState.Invoke(DownloadList);
        }

        public void RemooveTask()
        {
            //remoove selected task
            if (selectedTask != null)
            {
                IDownloadTask temp = null;

                for (int i = 0; i < downloadTaskList.Count; i++)
                {
                    if (downloadTaskList[i].CurrentDownloadItem.ID.Equals(selectedTask.ID))
                    {
                        downloadTaskList[i].Stop();
                        temp = downloadTaskList[i];
                        break;
                    }
                }

                downloadTaskList.Remove(temp);

                GetDownloadTaskState.Invoke(DownloadList);
            }
        }

        public void PauseTask()
        {
            if (selectedTask != null)
            {
                //pause selected task
                for (int i = 0; i < downloadTaskList.Count; i++)
                {
                    if (downloadTaskList[i].CurrentDownloadItem.ID.Equals(selectedTask.ID))
                    {
                        downloadTaskList[i].Pause();
                        break;
                    }
                }

                GetDownloadTaskState.Invoke(DownloadList);
            }
        }

        public void StartTask()
        {
            if (selectedTask != null)
            {
                for (int i = 0; i < downloadTaskList.Count; i++)
                {
                    if (downloadTaskList[i].CurrentDownloadItem.ID.Equals(selectedTask.ID))
                    {
                        downloadTaskList[i].Start();
                        break;
                    }
                }

                GetDownloadTaskState.Invoke(DownloadList);
            }
        }

        public void StopTask()
        {
            if (selectedTask != null)
            {
                //stop selected task
                for (int i = 0; i < downloadTaskList.Count; i++)
                {
                    if (downloadTaskList[i].CurrentDownloadItem.ID.Equals(selectedTask.ID))
                    {
                        downloadTaskList[i].Stop();
                        break;
                    }
                }

                GetDownloadTaskState.Invoke(DownloadList);
            }
        }

    }
}
