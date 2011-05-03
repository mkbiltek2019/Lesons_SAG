using System;

namespace DownloadMenager
{
    public class HttpDownloadProgressChangedEventArgs:EventArgs
    {
        public Int64 ReceivedSize { get; private set; }
        public Int64 TotalSize { get; private set; }
        public int DownloadSpeed { get; private set; }
        public int Index { get; private set; }

        public HttpDownloadProgressChangedEventArgs(Int64 receivedSize,
            Int64 totalSize, int downloadSpeed, int index)
        {
            this.ReceivedSize = receivedSize;
            this.TotalSize = totalSize;
            this.DownloadSpeed = downloadSpeed;
            Index = index;
        }
    }
}
