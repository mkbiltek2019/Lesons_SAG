using System.Collections.Generic;
using System.Web;
using System.Xml.Linq;
using HttpHandlers.Data;

namespace HttpHandlers.Handlers
{
    public class RssHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            XDocument rssDoc = new XDocument(
                            new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("rss",
                                new XAttribute("version", "2.0"),
                                new XElement("channel", new XElement("title", "Simple RSS"), Elements)
                               ));

            context.Response.ContentType = "text/xml";
            rssDoc.Save(context.Response.Output);
            context.Response.End();
        }

        private IEnumerable<XElement> Elements
        {
            get
            {
                DataStorage ds = DataStorage.GetData(AppGlobal.DataFilePath);
                List<XElement> rss = new List<XElement>();

                foreach (var item in ds.NewsFeed)
                {
                    rss.Add(
                        new XElement("item", 
                            new XElement("title", item.Title), 
                            new XElement("pubDate", item.Date.ToString("r")), 
                            new XElement("description", item.Text))
                        );
                }

                return rss;
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
