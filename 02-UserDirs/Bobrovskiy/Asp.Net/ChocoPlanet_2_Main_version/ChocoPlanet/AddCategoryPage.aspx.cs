using System;
using System.Linq;
using ChocoPlanet.Business;

namespace ChocoPlanet
{
    public partial class AddCategotyPage : System.Web.UI.Page
    {
        private CategoryController categoryController = new CategoryController();
       
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["categoryID"]);

            if (id != null && id != 0)
            {
                categoryController.ModifyCategory(categoryController.GetById(id).Id, 
                                                 this.tbCategoryName.Text,
                                                 this.tbCategoryDescription.Text);
            }else
            {
                categoryController.AddCategory(categoryController.GetAllCategories().Count(),
                                               this.tbCategoryName.Text,
                                               this.tbCategoryDescription.Text);
            }

            Session["categoryID"] = null;
        }

        protected void tbRenderText(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["categoryID"]);

            if (id != null && id != 0)
            {
                this.tbCategoryName.Text = categoryController.GetById(id).Name;
                this.tbCategoryDescription.Text = categoryController.GetById(id).Description;
            }
        }

    }
}