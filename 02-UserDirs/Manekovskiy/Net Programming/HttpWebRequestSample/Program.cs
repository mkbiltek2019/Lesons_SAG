using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace HttpWebRequestSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient webClient = new WebClient();
            //byte[] downloadData = webClient.DownloadData("http://google.com.ua");

            //string htmlString = webClient.Encoding.GetString(downloadData);
            
            string fileName = string.Format(@"C:\Documents and Settings\manekovskiy\Desktop\ResponceFromGoogle at {0}.html", DateTime.Now.Ticks);

            //File.WriteAllText(fileName, htmlString, webClient.Encoding);

            Console.WriteLine("Спросите у гугля(google.com.ua):");

            string requestString = Console.ReadLine();
            string requestUrl = string.Format("google.com/search?num=39&q={0}&btnG=Search", HttpUtility.UrlEncode(requestString));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new UriBuilder(requestUrl).ToString());
            request.Method = "GET";
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();

            using (Stream responseStream = responce.GetResponseStream())
            {
                using (TextReader textReader = new StreamReader(responseStream))
                {
                    string htmlString = textReader.ReadToEnd();
                    Console.Write(htmlString);
                    File.WriteAllText(fileName, htmlString, Encoding.GetEncoding(responce.CharacterSet));
                }
            }
        }
    }
}
