using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace FileSearcher
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

        private int fileCount;
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

        private List<Thread> threads = null;

        public void DoSearch()
        {            
            DriveInfo[] drives = DriveInfo.GetDrives();
            threads = new List<Thread>();
            foreach (DriveInfo d in drives)
            {
                Thread t = new Thread(DoSearchInDrive);
                threads.Add(t);
                t.Start(d);
            }
        }

        private void DoSearchInDrive(object drive)
        {
            // здійснюємо пошук
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
                while (!searcher.IsCompleted) ;
                Console.WriteLine("Files count: {0}", searcher.FileCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error has occured: {0}", e.Message);
            }
        }
    }
}
