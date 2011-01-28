using System;
using System.IO;
using System.Web;
using HttpHandlers.Data;

namespace HttpHandlers.Handlers
{
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string fileName = Path.GetFileNameWithoutExtension(context.Request.FilePath);

            DataStorage ds = DataStorage.GetData(AppGlobal.DataFilePath);
            ImageItem img = ds.ImageFeed.Find(i => i.Id == Convert.ToInt32(fileName));

            if (img != null)
            {
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(img.Content);
                context.Response.End();
                return;
            }
            context.Response.StatusCode = 404;
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
