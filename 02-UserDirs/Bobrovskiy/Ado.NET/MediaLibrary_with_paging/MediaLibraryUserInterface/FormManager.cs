using System;
using MediaLibraryClient;

namespace MediaLibraryUserInterface
{
    public partial class MainForm
    {
        private string tabPageName = string.Empty;
        private int pageNumber = 1;

        private void FillDataGridViewByTableName(string tableName)
        {
            try
            {
                object datasource = (new MediaLibraryViewFactory()).GetMediaLibraryView(tableName);
                if (datasource != null)
                {
                    mainDataGridView.DataSource = datasource;
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void FillDataGridViewByTableNameAndPageNumberAndSize(string tableName, int pageNumber, int pageSize)
        {
            try
            {
                object datasource = (new MediaLibraryViewFactory()).GetMediaLibraryView(tableName, pageNumber, pageSize);
                if (datasource != null)
                {
                    mainDataGridView.DataSource = datasource;
                }
            }
            catch (Exception exception)
            {
            }

        }
        
        private void FillDataGridView()
        {
            int pageSize = 1;
            if (int.TryParse(pageSizeToolStripComboBox.Text, out pageSize))
            {
                FillDataGridViewByTableNameAndPageNumberAndSize(tabPageName, pageNumber, pageSize);
            }
            else
            {
                FillDataGridViewByTableName(tabPageName);
            }

            pageToolStripLabel.Text = pageNumber.ToString();
        }

        private void GetPreviousePage()
        {
            mainDataGridView.Columns.Clear();

            if (pageNumber > 1)
            {
                pageNumber--;
            }

            FillDataGridView();
        }

        private void GetNextPage()
        {
            mainDataGridView.Columns.Clear();

            pageNumber++;

            FillDataGridView();
        }  

    }

}
