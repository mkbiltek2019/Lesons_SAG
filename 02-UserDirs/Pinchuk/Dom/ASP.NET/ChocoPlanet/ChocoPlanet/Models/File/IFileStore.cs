using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChocoPlanet.Models.File
{
    public interface IFileStore
    {
        string SaveUploadedFile(HttpPostedFileBase fileBase);
        string UploadFolderAbsolute { get; }
    }
}