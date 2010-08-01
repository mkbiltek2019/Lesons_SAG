using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FillDataBaseBackgroundWorker
{
    public partial class DataFillerForm : Form
    { 
        public DataFillerForm(System.Collections.IDictionaryEnumerator collection)
        {
            InitializeComponent();

            fileCollection = collection;
        }

        private BackGroundFileWorker worker;
        
        public System.Collections.IDictionaryEnumerator fileCollection = null;
        
        private void startSortingButton_Click(object sender, EventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Marquee;

            if (fileCollection!=null)
            {
                worker = (new BackGroundWorkerFactory()).GetBackGroundSorterWorker(fileCollection);
                worker.ProgressChanged += backgroundWorker_ProgressChanged;
                worker.RunWorkerAsync();
            }

            progressBar.Style = ProgressBarStyle.Continuous;

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            currentSortingStateLabel.Text = string.Format("Current DataBase fill State: {0}", e.UserState);
            progressBar.Value = e.ProgressPercentage;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.Close();
        }

    }
}
