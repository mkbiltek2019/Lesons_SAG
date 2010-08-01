using System;
using System.IO;
using System.Collections;

namespace FileSearcher
{
    public class DiscoFiles
    {
        public static int count = 0;

        private DiscoFiles()
        {
        }

        /// <summary>
        /// Main method, which developer-user will call to get a list of
        ///  all of the files loaded into a sent in hashtable list
        /// </summary>
        /// <param name="p_TargetDir">The top-level directory you want to search</param>
        /// <param name="p_FilePattern">The file pattern you want to search, ex. *.*, frs*.old, msen.old</param>
        /// <param name="p_htDirs">Hashtable ref which will hold all of the directories searched</param>
        /// <param name="p_htFiles">Hashtable ref which will be a list of all the files found, which match
        /// the filepattern entered</param>
        /// <param name="p_SearchSubdirs">bool whether or not you want to search the subdirs</param>
        public static void CreateFileList(string p_TargetDir, string p_FilePattern,
            ref Hashtable p_htDirs, ref Hashtable p_htFiles, bool p_SearchSubdirs)
        {
            //CREATE A LIST OF FILES Which will be searched
            //basically get all of the files which match the file pattern
            //from the path the user entered p_TargetDir
            // if the user enters an empty string for the targetdir,
            // the application will get the currentdirectory (app.path) and continue
            string strCurrDir = string.Empty;
            if (p_TargetDir.Length != 0)
            {
                strCurrDir = p_TargetDir;
            }
            else
            {
                strCurrDir = Directory.GetCurrentDirectory();
            }

            try
            {
                // you could get an error when the user enters a bad path
                string[] files = Directory.GetFiles(strCurrDir, p_FilePattern);
                string[] Dirs = Directory.GetDirectories(strCurrDir);
                int DirCount;
                int FileCount;
                // add all subdirectories
                for (DirCount = 0; DirCount < Dirs.Length; DirCount++)
                {
                    p_htDirs.Add(Dirs[DirCount], Dirs[DirCount]);
                }
                // add all files
                for (FileCount = 0; FileCount < files.Length; FileCount++)
                {
                    p_htFiles.Add(files[FileCount], files[FileCount]);
                }

                if (p_SearchSubdirs)
                {
                    // iterate through all of the directories in the current directory
                  System.Collections.IDictionaryEnumerator DirectoryEnum;
                    while (p_htDirs.Count > 0)
                    {
                        DirectoryEnum = p_htDirs.GetEnumerator();
                        DirectoryEnum.MoveNext();
                        // Get all the subdirs of this directory and add them to the directory hashtable
                        IterateDirectories(
                            DirectoryEnum.Key.ToString(), 
                            p_FilePattern,
                            ref p_htDirs, 
                            ref p_htFiles);
                    }
                }
            }
            catch(Exception OpenDirEx)
            {
            }
        }
          private static void IterateDirectories(string p_TargetDir, string p_FilePattern,
            ref Hashtable p_htDirs, ref Hashtable p_htFiles)
        {
            try
            {
                string[] files = Directory.GetFiles(p_TargetDir, p_FilePattern);//, p_FilePattern + "*.*");
                string[] Dirs = Directory.GetDirectories(p_TargetDir);
                // remove the sent in directory immediately
                p_htDirs.Remove(p_TargetDir);

                Hashtable htLocalDir = new Hashtable(5000);
                Hashtable htLocalFiles = new Hashtable(5000);
                int DirCount = 0;
                int FileCount = 0;
                // add all subdirectories
                for (DirCount = 0; DirCount < Dirs.Length; DirCount++)
                {
                    try
                    {
                        p_htDirs.Add(Dirs[DirCount], Dirs[DirCount]);
                        htLocalDir.Add(Dirs[DirCount], Dirs[DirCount]);
                    }
                    catch //(System.ArgumentException ex)
                    {
                    }
                }

                // add all files
                for (FileCount = 0; FileCount < files.Length; FileCount++)
                {
                    try
                    {
                        count++;

                        p_htFiles.Add(files[FileCount], files[FileCount]);
                        htLocalFiles.Add(files[FileCount], files[FileCount]);
                    }
                    catch //(System.ArgumentException ex)
                    {
                    }
                }

                while (htLocalDir.Count > 0)
                {
                    System.Collections.IDictionaryEnumerator LocalDirEnum;
                    LocalDirEnum = htLocalDir.GetEnumerator();
                    LocalDirEnum.MoveNext();
                   
                    htLocalDir.Remove(LocalDirEnum.Key.ToString());
                }
                // iterate through all of the files in the current directory
                while (htLocalFiles.Count > 0)
                {
                    System.Collections.IDictionaryEnumerator LocalFileEnum;
                    LocalFileEnum = htLocalFiles.GetEnumerator();
                    LocalFileEnum.MoveNext();
                    
                    htLocalFiles.Remove(LocalFileEnum.Key.ToString());
                }
            }
            catch //(System.UnauthorizedAccessException myEx)
            {
                p_htDirs.Remove(p_TargetDir);
            }
        }


