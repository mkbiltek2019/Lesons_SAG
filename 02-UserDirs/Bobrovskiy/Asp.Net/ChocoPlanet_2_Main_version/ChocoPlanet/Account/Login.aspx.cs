using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChocoPlanet.Business;
using ChocoPlanet.DataAccess;

namespace ChocoPlanet.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //create Basket
           ServiceLocator.GetType<UserOrderManager>().CreateBasket();
        }
    }
}
