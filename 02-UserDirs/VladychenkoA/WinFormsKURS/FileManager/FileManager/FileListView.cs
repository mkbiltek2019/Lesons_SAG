using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager
{
    public class FileListView
    {
        List<DirectoryInfo> directories;
        List<FileInfo> files;
        private DirectoryInfo currentDirectory;
        private ListView listView;
        private ImageList smallImageList;
        private ImageList bigImageList;

        public DirectoryInfo CurrentDirectory
        {
            get { return currentDirectory; }
            set { currentDirectory = value; }
        }

        public ListView ListView
        {
            get { return listView; }
            set { listView = value; }
        }

        public ImageList SmallImageList
        {
            set { smallImageList = value; }
            get { return smallImageList; }
        }

        public ImageList BigImmageList
        {
            set { bigImageList = value; }
            get { return bigImageList; }
        }

        public FileListView(string root)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(root);
                CurrentDirectory = directoryInfo;
                string[] directoryNames = Directory.GetDirectories(CurrentDirectory.FullName);
                string[] fileNames = Directory.GetFiles(CurrentDirectory.FullName);

                directories = new List<DirectoryInfo>();
                files = new List<FileInfo>();
                smallImageList.Images.Add(new Icon(GetType(), "Resources.3.ico"));
                bigImageList.Images.Add(new Icon(GetType(), "Resources.2.ico"));
               
                smallImageList.Images.SetKeyName(0, "3.ico");
                bigImageList.Images.SetKeyName(0, "2.ico");

                foreach (string directoryName in directoryNames)
                {
                    directories.Add(new DirectoryInfo(directoryName));
                }

                foreach (string fileName in fileNames)
                {
                    files.Add(new FileInfo(fileName));
                }

                foreach (DirectoryInfo directory in directories)
                {
                    listView.Items.Add(new ListViewItem(new string[] { directory.Name, string.Empty, directory.CreationTime.ToString(), directory.LastWriteTime.ToString() },0));

                }

                foreach (FileInfo file in files)
                {
                    Icon icon = Icon.ExtractAssociatedIcon(file.FullName);
                    smallImageList.Images.Add(file.Name, icon);
                    bigImageList.Images.Add(file.Name, icon);
                    listView.Items.Add(new ListViewItem(new string[] { file.Name, file.Length.ToString(), file.CreationTime.ToString(), file.LastWriteTime.ToString() }, file.Name));
                } 
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message); 
            }
        }
    }
}
