using System;
using System.IO;
using System.Net;
using CurrencyConverter.DownloadManager;

namespace MoneyConverServiceWCF.DownloadManager
{
    public class MainDownloadManager : IDownload
    {
        private DateTime currentDate = DateTime.Now;

        public bool Download()
        {
            bool result = false;

            if (currentDate.ToString("d") != DateTime.Now.Date.ToString("d"))
            {
                currentDate = DateTime.Now;

                WebRequest request = WebRequest.Create(Resources.SourceName);
                request.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream stream = response.GetResponseStream();

                const int size = 4096;
                byte[] bytes = new byte[size];
                int numBytes = 0;

                using (
                    FileStream fileStream = new FileStream(Resources.DestinationName, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    while ((numBytes = stream.Read(bytes, 0, size)) > 0)
                    {
                        fileStream.Write(bytes, 0, numBytes);
                    }
                }

                stream.Close();
                response.Close();
                result = true;
            }


            return result;
        }

    }
}