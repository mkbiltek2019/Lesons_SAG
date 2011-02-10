using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChocoPlanet.Manager
{
    public partial class BasketList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            Session["basketID"] = e.CommandArgument;
            Server.Transfer("UserBasketDetails.aspx");
        }
    }
}