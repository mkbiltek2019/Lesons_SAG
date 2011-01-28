using System;
using System.IO;

namespace HttpHandlers.Data
{
    public static class AppGlobal
    {
        public static string DataFilePath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Data.xml"); }
        }
    }
}
