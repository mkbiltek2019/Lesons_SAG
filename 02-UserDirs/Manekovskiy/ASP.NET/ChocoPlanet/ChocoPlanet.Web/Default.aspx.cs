using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoPlanet.Web
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ChangeResponceButton_Click(object sender, EventArgs e)
        {
            //HtmlTextWriter responceWriter = new HtmlTextWriter(Response.Output);
            //responceWriter.BeginRender();
            //responceWriter.RenderBeginTag(HtmlTextWriterTag.Img);

            //responceWriter.AddAttribute(HtmlTextWriterAttribute.Src, "/images/flags/ua.png");

            //responceWriter.RenderEndTag();
            //responceWriter.EndRender();
        }
    }
}
