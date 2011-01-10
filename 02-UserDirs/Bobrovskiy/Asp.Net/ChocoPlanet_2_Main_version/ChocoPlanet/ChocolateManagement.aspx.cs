using System;
using System.Web.UI.WebControls;
using ChocoPlanet.Business;

namespace ChocoPlanet
{
    public partial class ChocolateManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewCategory_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddNewProduct_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "New":
                    {
                        Server.Transfer("AddCategoryPage.aspx");
                    } break;
                case "Edit":
                    {
                        Session["categoryID"] = e.CommandArgument;
                        Server.Transfer("AddCategoryPage.aspx");
                    } break;
                case "Delete":
                    {
                        CategoryController categoryController = new CategoryController();
                        int id = Convert.ToInt32(e.CommandArgument);
                        categoryController.RemoveCategory(id);
                        Server.Transfer("ChocolateManagement.aspx");
                    } break;
            }
        }
    }
}