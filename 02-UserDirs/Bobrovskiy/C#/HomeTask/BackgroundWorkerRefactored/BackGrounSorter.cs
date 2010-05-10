using System;
using System.Collections;
using System.ComponentModel;

namespace BackgroundWorkerDemo
{
    public enum SortingState
    {
        Sorting,
        Completed,
        Canceled
    }

    public class Client
    {
        public BackGroundSorterWorker GetBackGroundSorterWorker(ArrayList arrayList)
        {
            return new BackGroundSorterWorker(arrayList);
        }
    }

    public class BackGroundSorterWorker : BackgroundWorker
    {
        public SortingState Result;   

        private ArrayList arrayListForCalculation;
       
        public BackGroundSorterWorker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public BackGroundSorterWorker(ArrayList arrayList)
            : this()
        {
            arrayListForCalculation = arrayList;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            for (int i = 0; i < arrayListForCalculation.Count; i++)
            {
                for (int j = 0; j < arrayListForCalculation.Count; j++)
                {
                    if (((IComparable)arrayListForCalculation[i]).CompareTo(arrayListForCalculation[j]) < 0)
                    {
                        object swap = arrayListForCalculation[i];
                        arrayListForCalculation[i] = arrayListForCalculation[j];
                        arrayListForCalculation[j] = swap;
                    }
                   
                }

                if (CancellationPending)
                {
                    e.Cancel = true;
                    ReportProgress((int) ((i/(float) arrayListForCalculation.Count)*100),
                                   SortingState.Canceled);
                    return;
                }

                ReportProgress((int)((i / (float)arrayListForCalculation.Count) * 100), 
                                SortingState.Sorting);

            }

            ReportProgress(100, "Done!");
            e.Result = SortingState.Completed;
        }

    }
   
}
