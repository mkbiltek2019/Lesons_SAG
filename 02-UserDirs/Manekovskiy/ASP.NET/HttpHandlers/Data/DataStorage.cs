using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HttpHandlers.Data
{

    [Serializable]
    public class DataStorage
    {
        public List<ImageItem> ImageFeed;
        public List<NewsItem> NewsFeed;

        public static DataStorage GetData(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof (DataStorage));
                return (DataStorage) xml.Deserialize(fs);
            }
        }

        public static void SaveData(string path, DataStorage ds)
        {
            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                XmlSerializer xml = new XmlSerializer(typeof(DataStorage));
                xml.Serialize(fs, ds);
            }
        }
    }

    [Serializable]
    public class NewsItem
    {
        public int Id;
        public string Title;
        public DateTime Date;
        public string Text;
    }

    [Serializable]
    public class ImageItem
    {
        public int Id;
        public byte[] Content;
        public string Title;
    }

}
