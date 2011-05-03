using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DownloadMenager.Core;
using DownloadMenager.UI;

namespace DownloadMenager
{
    public enum ListViewColumn
    {
        DownloadFolder = 1,
        Status,
        Size,
        Download,
        Remaining,
        Speed

    }
    public partial class DownloadMaster : Form
    {
        private List<string> tbPath;
        private List<string> tbURL;
        // HttpDownloadClient client = null;
        private List<HttpDownloadClient> clients;
        bool isPaused = false;
        DateTime lastNotificationTime;
        private Dictionary<string, string> DownloadInfo { get; set; }
        private int activeIndexListView = -1;
        public DownloadMaster()
        {
            DownloadInfo = new Dictionary<string, string>();
            tbPath = new List<string>();
            tbURL = new List<string>();
            clients = new List<HttpDownloadClient>();
            InitializeComponent();
        }

        private void addDownloads_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult dialogResult = (new AddDownloaddsWindow()).ShowDialog();

                switch (dialogResult)
                {
                    case DialogResult.OK:


                        tbPath.Add(DataSender.DownloadDataEventHendler().SingleOrDefault(k => k.Key == Properties.Resources.DownloadPach).Value);
                        tbURL.Add(DataSender.DownloadDataEventHendler().SingleOrDefault(k => k.Key == Properties.Resources.DownloadUrl).Value);

                        ListViewItem listViewItem = new ListViewItem(new[]
                                                                         {
                                                                             Path.GetFileNameWithoutExtension(tbPath[tbPath.Count-1]),
                                                                             tbPath[tbPath.Count-1],
                                                                             String.Empty,
                                                                             String.Empty,
                                                                             String.Empty,
                                                                             String.Empty,
                                                                             String.Empty
                                                                            
                                                                         });
                        lwDownloadInfo.Items.Add(listViewItem);


                        clients.Add(new HttpDownloadClient(0, tbURL[tbURL.Count - 1], String.Empty, 0));
                        break;
                    case DialogResult.Cancel:

                        break;
                    default:
                        throw new Exception("Помилка робти програми!");
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(DownloadStart));

            //DownloadStart();
        }

