using System.Data;
using System.Data.SqlClient;
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

        }

        private void deleteToolStripButton_Click(object sender, System.EventArgs e)
        {

        }     
    }

}
