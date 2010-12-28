using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocoPlanet.Business;

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
            string category = ((DropDownList) sender).SelectedItem.Text;
            
            dgProducts.DataSourceID = null;
            dgProducts.DataSource = productController.GetListByCategoryName(category);
            dgProducts.DataBind();
        }

        
    }
}