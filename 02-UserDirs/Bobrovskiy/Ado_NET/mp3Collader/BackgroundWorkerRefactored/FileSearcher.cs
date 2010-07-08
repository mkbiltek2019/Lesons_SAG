using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileSearcherBackgroundWorker
{
    public partial class FileSearcherForm : Form
    { 
        public FileSearcherForm()
        {
            InitializeComponent();
        }

        private BackGroundFileWorker worker;
        private string FolderPath = string.Empty;
        private static readonly int defaultCapacity = 5000;

        private Hashtable fileList = new Hashtable(defaultCapacity);

        public Hashtable FileList
        {
            get
            {
                return fileList;
            }
        }

        private string GetFolderPath()
        {
            string result = string.Empty;

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                result = dialog.SelectedPath;
            }

            return result;
        }

        private void startSortingButton_Click(object sender, EventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Marquee;

            if (!string.IsNullOrEmpty(FolderPath))
            {
                worker = (new BackGroundWorkerFactory()).GetBackGroundSorterWorker(FolderPath);
                worker.ProgressChanged += backgroundWorker_ProgressChanged;
                worker.RunWorkerAsync();
            }

            progressBar.Style = ProgressBarStyle.Continuous;

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            currentSortingStateLabel.Text = string.Format("Current Sorting State: {0}", e.UserState);
            progressBar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                fileList = worker.fileList;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderPath = GetFolderPath();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
