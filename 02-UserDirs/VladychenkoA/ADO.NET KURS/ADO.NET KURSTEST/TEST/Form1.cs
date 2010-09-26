using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void currencyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.currencyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.exchange_Rates_NBUDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exchange_Rates_NBUDataSet.Rates' table. You can move, or remove it, as needed.
            this.ratesTableAdapter.Fill(this.exchange_Rates_NBUDataSet.Rates);
            // TODO: This line of code loads data into the 'exchange_Rates_NBUDataSet.Currency' table. You can move, or remove it, as needed.
            this.currencyTableAdapter.Fill(this.exchange_Rates_NBUDataSet.Currency);

        }
    }
}
