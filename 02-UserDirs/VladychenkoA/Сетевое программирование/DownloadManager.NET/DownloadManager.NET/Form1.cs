using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace DownloadManager.NET
{
    public partial class Form1 : Form
    {
        private ListDownloaders ld = new ListDownloaders();
        public Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void newDownladToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ld.AddDownloader();
            LoadDownloadeList();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (Equals(WindowState, FormWindowState.Minimized))
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, " Менеджер закачек ", " Свернуто в трей ", ToolTipIcon.Info);
            }
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(5000, " Менеджер закачек ", " Свернуто в трей ", ToolTipIcon.Info);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimerCallback timerCallback = LoadDownloaderList;
            timer = new Timer(timerCallback,null,1000,1000);
        }
        private void LoadDownloaderList(object temp)
        {
            listView1.Items.Clear();
            foreach (Downloader downloader in ld.ListDownloader)
            {
                listView1.Items.Add(
                    new ListViewItem(
                        new string[]
                            {
                                downloader.download.FileName, downloader.download.FileSize.ToString(),
                                downloader.download.Completed.ToString(), downloader.download.Progress.ToString(),
                                downloader.download.Left.ToShortTimeString(), downloader.download.Speed.ToString(),
                                downloader.download.Begin.ToShortDateString(), downloader.download.Status,
                                downloader.download.UrlDwnload
                            }, 0));
            } 
        }
        private void LoadDownloadeList()
        {
            listView1.Items.Clear();
            foreach (Downloader downloader in ld.ListDownloader)
            {
                listView1.Items.Add(
                    new ListViewItem(
                        new string[]
                            {
                                downloader.download.FileName, downloader.download.FileSize.ToString(),
                                downloader.download.Completed.ToString(), downloader.download.Progress.ToString(),
                                downloader.download.Left.ToShortTimeString(), downloader.download.Speed.ToString(),
                                downloader.download.Begin.ToShortDateString(), downloader.download.Status,
                                downloader.download.UrlDwnload
                            }, 0));
            } 
        }
    }
}
