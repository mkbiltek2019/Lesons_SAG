using System;
using System.Collections;
using FileSearcherBackgroundWorker;
using FillDataBaseBackgroundWorker;
using Model;
using mp3Collader.Controllers;
using MyBackgroundWorker;

namespace mp3Collader
{
    public partial class mainForm
    {
        private TableController tableController; 
        private int currentPage = 1;

        private const int defaultCapacity = 5000;
        private Hashtable fileList = new Hashtable(defaultCapacity);
        
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

            foreach (Model.SimpleTable value in tableController.GetListByTableName(TableList.FileName))
            {
                fileNameComboBox.Items.Add(value.Name);
            }

        }

        private void FillDataGridViewWithFilter()
        {
            mainDataGridView.Columns.Clear();

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
                    mainDataGridView.DataSource = (IList)datasource;
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void StoreRenamedFilesToSelectedDirectory()
        { 
            SaveForm dialog = new SaveForm(tableController.ResultList);
            dialog.ShowDialog();
        }
        
        private void GetFileListFromSelectedFolder()
        {
            FileSearcherForm m = new FileSearcherForm();
            m.ShowDialog();

            fileList = m.FileList;
        }

        private void FillDatabase()
        {
            System.Collections.IDictionaryEnumerator FileListEnumerator;
            FileListEnumerator = fileList.GetEnumerator();

            DataFillerForm fileWorker = new DataFillerForm(FileListEnumerator);
            fileWorker.ShowDialog();
        }

        private void ClearDatabase()
        {
            tableController.ClearDataBase();
        }

    }//class
} //namespace
