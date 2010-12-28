using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChocoPlanet.Business;

namespace ChocoPlanet
{
    public partial class ProductEditWindow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateImages();
        }

        private void GenerateImages()
        {
            ImageLoader imageLoader = new ImageLoader();
            imageLoader.GetImagesList();

            foreach (ImageModel image in imageLoader.GetImagesList())
            {
                ListItem item = new ListItem("<img src=\"/images/LoadedImages/" + image.Name + "\" />", image.Name);
                //item.Text = image.Name;
                rblImages.Items.Add(item);
            }
        }
       

    }
}