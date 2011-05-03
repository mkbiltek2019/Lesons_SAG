using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadMenager.Core
{
    static class DataSender
    {
        public delegate Dictionary<string ,string > DownloadDataEvent();
        public static DownloadDataEvent DownloadDataEventHendler;
    }
}
