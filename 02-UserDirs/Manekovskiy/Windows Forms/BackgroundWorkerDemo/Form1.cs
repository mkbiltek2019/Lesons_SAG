using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackgroundWorkerDemo
{
    public partial class Form1 : Form
    {
        public enum SortingState
        {
            Sorting,
            Completed,
            Canceled
        }

        const int n = 10000;
        int[] a = new int[n];

        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int[] array = (int[])e.Argument;

            int totalIterations = array.Length;
            float currentProgress = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    if (array[i] < array[j])
                    {
                        int swap = array[i];
                        array[i] = array[j];
                        array[j] = swap;
                    }
                }

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                currentProgress = (i / (float)totalIterations) * 100;
                backgroundWorker.ReportProgress((int)currentProgress, SortingState.Sorting);
            }

            if (e.Cancel)
            {
                backgroundWorker.ReportProgress((int)currentProgress, SortingState.Canceled);
            }
            else
            {
                backgroundWorker.ReportProgress((int)currentProgress, SortingState.Completed);
            }
        }

        private void startSortingButton_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync(a);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Congradulation! Sorting compeleted!", "Congradulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            currentSortingStateLabel.Text = string.Format("Current Sorting State: {0}", ((SortingState)e.UserState).ToString());
            progressLabel.Text = string.Format("Progress: {0}%", e.ProgressPercentage);
            progressBar.Value = e.ProgressPercentage;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }
    }
}
