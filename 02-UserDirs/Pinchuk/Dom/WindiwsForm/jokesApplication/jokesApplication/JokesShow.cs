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
    public partial class JokesShow : Form
    {
        public JokesShow()
        {
            InitializeComponent();
        }

       
        private void JokesShow_Load(object sender, EventArgs e)
        {
            XElement jokesDataEventHendler = DataSender.JokesDataEventHendler();
           Text = jokesDataEventHendler.Element("Title").Value;
            lbJokes.Text = jokesDataEventHendler.Element("Content").Value;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!rbnBoring.Checked && !rbnFuny.Checked)
                MessageBox.Show("Ви не висловили своєї думки про жарт!");
            else
            {

                DataSender.StatisticJokesEventHendler = new DataSender.StatisticJokesEvent(() => rbnFuny.Checked);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
