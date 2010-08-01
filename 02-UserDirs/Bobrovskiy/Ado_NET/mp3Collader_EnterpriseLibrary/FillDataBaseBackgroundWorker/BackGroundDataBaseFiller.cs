using System.ComponentModel;
using System.IO;
using AudioFileTagger;
using mp3Collader.Controllers;

namespace FillDataBaseBackgroundWorker
{
    public enum SortingState
    {
        Start,
        Completed,
        Canceled
    }

    public class BackGroundWorkerFactory
    {
        public BackGroundFileWorker GetBackGroundSorterWorker(System.Collections.IDictionaryEnumerator fileListEnumerator)
        {
            return new BackGroundFileWorker(fileListEnumerator);
        }
    }

    public class BackGroundFileWorker : BackgroundWorker
    {
        public SortingState Result;

        private System.Collections.IDictionaryEnumerator FileListEnumerator;

        public BackGroundFileWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public BackGroundFileWorker(System.Collections.IDictionaryEnumerator fileListEnumerator)
            : this()
        {
            FileListEnumerator = fileListEnumerator;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {  
            ReportProgress(0, SortingState.Start);

            TableController tableController = new TableController();
            AudioFileInfo audioFile  = new AudioFileInfo();
            
            tableController.InsertInitialize();

            while (FileListEnumerator.MoveNext())
            { 
                if (CancellationPending)
                {
                    e.Cancel = true;
                    break;
                } 
                
                FileInfo currentFile = new FileInfo(FileListEnumerator.Key.ToString());

                audioFile.GetInfo(currentFile);
                tableController.Insert(currentFile, audioFile);
            }

            ReportProgress(100, "Done!");
            e.Result = SortingState.Completed;
        }


    }
   
}
