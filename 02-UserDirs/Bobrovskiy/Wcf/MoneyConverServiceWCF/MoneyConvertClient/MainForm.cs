using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MoneyConvertClient.CurrencyConverterService;

namespace MoneyConvertClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CurrencyList curencyList = new CurrencyList();
            client = new CurrencyConverterClient();
            curencyList = client.GetCurrentcyList();
            this.currencyListComboBox.DataSource = curencyList;

        }

        private CurrencyConverterClient client = null;

        private void calculateButton_Click(object sender, EventArgs e)
        {
            string currency = this.currencyListComboBox.SelectedItem.ToString();
            this.resultTextBox.Text = Convert.ToString(client.Convert(currency, 
                                                     "UAH",
                                                     Convert.ToDouble(this.amountTextBox.Text), 
                                                     DateTime.Now));

        }
    }
}
