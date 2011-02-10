using System;
using System.Web.UI.WebControls;
using ChocoPlanet.Business;
using ChocoPlanet.DataAccess;

namespace ChocoPlanet
{
    public partial class ChocolateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnDDListSelectionChanged_Click(object sender, EventArgs e)
        {
            ProductController productController = new ProductController();
            CategoryController categoryController = new CategoryController();

            string category = ((DropDownList)sender).SelectedItem.Text;
            dgProducts.DataSourceID = null;

            if (!string.IsNullOrEmpty(category))
            {
                dgProducts.DataSource = productController.SelectByCategoryId(
                                        categoryController.GetIdByName(category));
            }

            dgProducts.DataBind();
        }

        protected void btnAddToBasket(object sender, CommandEventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Customer") || User.IsInRole("Manager"))
                {
                    int productId = Convert.ToInt32(e.CommandArgument);
                    ServiceLocator.GetType<UserOrderManager>().AddProduct(productId);
                }
            }

        }
    }
}