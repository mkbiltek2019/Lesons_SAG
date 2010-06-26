using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsersDictionary.Presenters;
using System.Reflection;

namespace UsersDictionary.Client
{
    public partial class UsersForm : Form
    {
        UserPresenter presenter;

        public UsersForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = presenter;
            dataGridView1.DataMember = "Users";

            presenter = new UserPresenter();
        }

        private void UsersForm_Shown(object sender, EventArgs e)
        {
            presenter.GetNextUserPage();
            dataGridView1.DataSource = presenter;
            
            //Type datagridViewType = dataGridView1.GetType();
            //datagridViewType.InvokeMember(
            //     "OnDataSourceChanged",
            //     BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
            //     null,
            //     dataGridView1,
            //     new object[] { EventArgs.Empty });
            //datagridViewType.InvokeMember(
            //     "RefreshColumnsAndRows",
            //     BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
            //     null,
            //     dataGridView1,
            //     new object[] { });
            
            //this.OnDataSourceChanged.Invoke(EventArgs.Empty);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.GetNextUserPage();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = presenter;
            dataGridView1.DataMember = "Users";
            //presenter.GetNextUserPage();
            //Type datagridViewType = dataGridView1.GetType();
            //datagridViewType.InvokeMember(
            //     "RefreshColumnsAndRows",
            //     BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
            //     null,
            //     dataGridView1,
            //     new object[] { });
        }
    }
}
