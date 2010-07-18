using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
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

        // fill dataBase with data
        private AudioFileManager.AudioFileManager audioFileManager = null;

        private Database database;
        private TableController tableController;

        private int currentPage = 1;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void processSelectedFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {   // fill dataBase with data
            audioFileManager = new AudioFileManager.AudioFileManager();
            audioFileManager.GetFileList();

        }

        private void saveFilteredTrackInFolderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            audioFileManager.FillDataBaseWithData();
            FillComboBoxWithData();
        }

        private void FillComboBoxWithData()
        {
            tableController = new TableController();
            if (artistComboBox.Items.Count > 0)
            {
                artistComboBox.Items.Clear();
            }

            foreach (Model.SimpleTable value in tableController.GetListByTableName(TableList.Artist))
            {
                artistComboBox.Items.Add(value.Name);
            }
           
            if (albumComboBox.Items.Count > 0)
            {
                albumComboBox.Items.Clear();
            }

            foreach (Model.SimpleTable value in tableController.GetListByTableName(TableList.Album))
            {
                albumComboBox.Items.Add(value.Name);
            }

            if (genreComboBox.Items.Count > 0)
            {
                genreComboBox.Items.Clear();
            }

            foreach (Model.SimpleTable value in tableController.GetListByTableName(TableList.Genre))
            {
                genreComboBox.Items.Add(value.Name);
            }
            
            if (fileNameComboBox.Items.Count > 0)
            {
                fileNameComboBox.Items.Clear();
            }

            foreach (Model.ResultTable value in tableController.GetListByTableName(TableList.FileName))
            {
                fileNameComboBox.Items.Add(value.FileName);
            }
            
        }

        private void FillDataGridViewWithFilter()
        {
            tableController = new TableController();

            string album = string.Empty;
            string artist = string.Empty;
            string genre = string.Empty;
            string fileName = string.Empty;

            if (albumComboBox.SelectedItem != null)
            {
                album = Convert.ToString(this.albumComboBox.SelectedItem);
                artistComboBox.SelectedItem = null;
                genreComboBox.SelectedItem = null;
                fileNameComboBox.SelectedItem = null;
            }

            if (artistComboBox.SelectedItem != null)
            {
                artist = Convert.ToString(this.artistComboBox.SelectedItem);
                genreComboBox.SelectedItem = null;
                fileNameComboBox.SelectedItem = null;
                albumComboBox.SelectedItem = null;
            }

            if (genreComboBox.SelectedItem != null)
            {
                genre = Convert.ToString(this.genreComboBox.SelectedItem);
                artistComboBox.SelectedItem = null;
                fileNameComboBox.SelectedItem = null;
                albumComboBox.SelectedItem = null;
            }

            if (fileNameComboBox.SelectedItem != null)
            {
                fileName = Convert.ToString(this.fileNameComboBox.SelectedItem);
                artistComboBox.SelectedItem = null;
                albumComboBox.SelectedItem = null;
                genreComboBox.SelectedItem = null;
            }

            try
            {
                object datasource =
                    (tableController.GetCustomizedViewByTableName(
                    (int)pageSizeNumericUpDown.Value,
                    currentPage,
                    album,
                    artist,
                    genre,
                    fileName));
                if (datasource != null)
                {
                    mainDataGridView.DataSource = datasource;
                }
            }
            catch (Exception exception)
            {
            }
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

        private void GetPreviousePage()
        {
            mainDataGridView.Columns.Clear();

            if (currentPage > 1)
            {
                currentPage--;
            }

            FillDataGridViewWithFilter();
        }

        private void GetNextPage()
        {
            mainDataGridView.Columns.Clear();

            currentPage++;

            FillDataGridViewWithFilter();


            if (mainDataGridView.RowCount <= 0)
            {
                currentPage--;
            }

        }

        private void nextPageToolStripButton_Click(object sender, EventArgs e)
        {
            GetNextPage();
            this.pageNumberToolStripButton.Text = currentPage.ToString();
        }

        private void saveFilteredDataToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoreRenamedFilesToSelectedDirectory(tableController.ResultList);
        }

        private void StoreRenamedFilesToSelectedDirectory(System.Collections.Generic.List<global::Model.ResultTable> list)
        {
            audioFileManager.StoreFileList(tableController.ResultList);
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableController.ClearDataBase();
        }

        private void pageSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FillDataGridViewWithFilter();
        }

    }

}
