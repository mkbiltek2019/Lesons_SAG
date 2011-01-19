using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxWebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string Method = "method";

            if (!string.IsNullOrWhiteSpace(Request.QueryString[Method]))
            {
                switch(Request.QueryString[Method])
                {
                    case "GetDate":
                        Response.Write(DateTime.Now.ToLongTimeString());
                        Response.End();
                        break;
                }
            }
        }

        protected void GetDateClick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongTimeString();
        }
    }
}