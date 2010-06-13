using System.Collections.Generic;
using System.Windows.Forms; 
using MediaLibraryClient;

namespace MediaLibraryUserInterface
{
    public partial class MainForm : Form
    {  
        public MainForm()
        {
            InitializeComponent();
        }


        #region View data

        private void mainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            tabPageName = e.TabPage.Text;
            FillDataGridViewByTableName(tabPageName);
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void downToolStripButton_Click(object sender, System.EventArgs e)
        {
            GetPreviousePage();
        }

        private void upToolStripButton_Click(object sender, System.EventArgs e)
        {
            GetNextPage();
        } 

        #endregion


        private void addToolStripButton_Click(object sender, System.EventArgs e)
        {
           TrackListInsertForm addForm = new TrackListInsertForm();
                addForm.ShowDialog();
        }

        private void modifyToolStripButton_Click(object sender, System.EventArgs e)
        {
            int rowIndex = mainDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowIndex > 0)
            {
                List<string> cellList = new List<string>();
                
                for (int i = 0; i < mainDataGridView.Rows[rowIndex].Cells.Count; i++ )
                {
                   cellList.Add(mainDataGridView.Rows[rowIndex].Cells[i].Value.ToString());
                }

                TrackListInsertForm addForm = new TrackListInsertForm(cellList);
                addForm.ShowDialog();
            }
        } 
         

        private void deleteToolStripButton_Click(object sender, System.EventArgs e)
        {

        } 
         
    }

}
