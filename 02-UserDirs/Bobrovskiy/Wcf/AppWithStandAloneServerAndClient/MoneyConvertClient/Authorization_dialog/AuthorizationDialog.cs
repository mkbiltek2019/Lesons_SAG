using System;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Messaging;
using MoneyConvertClient.Classes;
using MoneyConvertClient.Classes.Validation;

namespace MoneyConvertClient.Authorization_dialog
{
    public partial class authorizationDialog : Form
    {
        public authorizationDialog()
        {
            InitializeComponent();
        }

        private void authorizationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void authorizationDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void logonButton_Click(object sender, EventArgs e)
        {
            //send authorization data to mainform and
            Validator validator = new Validator();
            validator.ValidationState += new Action<string>(client_DoReport);

           // Authentification auth = new Authentification();
            string log = validator.ValidateText(this.loginTextBox.Text);
            string passwd = validator.ValidateText(this.passwordMaskedTextBox.Text);

            if (validator.DataIsValid)
            {
                Messenger.Default.Send<Authentification>(new Authentification() { Login = log, Password = passwd });
                this.Close();
            }
        }

        private void client_DoReport(string obj)
        {
            MessageBox.Show("Login or password invalide.");
        }
    }
}
