using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CurrencyConverter.CurrencyConverterService;

namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint BeepType);
        public Form1()
        {
            InitializeComponent();
            monthCalendar.MinDate = Convert.ToDateTime("1.01.2010");
            monthCalendar.MaxDate = DateTime.Today;
            //dateBox.Text = monthCalendar.TodayDate.ToShortDateString();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateBox.Text = e.Start.ToShortDateString() ;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            DateTime temp;
            CurrencyConverterClient client = new CurrencyConverterClient();
            if(DateTime.TryParse(dateBox.Text, out temp))
            {
                textBoxResault.Text =
                    Convert.ToString(client.Convert(currencyComboBox.Text, "UAH", Convert.ToDouble(this.numericUpDown1.Text),
                                                    Convert.ToDateTime(this.dateBox.Text)));
            }
            else
            {
                MessageBox.Show(" Выберите дату ", " Ошибка! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(textBoxResault.Text != "Результат операции")
            {
                Form2 form2 = new Form2();
                form2.Show();
                MessageBeep(0x00000040);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrencyConverterClient client = new CurrencyConverterClient();
            List<string> liststr = new List<string>();
            liststr = client.GetCurrentcyList();
            for (int i = 0; i <liststr.Count ; i++)
            {
                currencyComboBox.Items.Add(liststr[i]);
            } 
        }


    }
}
