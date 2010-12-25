using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace ChocoPlanet.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void OnChangeCultureCommand(object sender, CommandEventArgs e)
        {
            Context.Session["LanguagePreference"] = e.CommandArgument.ToString();
            Response.Redirect(Page.AppRelativeVirtualPath);
        }
    }
}
