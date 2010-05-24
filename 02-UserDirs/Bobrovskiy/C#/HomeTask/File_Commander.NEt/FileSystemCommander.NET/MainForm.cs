using System.Windows.Forms;
using Helper;

namespace FileSystemCommander.NET
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            BindEventsToFileListPanel();
            SetLeftFileListPanelViewSettings(View.Details);
            SetRightFileListPanelViewSettings(View.Details);
            SetFolderPath();

            RefreshDiskList();
        }


        #region Mouse Events

        private void fileListPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            ListPanel_OnMouseUp(sender, e, leftFileListPanel, FilePathTextBox.Text);
        }

        private void fileListPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            ListPanel_OnMouseUp(sender, e, leftFileListPanel, FilePath2TextBox.Text);
        }

        private void fileListPanel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListPanel_OnMouseDoubleClick(sender, e, leftFileListPanel);
        }

        private void fileListPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListPanel_OnMouseDoubleClick(sender, e, rightFileListPanel);
        }


        #endregion


        #region view settings

        private void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            SetRightFileListPanelViewSettings(View.List);
            SetLeftFileListPanelViewSettings(View.List);
        }

        private void toolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            SetRightFileListPanelViewSettings(View.Details);
            SetLeftFileListPanelViewSettings(View.Details);
        }

        private void toolStripMenuItem4_Click(object sender, System.EventArgs e)
        {
            SetRightFileListPanelViewSettings(View.LargeIcon);
            SetLeftFileListPanelViewSettings(View.LargeIcon);
        }

        #endregion


        private void exitToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void RefreshDiskListButton_Click(object sender, System.EventArgs e)
        {
            RefreshDiskList();
            queryDisk();
        }
       
    }
}
