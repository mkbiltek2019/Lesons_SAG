using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoPlanet.Web
{
    public class BasePage : Page
    {
        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            if (Session["LanguagePreference"] != null)
                UICulture = Context.Session["LanguagePreference"].ToString();
        }
    }
}