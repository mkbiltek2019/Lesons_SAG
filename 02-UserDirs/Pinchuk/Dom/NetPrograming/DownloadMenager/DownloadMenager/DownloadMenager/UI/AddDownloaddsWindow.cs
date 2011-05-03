using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DownloadMenager.Core;

namespace DownloadMenager
{
    public partial class AddDownloaddsWindow : Form
    {
        private Dictionary<string, string> DownloadInfo { get; set; }
        public AddDownloaddsWindow()
        {
            DownloadInfo = new Dictionary<string, string>();
            InitializeComponent();
        }

        private void btDowloadStart_Click(object sender, EventArgs e)
        {
            DownloadInfo.Clear();
            tbPath.Text = tbPath.Text +"\\"+ Path.GetFileName(tbURL.Text);
            DownloadInfo.Add(Properties.Resources.DownloadUrl,tbURL.Text);
            DownloadInfo.Add(Properties.Resources.DownloadPach,tbPath.Text);
                DataSender.DownloadDataEventHendler = new DataSender.DownloadDataEvent(() => DownloadInfo);
            
            DialogResult = DialogResult.OK;
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fbdSavePath.ShowDialog(this)==DialogResult.OK)
                tbPath.Text = fbdSavePath.SelectedPath;
        }
    }
}