        private void DownloadStart(object st)
        {
            int selectedIndex = lwDownloadInfo.SelectedIndices[0];

            try
            {

                // Check whether the file exists.
                if (File.Exists(tbPath[selectedIndex].Trim()))
                {
                    string message = "There is already a file with the same name, "
                                     + "do you want to delete it? "
                                     + "If not, please change the local path. ";
                    var result = MessageBox.Show(
                        message,
                        "File name conflict: " + tbPath[selectedIndex].Trim(),
                        MessageBoxButtons.OKCancel);

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        File.Delete(tbPath[selectedIndex].Trim());
                    }
                    else
                    {
                        return;
                    }
                }

                // Construct the temporary file path.
                string tempPath = tbPath[selectedIndex].Trim() + ".tmp";

                // Delete the temporary file if it already exists.
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                // Initialize an instance of HttpDownloadClient.
                // Store the file to a temporary file first.
                int index = lwDownloadInfo.Items.Count - 1;
                tsslIndex.Text = String.Format("Index:{0}", index);
                //clients.Add(new HttpDownloadClient(selectedIndex, tbURL[selectedIndex], tempPath, selectedIndex));
                clients[selectedIndex] = new HttpDownloadClient(selectedIndex, tbURL[selectedIndex], tempPath,
                                                                selectedIndex);
                //// Register the events of HttpDownloadClient.
                clients[selectedIndex].DownloadCompleted += new EventHandler<HttpDownloadCompletedEventArgs>(
                    DownloadCompleted);
                clients[selectedIndex].DownloadProgressChanged +=
                    new EventHandler<HttpDownloadProgressChangedEventArgs>(DownloadProgressChanged);
                clients[selectedIndex].StatusChanged += new EventHandler<StatusChangedArgs>(StatusChanged);

                // Start to download file.
                clients[selectedIndex].Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void StatusChanged(object sender, StatusChangedArgs e)
        {

            //lbStatus.Text = client.Status.ToString();

            switch (clients[e.Index].Status)
            {
                case HttpDownloadClientStatus.Idle:
                case HttpDownloadClientStatus.Canceled:
                case HttpDownloadClientStatus.Completed:
                    btnDownload.Enabled = true;
                    btnPause.Enabled = false;
                    btnCancel.Enabled = false;
                    // tbPath.Enabled = true;
                    // tbURL.Enabled = true;
                    break;
                case HttpDownloadClientStatus.Downloading:
                    btnDownload.Enabled = false;
                    btnPause.Enabled = true;
                    btnCancel.Enabled = true;
                    //  tbPath.Enabled = false;
                    //  tbURL.Enabled = false;
                    break;
                case HttpDownloadClientStatus.Pausing:
                case HttpDownloadClientStatus.Canceling:
                    btnDownload.Enabled = false;
                    btnPause.Enabled = false;
                    btnCancel.Enabled = false;
                    // tbPath.Enabled = false;
                    //  tbURL.Enabled = false;
                    break;
                case HttpDownloadClientStatus.Paused:
                    btnDownload.Enabled = false;
                    btnPause.Enabled = true;
                    btnCancel.Enabled = false;
                    // tbPath.Enabled = false;
                    //tbURL.Enabled = false;
                    break;
            }

            //if (client.Status == HttpDownloadClientStatus.Paused)
            //{
            //    //lbSummary.Text =
            //    //   String.Format("Received: {0}KB, Total: {1}KB, Time: {2}:{3}:{4}",
            //    //   client.DownloadedSize / 1024, client.TotalSize / 1024,
            //    //   client.TotalUsedTime.Hours, client.TotalUsedTime.Minutes,
            //    //   client.TotalUsedTime.Seconds);
            //}
        }

        /// <summary>
        /// Handle DownloadProgressChanged event.
        /// </summary>
        void DownloadProgressChanged(object sender, HttpDownloadProgressChangedEventArgs e)
        {
            // Refresh the summary every second.
            if (DateTime.Now > lastNotificationTime.AddSeconds(1))
            {
                //lbSummary.Text = String.Format("Received: {0}KB, Total: {1}KB, Speed: {2}KB/s",
                //    e.ReceivedSize / 1024, e.TotalSize / 1024, e.DownloadSpeed / 1024);
                //for (int i = 0; i < lwDownloadInfo.Items.Count; i++)
                //{

                //    lwDownloadInfo.Items[i].SubItems[(int)ListViewColumn.Status].Text = client.Status.ToString();
                //    lwDownloadInfo.Items[i].SubItems[(int)ListViewColumn.Download].Text = String.Format("{0} KB", e.ReceivedSize / 1024);
                //    lwDownloadInfo.Items[i].SubItems[(int)ListViewColumn.Remaining].Text = String.Format("{0} KB", e.TotalSize / 1024 - e.ReceivedSize / 1024);
                //    lwDownloadInfo.Items[i].SubItems[(int)ListViewColumn.Size].Text = String.Format("{0} KB", e.TotalSize / 1024);
                //    lwDownloadInfo.Items[i].SubItems[(int)ListViewColumn.Speed].Text = String.Format("{0} KB", e.DownloadSpeed / 1024);
                //}

                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Status].Text = clients[e.Index].Status.ToString();
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Download].Text = String.Format("{0} KB", e.ReceivedSize / 1024);
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Remaining].Text = String.Format("{0} KB", e.TotalSize / 1024 - e.ReceivedSize / 1024);
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Size].Text = String.Format("{0} KB", e.TotalSize / 1024);
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Speed].Text = String.Format("{0} KB", e.DownloadSpeed / 1024);

                //prgDownload.Value = (int)(e.ReceivedSize * 100 / e.TotalSize);
                lastNotificationTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Handle DownloadCompleted event.
        /// </summary>
        void DownloadCompleted(object sender, HttpDownloadCompletedEventArgs e)
        {
            if (e.Error == null)
            {

                //lbSummary.Text =
                //    String.Format("Received: {0}KB, Total: {1}KB, Time: {2}:{3}:{4}",
                //    e.DownloadedSize / 1024, e.TotalSize / 1024, e.TotalTime.Hours,
                //    e.TotalTime.Minutes, e.TotalTime.Seconds);



                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Status].Text = clients[e.Index].Status.ToString();
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Download].Text = String.Format("{0} KB", 0);
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Remaining].Text = String.Format("{0} KB", e.TotalSize / 1024);
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Size].Text = String.Format("{0} KB", e.TotalSize / 1024);
                lwDownloadInfo.Items[e.Index].SubItems[(int)ListViewColumn.Speed].Text = String.Format("{0} KB", 0);


                if (File.Exists(tbPath[e.Index].Trim()))
                {
                    File.Delete(tbPath[e.Index].Trim());
                }

                File.Move(tbPath[e.Index].Trim() + ".tmp", tbPath[e.Index].Trim());
                //prgDownload.Value = 100;
            }
            else
            {
                //lbSummary.Text = e.Error.Message;
                if (File.Exists(tbPath[e.Index].Trim() + ".tmp"))
                {
                    File.Delete(tbPath[e.Index].Trim() + ".tmp");
                }
                //prgDownload.Value = 0;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (clients.Count != 0)
            {
                int selected = lwDownloadInfo.SelectedIndices[0];
                {
                    if (clients[selected].Status.ToString() == "Downloading")
                        clients[selected].Cancel();
                }
                

            }


            lwDownloadInfo.Items.Remove(lwDownloadInfo.SelectedItems[0]);
            btnDownload.Enabled = false;
            btnCancel.Enabled = false;

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            int selectedIndex = lwDownloadInfo.SelectedIndices[0];
            if (clients[selectedIndex].Status.ToString()=="Paused")
            {

                clients[selectedIndex].Resume();
                lwDownloadInfo.Items[selectedIndex].SubItems[(int) ListViewColumn.Status].Text = "Downloading";
                btnPause.Text = "Paused";

            }
            else
            {
                clients[selectedIndex].Pause();
                btnPause.Text = "Resume";
                lwDownloadInfo.Items[selectedIndex].SubItems[(int) ListViewColumn.Status].Text = "Paused";
            }
            isPaused = !isPaused;

        }

        private void lwDownloadInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnDownload.Enabled = false;
            if(lwDownloadInfo.SelectedItems.Count!=0)
            {
                int selectedIndex = lwDownloadInfo.SelectedIndices[0];
                if (String.IsNullOrEmpty(lwDownloadInfo.Items[selectedIndex].SubItems[(int)ListViewColumn.Download].Text))
                    btnDownload.Enabled = true;
                btnCancel.Enabled = true;
                btnPause.Enabled = true;
                btnPause.Text = lwDownloadInfo.Items[selectedIndex].SubItems[(int)ListViewColumn.Status].Text == "Paused" ? "Resume" : "Paused";
            }
            else
            {
                btnCancel.Enabled = false;
                btnPause.Enabled = false;
            }

            


        }
    }
}
