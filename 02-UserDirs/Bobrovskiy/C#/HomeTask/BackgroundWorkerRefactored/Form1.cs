using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackgroundWorkerDemo
{
    public partial class Form1 : Form
    {
        
        private BackGroundSorterWorker worker;

        private static readonly int n = 10000;
        private ArrayList a = new ArrayList(n);

        public Form1()
        {
            InitializeComponent();
        }

        private void startSortingButton_Click(object sender, EventArgs e)
        {
            FullArrayWithSomeData();
            
            worker = (new Client()).GetBackGroundSorterWorker(a);
            worker.ProgressChanged += backgroundWorker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void FullArrayWithSomeData()
        {
            int max = n;

            for (int i = 0; i < n; i++)
            {
                a.Add(max--);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            currentSortingStateLabel.Text = string.Format("Current Sorting State: {0}", e.UserState);
            progressLabel.Text = string.Format("Progress: {0}%", e.ProgressPercentage);
            progressBar.Value = e.ProgressPercentage;
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        private void ShowResultButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < a.Count; i++)
            {
                ArrayListBox.Items.Add(a[i]);
            }
        }
    }
}
