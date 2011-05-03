using System;

namespace DownloadMenager
{
    public class HttpDownloadCompletedEventArgs:EventArgs
    {
        public Int64 DownloadedSize { get; private set; }
        public Int64 TotalSize { get; private set; }
        public Exception Error { get;  private set; }
        public TimeSpan TotalTime { get; private set; }
        public int Index { get; private set; }

        public HttpDownloadCompletedEventArgs(Int64 downloadedSize, 
            Int64 totalSize,TimeSpan totalTime, Exception ex,int index)
        {
            this.DownloadedSize = downloadedSize;
            this.TotalSize = totalSize;
            this.TotalTime = totalTime;
            this.Error = ex;
            this.Index = index;
        }
    }
}
