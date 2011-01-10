using System;
using System.Drawing.Imaging;

namespace ChocoPlanet.Utilities
{
    public class ThumbImageGenerator
    {
        private const int imageWidth = 70;
        private const int imageHeight = 70;
        private ImageFormat imageFormat = ImageFormat.Jpeg;
        private const string imageFileExtention = ".jpg";
        private const string savePathForThumbnailImages = "images\\LoadedImageThubms\\";
        private const string errorMessage = "Can't generate thumbnail image!";

        public string FilePath
        {//currentPage.Server.MapPath(imageUrl)
            get;
            set;
        }

        public string PhysicalApplicationPath
        {//currentPage.Request.PhysicalApplicationPath
            get; 
            set;
        }

        public ThumbImageGenerator(string filePath, string physicalApplicationPath)
        {
            FilePath = filePath;
            PhysicalApplicationPath = physicalApplicationPath;
        }

        //currentPage.Response.Write("An error occurred - " + ex.ToString());
        public event Action<string> ThumbnailImageGeneratorResponce = null;

        public string GenerateThumbnailImage(string imageUrl)
        {
            //thumbnail creation starts
            string thumbName = string.Empty;
            try
            {
                System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(FilePath);

                System.Drawing.Image.GetThumbnailImageAbort dummyCallBack =
                            new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

                System.Drawing.Image thumbNailImg = fullSizeImg.GetThumbnailImage(imageWidth,
                                                                                  imageHeight,
                                                                                  dummyCallBack,
                                                                                  IntPtr.Zero);

                //We need to create a unique filename for each generated image
                thumbName = GenerateThumbName();
                string newName = PhysicalApplicationPath +
                                 savePathForThumbnailImages +
                                 thumbName;

                //Save the thumbnail in Png format. You may change it to a diff format with the ImageFormat property
                thumbNailImg.Save(newName, imageFormat);

                thumbNailImg.Dispose();
            }

            catch (Exception ex)
            {
                ThumbnailImageGeneratorResponce.Invoke(errorMessage);
            }

            return thumbName;
        }

        private string GenerateThumbName()
        {
            const string dataFormat = "ddMMyyhhmmss";
            DateTime MyDate = DateTime.Now;
            return MyDate.ToString(dataFormat) + imageFileExtention;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        
    }
}