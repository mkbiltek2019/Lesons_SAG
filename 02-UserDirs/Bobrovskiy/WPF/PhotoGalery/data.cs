using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace PhotoGallery
{
    //NOTICE: to work with large collections you have to use some kind of paging 
    // because you can't store all image in memory if you have a lot of images
 
    public class ImageFile
    {  
        private String _path; 
        private Uri _uri;
        private BitmapFrame _image;

        public String Path
        {
            get 
            { 
                return _path; 
            }
        }

        public Uri Uri 
        { 
            get
            {
                return _uri; 
            } 
        } 

        public BitmapFrame Image
        {
            get
            {
                return _image;
            }
        }

        public ImageFile(string path)
        {
            _path = path;
            _uri = new Uri(_path);
            _image = BitmapFrame.Create(_uri);
        }

        public override string ToString()
        {
            return Path;
        }

    }

    public class PhotoList : ObservableCollection<ImageFile>
    {
        private DirectoryInfo _directory;

        public PhotoList()
        {
        }

        public PhotoList(string path) : this(new DirectoryInfo(path)) { }

        public PhotoList(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }

        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get
            {
                return _directory.FullName;
            }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get
            {
                return _directory;
            }
        }
        
        private void Update()
        {
            foreach (FileInfo f in _directory.GetFiles("*.jpg"))
            {
                Add(new ImageFile(f.FullName));
            }
        }

    }

}
