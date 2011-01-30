using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DownloadFileWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DownloadFile_Click(object sender, CommandEventArgs e)
        {
            // имя файла берем из БД по аргументам которые пришли к нам от клиента
            string fileName = "Имя файла.zip";

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

            // расположение файла также берется из БД
            Response.TransmitFile(Server.MapPath("~/files/archive.zip"));
            Response.End();
        }
    }
}