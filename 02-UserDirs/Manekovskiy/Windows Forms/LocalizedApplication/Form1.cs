using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace LocalizedApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string locale = ConfigurationManager.AppSettings["locale"];
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale);

            InitializeComponent();

            comboBox1.Items.AddRange(GetAvailableLocales());
        }

        private CultureInfo[] GetAvailableLocales()
        {
            return new[]{ 
                CultureInfo.InvariantCulture, 
                CultureInfo.GetCultureInfo("en-US"), 
                CultureInfo.GetCultureInfo("ru-RU")};
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            currentConfig.AppSettings.Settings["locale"].Value = comboBox1.SelectedItem.ToString();
            currentConfig.Save();
        }
    }
}
