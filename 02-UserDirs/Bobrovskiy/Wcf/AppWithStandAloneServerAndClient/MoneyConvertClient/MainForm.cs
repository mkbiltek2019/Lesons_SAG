using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Messaging;
using MoneyConvertClient.Authorization_dialog;
using MoneyConvertClient.Classes;
using MoneyConvertClient.Classes.ProxyThreadWorker;
using MoneyConvertClient.Classes.Validation;
using MoneyConvertClient.ServiceReference;

namespace MoneyConvertClient
{
    public partial class MainForm : Form
    {
        //TODO: Do not run service operation in UI thread on client and on server side !!!! 

        public MainForm()
        {
            InitializeComponent();

            Messenger.Default.Register<Authentification>(this, OnLoginAndPasswordInput);
        }

        private Authentification auth = null;

        private void OnLoginAndPasswordInput(Authentification obj)
        {
            auth = obj;
        }

        private void client_DoList(MoneyConverterClient obj, object o)
        {
            this.currencyListComboBox.BeginInvoke(new Action<List<string> >(SetComboBoxData), 
                                                  obj.GetCurrentcyList());
        }

        private void SetComboBoxData(List<string> obj)
        {
            this.currencyListComboBox.DataSource = obj;
        }

        private void client_DoReport(string obj)
        {
            this.exceptionLabel.BeginInvoke(new Action<string>(DrawMessage) , obj);
        }

        private void DrawMessage(string message)
        {
            this.exceptionLabel.Text = message;
        }

        private void client_ConvertCurrency(MoneyConverterClient currentConverter, object o)
        {
            DataModelForConverter data = (DataModelForConverter) o;
            double result = currentConverter.Convert(data.SourceCurrency,
                                              data.DestinationCurrency,
                                              data.Amount,
                                              data.Date);

            this.resultTextBox.BeginInvoke(new Action<double>(DrawResult), result);
        }

        private void DrawResult(double obj)
        {
            this.resultTextBox.Text = Convert.ToString(obj);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            validator.ValidationState += new Action<string>(client_DoReport);

            if(this.currencyListComboBox.SelectedItem!=null)
            {
                string currency = validator.ValidateText(this.currencyListComboBox.SelectedItem.ToString());
                double amount = validator.ValidateAndConvertToDouble(this.amountTextBox.Text);

                const string UAH = "UAH";
                DateTime date = DateTime.Now;

                if (validator.DataIsValid)
                {
                    DataModelForConverter data = new DataModelForConverter();
                    data.Amount = amount;
                    data.Date = date;
                    data.DestinationCurrency = UAH;
                    data.SourceCurrency = currency;

                    ProxyWorker<MoneyConverterClient> client = null;
                    client = new ProxyWorker<MoneyConverterClient>(data);
                    client.DoReport += new Action<string>(client_DoReport);
                    client.DoAction += new Action<MoneyConverterClient, object>(client_ConvertCurrency);
                    client.Login = auth.Login;
                    client.Password = auth.Password;

                    client.Start();
                }
            }
            
        }

        private void reconnectButton_Click(object sender, EventArgs e)
        {
            GetCurrencyList();
        }

        private void GetCurrencyList()
        {
            ProxyWorker<MoneyConverterClient> client = null;
            client = new ProxyWorker<MoneyConverterClient>(null);
            client.DoReport += new Action<string>(client_DoReport);
            client.DoAction += new Action<MoneyConverterClient,object>(client_DoList);
            client.Login = auth.Login;
            client.Password = auth.Password;

            client.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            authorizationDialog logonDialog = new authorizationDialog();
            logonDialog.ShowDialog();
        }

    }
}
