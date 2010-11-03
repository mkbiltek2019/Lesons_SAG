using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleDownloadManager.Classes;
using SimpleDownloadManager.Interfaces;

namespace SimpleDownloadManager
{
    public partial class SimpleDownloadmanager : Form
    {
        public SimpleDownloadmanager()
        {
            InitializeComponent();
            httpDownloadManager.GetDownloadTaskState += new Action<List<DownloadItem> >(httpDownloadManager_GetDownloadTaskState);
        }

        private IDownloadManager httpDownloadManager = new HttpDownloadManager();
        private DownloadItem dataGridViewSelectedItem = null;

        void httpDownloadManager_GetDownloadTaskState(List<DownloadItem> data)
        {
            this.tastListDataGridView.BeginInvoke(new Action<List<DownloadItem> >(UpdateDataGridView), data);
        }

        private void UpdateDataGridView(List<DownloadItem> data)
        {
            this.tastListDataGridView.DataSource = null;
            this.tastListDataGridView.DataSource = data;
            this.tastListDataGridView.Columns[0].Visible = false; //hide first Column
        }

        private void fileStoreDirectoryButton_Click(object sender, EventArgs e)
        {
            //here select directory and file name for downloaded file
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            httpDownloadManager.PauseTask();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            httpDownloadManager.StopTask();
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            httpDownloadManager.RemooveTask();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToDownloadListButton_Click(object sender, EventArgs e)
        {
            // add file to download list
            //TODO: check for input data
            DownloadItem downloadItem = new DownloadItem();
            downloadItem.SourceName = this.sourceFileNameTextBox.Text;
            downloadItem.DestinationName = this.destFileTextBox.Text;
            downloadItem.Persentage = 0;
            downloadItem.State = TaskState.Start;

            httpDownloadManager.AddTask(downloadItem);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            httpDownloadManager.StartTask();
        }

        private void tastListDataGridView_Click(object sender, EventArgs e)
        {
            if (tastListDataGridView.SelectedRows.Count > 0)
            {
                dataGridViewSelectedItem = (DownloadItem)tastListDataGridView.SelectedRows[0].DataBoundItem;
                httpDownloadManager.SelectedItem = dataGridViewSelectedItem;
            }
        }
    }
}
