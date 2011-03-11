using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Diagnostics;

namespace DownloadManager.NET
{
    class Downloader
    {
        private BackgroundWorker bgw = new BackgroundWorker();
        public Download download = new Download();
        private string _sUrl;
        private string _sFilePath;
         
        public string SUrl
        {
            get { return _sUrl; }
            set { _sUrl = value; }
        }
        public string SFilePath
        {
            get { return _sFilePath; }
            set { _sFilePath = value; }
        }
        public void StartDownload()
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            SUrl = form2.Controls[0].Text;
            SFilePath = form2.Controls[7].Text + "/" + form2.Controls[4];
            download.FileName = form2.Controls[4].Text;
            download.UrlDwnload = form2.Controls[0].Text;
            download.Begin = DateTime.Now;
            bgw.RunWorkerAsync();
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
        }
        public void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Uri url = new Uri(_sUrl);
            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            response.Close();
            
            download.FileSize = response.ContentLength;
            download.Completed = 0;
            DateTime dt1 =  DateTime.Now;
            using (WebClient client = new WebClient())
            {
                using (Stream stream = client.OpenRead(new Uri(_sUrl)))
                {
                    using (Stream stream1 = new FileStream(_sFilePath,FileMode.Create,FileAccess.Write,FileShare.None))
                    {
                        int byteSize = 0;
                        byte[] bytes = new byte[byteSize];
                        while ((byteSize = stream.Read(bytes,0,bytes.Length)) > 0)
                        {
                            stream1.Write(bytes, 0, byteSize);
                            download.Completed += byteSize;
                            DateTime dt2 = DateTime.Now;
                            download.Speed = (download.Completed*8)/(dt2 - dt1).TotalSeconds;
                            download.Left = Convert.ToDateTime((download.FileSize - download.Completed)/download.Speed);
                            double dI = (double) download.Completed;
                            double dT = (double) download.FileSize;
                            double dP = (dI/dT);
                            download.Progress = (int) dP*100;
                            if (download.Progress < 100)
                                download.Status = " загружается";
                            else
                            {
                                download.Status = "загружен";
                            }
                            Stopwatch sw = Stopwatch.StartNew();
                            sw.Stop();
                        }
                        stream1.Close();
                    }
                    stream.Close();
                }
            }
        }
    }
}
