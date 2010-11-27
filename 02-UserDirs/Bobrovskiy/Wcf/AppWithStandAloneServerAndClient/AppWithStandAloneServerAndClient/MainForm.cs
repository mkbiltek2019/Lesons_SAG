using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppWithStandAloneServerAndClient.WCF_Server;

namespace AppWithStandAloneServerAndClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ServiceManager serviceManager = new ServiceManager();

        private void startButton_Click(object sender, EventArgs e)
        {
            serviceManager.Start();

            this.stateTextBox.Text = serviceManager.GetData().State;
            this.typeTextBox.Text = serviceManager.GetData().Type;
            this.nameTextBox.Text = serviceManager.GetData().Name;
            this.namespaceTextBox.Text = serviceManager.GetData().NameSpace;

            this.addressesListBox.DataSource = serviceManager.GetData().AddressesCollection;
            this.namesListBox.DataSource = serviceManager.GetData().BindingCollection;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            serviceManager.Stop();
        }
    }
}
