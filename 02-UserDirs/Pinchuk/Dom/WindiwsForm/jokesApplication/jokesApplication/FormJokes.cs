using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace jokesApplication
{
    public partial class FormJokes : Form
    {
        private XmlReader xmlReader;
        private int countBoring;
        private int countFuny;
        public FormJokes()
        {
            countFuny = 0;
            countBoring = 0;
            InitializeComponent();
            UpdateStatistic();
        }

        private void UpdateStatistic()
        {
            lbBoring.Text = String.Format("Не смішних: {0} шт. ", countBoring);
            lbFuny.Text = String.Format("Смішних: {0} шт.",countFuny);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = !ShowInTaskbar;
        }

        private void HiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = !ShowInTaskbar;
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tbJoksFileName.Text))
                {
                    tbJoksFileName.Text = GetFileName();

                }
                if (xmlReader == null)
                    xmlReader = new XmlReader(tbJoksFileName.Text);

                XElement xElement = xmlReader.GetJoks();
                if (xElement == null)
                    MessageBox.Show("В даному файлі жарти закінчились!");
                else
                {
                    DataSender.JokesDataEventHendler = new DataSender.JokesDataEvent(() => xElement);
                    DialogResult dialogResult = (new JokesShow()).ShowDialog();
                    
                    switch (dialogResult)
                    {
                        case DialogResult.OK:
                            if (DataSender.StatisticJokesEventHendler())
                            {
                                countFuny++;
                            }
                            else
                            {
                                countBoring++;
                            }
                            break;

                    }
                    UpdateStatistic();
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            tbJoksFileName.Text = GetFileName();
        }
        public string GetFileName()
        {
            string result = String.Empty;
            if (ofdJokesFileName.ShowDialog() == DialogResult.OK)
            {
                 result=ofdJokesFileName.FileName;
                 xmlReader = new XmlReader(result);
            }
            return result;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }
        
       

        

        
    }
}
