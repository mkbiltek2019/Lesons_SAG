using System;

namespace ChocoPlanet.Web
{
    public partial class ChocolateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnDDListSelectionChanged_Click(object sender, EventArgs e)
        {
            //ProductController productController = new ProductController();
            //string category = ((DropDownList)sender).SelectedItem.Text;

            //dgProducts.DataSourceID = null;
            //dgProducts.DataSource = productController.GetAllProducts();
            //dgProducts.DataBind();
        }
    }
}