using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadManager.NET
{
    class ListDownloaders
    {
        private List<Downloader> _listDownloaders = new List<Downloader>();
        public List<Downloader> ListDownloader
        {
            set { _listDownloaders = value; }
            get { return _listDownloaders; }
        }
        public void AddDownloader()
        {
            Downloader downloader = new Downloader();
            downloader.StartDownload();
            ListDownloader.Add(downloader);
        }
    }
}