        //public static void CreateFileList(string p_TargetDir, string[] p_FilePattern,
        //    ref Hashtable p_htDirs, ref Hashtable p_htFiles, bool p_SearchSubdirs)
        //{
        //    //CREATE A LIST OF FILES Which will be searched
        //    //basically get all of the files which match the file pattern
        //    //from the path the user entered p_TargetDir
        //    // if the user enters an empty string for the targetdir,
        //    // the application will get the currentdirectory (app.path) and continue
        //    string strCurrDir;
        //    if (p_TargetDir.Length != 0)
        //    {
        //        strCurrDir = p_TargetDir;
        //    }
        //    else
        //    {
        //        strCurrDir = Directory.GetCurrentDirectory();
        //    }
        //    try
        //    {
        //        string[] files = null;
        //        ArrayList FileList = new ArrayList();
        //        // you could get an error when the user enters a bad path
        //        foreach (string strPattern in p_FilePattern)
        //        {
        //            files = Directory.GetFiles(p_TargetDir, strPattern);
        //            foreach (string filename in files)
        //            {
        //                FileList.Add(filename);
        //            }
        //        }

        //        string[] Dirs = Directory.GetDirectories(strCurrDir);
        //        int DirCount;
        //        int FileCount;
        //        // add all subdirectories
        //        for (DirCount = 0; DirCount < Dirs.Length; DirCount++)
        //        {
        //            p_htDirs.Add(Dirs[DirCount], Dirs[DirCount]);
        //        }
        //        // add all files
        //        for (FileCount = 0; FileCount < FileList.Count; FileCount++)
        //        {
        //            p_htFiles.Add(FileList[FileCount], FileList[FileCount]);
        //        }

        //        if (p_SearchSubdirs)
        //        {
        //            // iterate through all of the directories in the current directory
        //            System.Collections.IDictionaryEnumerator DirectoryEnum;
        //            while (p_htDirs.Count > 0)
        //            {
        //                DirectoryEnum = p_htDirs.GetEnumerator();
        //                DirectoryEnum.MoveNext();
        //                // Get all the subdirs of this directory and add them to the directory hashtable
        //                IterateDirectories(
        //                    DirectoryEnum.Key.ToString(), 
        //                    p_FilePattern,
        //                    ref p_htDirs, 
        //                    ref p_htFiles);
        //            }
        //        }
        //    }
        //    catch(Exception OpenDirEx)
        //    {   

        //    }
        //} 


        /// <summary>
        /// Helper method called by CreateFileList method.
        /// </summary>
        /// <param name="p_TargetDir">top-level directory user wants to search</param>
        /// <param name="p_FilePattern">The file pattern you want to search, ex. *.*, frs*.old, msen.old</param>
        /// <param name="p_htDirs">Hashtable ref which will hold all of the directories searched</param>
        /// <param name="p_htFiles">Hashtable ref which will be a list of all the files found, which match
        /// the filepattern entered</param>
      

        //private static void IterateDirectories(string p_TargetDir, string[] p_FilePattern,
        //    ref Hashtable p_htDirs, ref Hashtable p_htFiles)
        //{
        //    try
        //    {
        //        string[] files = null;
        //        ArrayList FileList = new ArrayList();
        //        foreach (string strPattern in p_FilePattern)
        //        {
        //            files = Directory.GetFiles(p_TargetDir, strPattern);
        //            foreach (string filename in files)
        //            {
        //                FileList.Add(filename);
        //            }
        //        }

        //        string[] Dirs = Directory.GetDirectories(p_TargetDir);
        //        // remove the sent in directory immediately
        //        p_htDirs.Remove(p_TargetDir);

        //        Hashtable htLocalDir = new Hashtable(5000);
        //        Hashtable htLocalFiles = new Hashtable(5000);
        //        int DirCount = 0;
        //        int FileCount = 0;
        //        // add all subdirectories
        //        for (DirCount = 0; DirCount < Dirs.Length; DirCount++)
        //        {
        //            try
        //            {
        //                p_htDirs.Add(Dirs[DirCount], Dirs[DirCount]);
        //                htLocalDir.Add(Dirs[DirCount], Dirs[DirCount]);
        //            }
        //            catch //(System.ArgumentException ex)
        //            {
        //                //Console.WriteLine(ex.Message);
        //            }
        //        }

        //        // add all files
        //        for (FileCount = 0; FileCount < FileList.Count; FileCount++)
        //        {
        //            try
        //            {
        //                p_htFiles.Add(FileList[FileCount], FileList[FileCount]);
        //                htLocalFiles.Add(FileList[FileCount], FileList[FileCount]);
        //            }
        //            catch //(System.ArgumentException ex)
        //            {
        //                //Console.WriteLine(ex.Message );
        //            }

        //        }
        //        while (htLocalDir.Count > 0)
        //        {

        //            System.Collections.IDictionaryEnumerator LocalDirEnum;
        //            LocalDirEnum = htLocalDir.GetEnumerator();
        //            LocalDirEnum.MoveNext();
        //            // RAD 12/01/04 Console.WriteLine(myEnumerator.Key.ToString());
        //            htLocalDir.Remove(LocalDirEnum.Key.ToString());
        //        }
        //        // iterate through all of the files in the current directory
        //        while (htLocalFiles.Count > 0)
        //        {

        //            System.Collections.IDictionaryEnumerator LocalFileEnum;
        //            LocalFileEnum = htLocalFiles.GetEnumerator();
        //            LocalFileEnum.MoveNext();
        //            // RAD 12/01/04 Console.WriteLine(myEnumerator.Key.ToString());
        //            htLocalFiles.Remove(LocalFileEnum.Key.ToString());
        //        }
        //    }
        //    catch //(System.UnauthorizedAccessException myEx)
        //    {
        //        p_htDirs.Remove(p_TargetDir);
        //    }
        //}

    }
}
