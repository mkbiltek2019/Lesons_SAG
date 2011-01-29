using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Web;
using HttpHandlers.Data;

namespace HttpHandlers.Handlers
{
    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string imageDirectory = ConfigurationManager.AppSettings["ImagesDirectory"];
            string fileName = Path.Combine(imageDirectory, Path.GetFileNameWithoutExtension(context.Request.FilePath) + ".jpg");

            try
            {
                byte[] imageBytes = new byte[] { };
                using (var stream = new FileStream(context.Server.MapPath(fileName), FileMode.Open))
                {
                    BinaryReader reader = new BinaryReader(stream);
                    imageBytes = reader.ReadBytes((int)stream.Length);

                    context.Response.ContentType = "image/jpeg";
                    context.Response.Output.Write(imageBytes);
                    context.Response.End();

                    reader.Close();

                    return;
                }
            }
            catch (Exception ex)
            {
                //context.Response.StatusCode = 404;
                throw ex;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
