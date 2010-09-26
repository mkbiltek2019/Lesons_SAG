using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FileSearch
{
    class Searcher
    {
        private object sync = new object();

        public Searcher(string fileMask)
        {
            this.fileMask = fileMask;
        }

        private string fileMask;
        public string FileMask
        {
            get
            {
                return fileMask;
            }
            set
            {
                if (!IsRunning)
                {
                    this.fileMask = value;
                }
                else
                {
                    throw new Exception("Can not modify File Mask: searching is running");
                }
            }
        }

        private int _fileCount;
        public int FileCount
        {
            get
            {
                if (IsCompleted)
                {
                    return _fileCount;
                }
                else
                {
                    throw new Exception("Search is not completed");
                }
            }
            private set
            {
                lock (sync)
                {
                    this._fileCount = value;
                }
            }
        }

        public bool IsCompleted
        {
            get
            {
                return !IsRunning;
            }
        }

        public bool IsRunning
        {
            get
            {
                return threads != null && threads.Any(r => r.IsAlive);
            }
        }

        private List<Thread> threads = null;

        public void DoSearch()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            threads = new List<Thread>();
            foreach (DriveInfo d in drives)
            {
                if (d.IsReady)
                {
                    Thread t = new Thread(DoSearchInDrive);
                    threads.Add(t);
                    t.Start(d);
                }
            }
        }

        private void DoSearchInDrive(object drive)
        {
            // здійснюємо пошук
            //   Regex mask = new Regex( fileMask,RegexOptions.IgnoreCase);
            //   string[] names;
            //   try
            //   {
            //        names = Directory.GetFiles(drive.ToString());
            //   }
            //   catch 
            //   {
            //       return ;
            //   }
            //   foreach (string name in names)
            //   {
            //       if(mask.IsMatch(name))
            //       {
            //           _fileCount++;
            //       }
            //   }

            //}
            ////DirectoryInfo dir = new DirectoryInfo(drive.ToString());
            ////FileSystemInfo[] names = dir.GetFileSystemInfos();
            ////foreach (FileSystemInfo name in names)
            ////{
            ////    Console.WriteLine("File name: {0}",name.FullName);
            ////    _fileCount++;
            ////}
           // _fileCount = 0;
           //DirectoryInfo dir = new DirectoryInfo(drive.ToString());
           //FileIOPermission f = new FileIOPermission(PermissionState.None);
           //f.AllLocalFiles = FileIOPermissionAccess.Read;
         
           //    foreach (FileInfo file in dir.GetFiles(fileMask, SearchOption.AllDirectories))
           //    {
           //        Console.WriteLine("Name: {0}", file.FullName);
           //        _fileCount++;
           //    }
            if (drive != null)
            {
                DriveInfo disk = (drive as DriveInfo);
                string[] dirList = null;

                dirList = Directory.GetDirectories(disk.Name); // here generated error 

                foreach (string directory in dirList)
                {
                    CountFilesInFolder(directory);
                }

            }
        }
        private void CountFilesInFolder(string directory)
        {
            foreach (string file in Directory.GetFiles(directory, fileMask))
            {
                Console.WriteLine(file);
                _fileCount++;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Searcher searcher = new Searcher("*.txt");
                    searcher.DoSearch();
                    while (!searcher.IsCompleted)
                        Console.WriteLine("Files count: {0}", searcher.FileCount);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error has occured: {0}", e.Message);
                }
            }
        }
    }
}
