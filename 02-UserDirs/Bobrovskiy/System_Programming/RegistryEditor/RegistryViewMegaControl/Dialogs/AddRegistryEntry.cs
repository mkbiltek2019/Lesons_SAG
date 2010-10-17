using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegistryViewMegaControl.Dialogs
{
    public partial class AddRegistryEntryDialDialog : Form
    {
        public AddRegistryEntryDialDialog(string fullName)
        {
            InitializeComponent();

            this.typeComboBox.Items.Add(RegistryValueKind.String);
            this.typeComboBox.Items.Add(RegistryValueKind.MultiString);
            this.typeComboBox.Items.Add(RegistryValueKind.DWord);
            //this.typeComboBox.Items.Add(RegistryValueKind.Binary);
            //this.typeComboBox.Items.Add(RegistryValueKind.QWord);
            //this.typeComboBox.Items.Add(RegistryValueKind.ExpandString);
            //this.typeComboBox.Items.Add(RegistryValueKind.None);
            //this.typeComboBox.Items.Add(RegistryValueKind.Unknown);
        }

        public string RegistryKeyName
        {
            get; 
            set;
        }

        public object RegistryKeyType
        {
            get;
            set;
        }

        public object RegistryKeyValue
        {
            get; 
            set;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            RegistryKeyName = this.nameTextBox.Text;
            RegistryKeyValue = this.valueTextBox.Text;
            RegistryKeyType = typeComboBox.SelectedItem;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
