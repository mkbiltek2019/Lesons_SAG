using System;
using System.Windows.Forms;
using mp3Collader.Controllers;

namespace mp3Collader
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            tableController = new TableController();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void processSelectedFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFileListFromSelectedFolder();
        }

        private void saveFilteredTrackInFolderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FillDatabase();
            FillComboBoxWithData();
        }

        private void albumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridViewWithFilter();
        }

        private void prevPageToolStripButton_Click(object sender, EventArgs e)
        {
            GetPreviousePage();
            this.pageNumberToolStripButton.Text = currentPage.ToString();
        }

        private void nextPageToolStripButton_Click(object sender, EventArgs e)
        {
            GetNextPage();
            this.pageNumberToolStripButton.Text = currentPage.ToString();
        }

        private void saveFilteredDataToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreRenamedFilesToSelectedDirectory();
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDatabase(); 
        }

        private void pageSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FillDataGridViewWithFilter();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           helpAboutBox dialog = new helpAboutBox();
            dialog.ShowDialog();
        } 
    }

}
