using System.Collections;
using System.Collections.Generic;
using FileSearcherBackgroundWorker;
using FillDataBaseBackgroundWorker;
using MyBackgroundWorker;

namespace AudioFileManager
{
    public class AudioFileManager
    {
        private const int defaultCapacity = 5000;
        private Hashtable fileList = new Hashtable(defaultCapacity);

        public void GetFileList()
        {
            FileSearcherForm m = new FileSearcherForm();
            m.ShowDialog();

            fileList = m.FileList;
        }

        public void FillDataBaseWithData()
        {
            System.Collections.IDictionaryEnumerator FileListEnumerator;
            FileListEnumerator = fileList.GetEnumerator();

            ////enumerate the collection of files found in the file hashtable
            //while (FileListEnumerator.MoveNext())
            //{
            //    // add each of the file names to the listbox
            //    FileListEnumerator.Key.ToString();

            //}

            DataFillerForm fileWorker = new DataFillerForm(FileListEnumerator);
            fileWorker.ShowDialog();
        }

        public void StoreFileList(List<Model.ResultTable> fileList)
        {
            SaveForm dialog = new SaveForm(fileList);
            dialog.ShowDialog();
        }
    }
}
