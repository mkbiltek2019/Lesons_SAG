using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileSearcher
{
   public class Searcher
    {
        #region Fields

        private object sync = new object();
        private List<Thread> threads = null;
        private string fileMask = string.Empty;
        private int fileCount = 0;
        private DriveInfo[] drives = null;

        #endregion

        #region Constructor

        public Searcher(string fileMask)
        {
            this.fileMask = fileMask;
        }

        #endregion

        #region Properties

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

        public int FileCount
        {
            get
            {
                if (IsCompleted)
                {
                    return fileCount;
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
                    this.fileCount = value;
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

        #endregion

        #region Public methods

        public void DoSearch()
        {
            CreateThreadList();

            for (int i = 0; i < drives.Length; i++)
            {
                threads[i].Start(drives[i]);
            }
        }

        #endregion

        #region Private methods

        private void CreateThreadList()
        {
            drives = DriveInfo.GetDrives();
            threads = new List<Thread>();

            for (int i = 0; i < drives.Length; i++)
            {
                threads.Add(new Thread(DoSearchInDrive));
                threads[i].Name = string.Format("ThreadForDisk-{0}", drives[i].Name);
            }
        }

        private void DoSearchInDrive(object drive)
        {
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
                fileCount++;
            }
        }

        #endregion

    }//class

}//namespace

