using System;
using System.Web.UI.WebControls;
using ChocoPlanet.Business;
using ChocoPlanet.DataAccess;

namespace ChocoPlanet.Customer
{
    public partial class CustomerBasket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dgProducts.DataSourceID = null;
            dgProducts.DataSource = ServiceLocator.GetType<UserOrderManager>().GetAllProductsInBasket();
            dgProducts.DataBind();
        }

        protected void btnRemoveFromBasket(object sender, CommandEventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Customer") || User.IsInRole("Manager"))
                {
                    int productId = Convert.ToInt32(e.CommandArgument);
                    ServiceLocator.GetType<UserOrderManager>().DeleteProduct(productId);
                }
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            ServiceLocator.GetType<UserOrderManager>().PlaceOrder(User.Identity.Name);
        }
    }
}