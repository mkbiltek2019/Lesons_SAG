using System;
using System.Collections;
using System.Collections.Generic;
using SimpleDownloadManager.Classes.httpDownload;
using SimpleDownloadManager.Interfaces;

namespace SimpleDownloadManager.Classes
{
    public class HttpDownloadManager : IDownloadManager
    {
        //TODO: синхронізувати datagridview зі списком за допомогою подій DownloadItemList
        public event Action<List<IDownloadTask> > GetDownloadTaskState;

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
                List<DownloadItem> list = new List<DownloadItem>();
                foreach (IDownloadTask downloadItem in downloadTaskList)
                {
                    list.Add(downloadItem.CurrentDownloadItem);
                }

                return list;
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
            downloadTask.ReportProgress +=new Action<DownloadItem>(downloadTask_ReportProgress);
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
            //remooove selected task
	    IDownloadTask temp = null;

            for (int i = 0; i < downloadTaskList.Count; i++)
            {
                if  (downloadTaskList[i].CurrentDownloadItem.ID.Equals(selectedTask.ID))
                {
                    downloadTaskList[i].Stop();
			temp = downloadTaskList[i];
		    break;
                   // downloadTaskList.Remove(downloadTaskList[i]);
                }
            }
		downloadTaskList.Remove(temp);

            GetDownloadTaskState.Invoke(DownloadList);
        }

        public void PauseTask()
        {
            //pause selected task
            for (int i = 0; i < downloadTaskList.Count; i++)
            {
                if (downloadTaskList[i].CurrentDownloadItem.ID.Equals(selectedTask.ID))
                {
                    downloadTaskList[i].Pause();

                    downloadTaskList.Remove(downloadTaskList[i]);
		    break;
                }
            }

            GetDownloadTaskState.Invoke(DownloadList);
        }

        public void StartTask()
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

        public void StopTask()
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
