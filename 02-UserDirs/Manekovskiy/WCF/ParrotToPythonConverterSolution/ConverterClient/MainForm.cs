using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConverterClient.ConverterServiceReference;

namespace ConverterClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void getResultButton_Click(object sender, EventArgs e)
        {
            using (var client = new ParrotToPythonConverterClient())
            {
                if (parrotsUpDown.Value == 0)
                {
                    // convert pyhtons to parrots
                    parrotsUpDown.Value = (decimal)client.ConvertPythonsToParrots((double)pythonsUpDown.Value);
                }
                if (pythonsUpDown.Value == 0)
                {
                    // convert parrots to pythons
                    pythonsUpDown.Value = (decimal)client.ConvertParrotsToPythons((double)parrotsUpDown.Value);
                }
            }
        }
    }
}