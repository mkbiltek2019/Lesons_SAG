using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ChocoPlanet.Models.File
{
    internal class DiskFileStore : IFileStore
    {
        private const string uploadFolderAbsolute = "~/Content/Image/Upload/";
        private string _uploadsFolder = HostingEnvironment.MapPath(uploadFolderAbsolute);

        public string UploadFolderAbsolute
        {
            get { return uploadFolderAbsolute; }
        }
        public string SaveUploadedFile(HttpPostedFileBase fileBase)
        {
           
            string diskLocation = GetDiskLocation(fileBase.FileName);
            fileBase.SaveAs(diskLocation);
            return  uploadFolderAbsolute+fileBase.FileName;
        }

        private string GetDiskLocation(string identifier)
        {
            return Path.Combine(_uploadsFolder, identifier);
        }
    }
}