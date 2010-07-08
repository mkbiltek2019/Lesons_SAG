using System.Collections;
using System.ComponentModel;
using FileSearcher;

namespace FileSearcherBackgroundWorker
{
    public class BackGroundFileWorker : System.ComponentModel.BackgroundWorker
    {
        public SortingState Result;

        private static readonly int defaultCapacity = 5000;
        private string FilePattern = "*mp3"; 
        private string Path = string.Empty;
        private Hashtable directoryList = new Hashtable(defaultCapacity);

        public Hashtable fileList = new Hashtable(defaultCapacity);

        public void FillDataBaseWithData(string SelectedFolder)
        {
            // call CreateFileList with the proper parameters
            DiscoFiles.CreateFileList(SelectedFolder,
                                      FilePattern,
                                      ref directoryList,
                                      ref fileList,
                                      true);
        } 
       
        public BackGroundFileWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public BackGroundFileWorker(string folderPath)
            : this()
        {
            Path = folderPath;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {  
            ReportProgress(0, SortingState.Start);

            FillDataBaseWithData(Path);

            ReportProgress(100, "Done!");
            e.Result = SortingState.Completed;
        }


    }

    public enum SortingState
    {
        Start,
        Completed,
        Canceled
    }

    public class BackGroundWorkerFactory
    {
        public BackGroundFileWorker GetBackGroundSorterWorker(string folderPath)
        {
            return new BackGroundFileWorker(folderPath);
        }
    }
   
}
