using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocoPlanet.Business.Managers;

namespace ChocoPlanet.Manager
{
    public partial class UserBasketDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["basketID"]);

                dgOrderItems.DataSourceID = null;

                if (id != 0)
                {
                    dgOrderItems.DataSource = basketsManager.GetProductListByBasketID(id);
                }

                dgOrderItems.DataBind();

                Session["basketID"] = 0; //clear session value
            }
        }

        BasketsManager basketsManager = new BasketsManager();

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        { //if this metohd doesn't fireup, need to enable viewstate in <form> 
            Session["orderStatusID"] = e.CommandArgument;
            Server.Transfer("UserBasketItemEdit.aspx");
        }
        
    }
}