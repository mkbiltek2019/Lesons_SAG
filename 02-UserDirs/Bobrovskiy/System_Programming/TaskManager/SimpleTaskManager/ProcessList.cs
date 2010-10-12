using System.Windows.Forms;
using TaskManager.Controller;

namespace SimpleTaskManager
{
    public partial class ProcessList : UserControl
    {
        private TaskManagerModel selectedRow = null;
       
        public TaskManagerModel SelectedRow
        {
            get
            {
                return selectedRow;
            }
        }

        public ProcessList()
        {
            InitializeComponent();
            LoadDataOnStartUp();
        }

        private DataExtractor _dataExtractor = new DataExtractor();

        private void LoadDataOnStartUp()
        {
            dataGridView.DataSource = _dataExtractor.ExtractData();
        }

        public void Update()
        {
            dataGridView.DataSource = null;
            LoadDataOnStartUp();
        }

        public void KillSelectedProcess()
        {
            if (selectedRow != null)
            {
                _dataExtractor.KillProcessById(selectedRow.ProcessPID);
            }
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //TODO: here you can add collumns sorting 
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                selectedRow = (TaskManagerModel)dataGridView.SelectedRows[0].DataBoundItem;
            }
        }

    }
}
