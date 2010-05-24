using System;
using System.Collections.Generic;
using System.IO;

namespace Helper
{
    public class DirectoryFileList
    {
        private readonly int defaultListCapacity = 500;
        private List<DirectoryInfo> directories;
        private List<FileInfo> files;

        public readonly string parent = "--";
        private DirectoryInfo currentDirectory;

        public DirectoryInfo CurrentDirectory
        {
            get
            {
                return currentDirectory;
            }
            set
            {
                currentDirectory = value;
            }
        }

        public DirectoryFileList(DirectoryInfo inititalDirectory)
        {
            currentDirectory = inititalDirectory;
        }

        public List<DirectoryInfo> GetDirectoryList()
        {
            directories = new List<DirectoryInfo>(defaultListCapacity);
            directories.Add(new DirectoryInfo(parent));//add empty string to directory list

            try
            {
                string[] directory = Directory.GetDirectories(CurrentDirectory.FullName);
                for (int i = 0; i < directory.Length; i++)
                {
                    directories.Add(new DirectoryInfo(directory[i]));
                }
            }
            catch (Exception e)
            {
            }

            return directories;
        }

        public List<FileInfo> GetFileList()
        {
            files = new List<FileInfo>(defaultListCapacity);
            try
            {
                string[] file = Directory.GetFiles(CurrentDirectory.FullName);
                for (int i = 0; i < file.Length; i++)
                {
                    files.Add(new FileInfo(file[i]));
                }
            }
            catch (Exception exception)
            {
            }
           
            return files;
        }

    }
}
