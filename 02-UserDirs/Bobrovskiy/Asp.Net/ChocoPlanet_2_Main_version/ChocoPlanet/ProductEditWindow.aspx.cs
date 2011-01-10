using System;
using System.IO;
using System.Linq;
using ChocoPlanet.Business;
using ChocoPlanet.Utilities;

namespace ChocoPlanet
{
    public partial class ProductEditWindow : System.Web.UI.Page
    {
        private ProductController productController = new ProductController();
        private CategoryController categoryController = new CategoryController();
        private string mainImgUrl = string.Empty;
        private string thumbImgUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //private void GenerateThumbnailImage(string imageUrl)
        //{
        //    const int imageWidth = 70;
        //    const int imageHeight = 70;
        //    ImageFormat imageFormat = ImageFormat.Jpeg;
        //    const string imageFileExtention = ".jpg";
        //    const string savePathForThumbnailImages = "images\\LoadedImageThubms\\";
        //    //thumbnail creation starts
        //    try
        //    {
        //        System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imageUrl));

        //        System.Drawing.Image.GetThumbnailImageAbort dummyCallBack =
        //                    new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

        //        System.Drawing.Image thumbNailImg = fullSizeImg.GetThumbnailImage(imageWidth,
        //                                                                          imageHeight,
        //                                                                          dummyCallBack,
        //                                                                          IntPtr.Zero);

        //        //We need to create a unique filename for each generated image
        //        //TODO: extract method imageUniqueNameGenerator
        //        DateTime MyDate = DateTime.Now;
        //        string MyString = MyDate.ToString("ddMMyyhhmmss") + imageFileExtention;

        //        //Save the thumbnail in Png format. You may change it to a diff format with the ImageFormat property
        //        thumbNailImg.Save(Request.PhysicalApplicationPath + savePathForThumbnailImages + MyString,
        //                          imageFormat);

        //        thumbNailImg.Dispose();
        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Write("An error occurred - " + ex.ToString());
        //    }
        //}

        //public bool ThumbnailCallback()
        //{
        //    return false;
        //}

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //TODO: make own fileUpload control
            const int maxFileSize = 512000;
            const string imageFileType = "image/jpeg";
            const string storeFilePath = "~/images/LoadedImages/";
            const string storeThumbPath = "~/images/LoadedImageThubms/";
            const string errorMessage = "Upload status: The file could not be uploaded. The following error occured: ";
            const string mainImgSession = "mainImgUrl";
            const string thumbImgSession = "thumbImgUrl";

            if (fuImage.HasFile)
            {
                try
                {
                    if (fuImage.PostedFile.ContentType == imageFileType)
                    {
                        if (fuImage.PostedFile.ContentLength < maxFileSize)
                        {
                            string filename = Path.GetFileName(fuImage.FileName);
                            fuImage.SaveAs(Server.MapPath(storeFilePath) + filename);
                            imgMainImage.ImageUrl = storeFilePath + filename;

                            ThumbImageGenerator thumbImageGenerator =
                                            new ThumbImageGenerator(Server.MapPath(imgMainImage.ImageUrl),
                                                                    Request.PhysicalApplicationPath);
                            thumbImageGenerator.ThumbnailImageGeneratorResponce +=
                                            new Action<string>(thumbImageGenerator_ThumbnailImageGeneratorResponce);
                            this.imgThumbImage.ImageUrl = storeThumbPath +
                                            thumbImageGenerator.GenerateThumbnailImage(imgMainImage.ImageUrl);

                            Session[mainImgSession] = imgMainImage.ImageUrl;
                            Session[thumbImgSession] = this.imgThumbImage.ImageUrl;
                        }
                        else
                        {
                        }
                        // StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                    {
                    }
                    // StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    Response.Write(errorMessage + ex.Message);
                }
            }

        }

        void thumbImageGenerator_ThumbnailImageGeneratorResponce(string obj)
        {
            Page.Response.Write(obj);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int catId = categoryController.GetIdByName(ddlProductCategory.SelectedValue);
            const string mainImgSession = "mainImgUrl";
            const string thumbImgSession = "thumbImgUrl";

            productController.AddProduct(
               productController.GetAllProducts().Count() + 1,
               catId,
               this.tbName.Text,
               this.tbDescription.Text,
               Session[mainImgSession].ToString().Substring(2),
               Session[thumbImgSession].ToString().Substring(2),
               Convert.ToDouble(this.tbPrice.Text),
               Convert.ToDateTime(this.tbPlacementDate.Text)
               );
            // TODO:modify this:( from imageUrl must be removed leading ~/ for that porpouse used .Substring(2))

            Session[mainImgSession] = string.Empty;
            Session[thumbImgSession] = string.Empty;
        }
    }
}