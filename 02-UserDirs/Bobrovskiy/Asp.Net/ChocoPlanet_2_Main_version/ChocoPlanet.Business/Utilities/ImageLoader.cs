using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ChocoPlanet.Business
{
    public class ImageModel
    {
        public string Path
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class ImageLoader
    {
        private string LoadedImageDirectory = ".\\images\\LoadedImages\\";

        public ICollection GetImagesList()
        {
            List<ImageModel> path = new List<ImageModel>();
            DirectoryInfo dir = new DirectoryInfo(LoadedImageDirectory);

            foreach (FileInfo file in dir.GetFiles("*.jpg"))
            {
                ImageModel imageModel = new ImageModel();
                imageModel.Path = file.DirectoryName;
                imageModel.Name = file.Name;

                path.Add(imageModel);
            }

            return path;
        }
    }
}
