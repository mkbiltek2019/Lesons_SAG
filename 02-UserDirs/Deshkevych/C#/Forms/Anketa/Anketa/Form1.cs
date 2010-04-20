using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anketa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //установим по умолчанию пол мужской
            radioButtonMale.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //собираем в строку анкетные данные
            string strMessage = "ФИО: " + textBoxFamali.Text +
                                " " + textBoxImja.Text + " " + textBoxOtchestvo.Text + "\n";
            strMessage += "Место проживания: " + textBoxStrana.Text + ", г." 
                + textBoxGorod.Text + "\n";
            strMessage += "Телефон: " + textBoxTelefon.Text + "\n";
            strMessage += "Дата рождения: " + dateTimePicker1.Value.ToLongDateString() + "\n";

            if (radioButtonMale.Checked == true)
            {
                strMessage += "Пол : Мужской";
            }
            else
            {
                strMessage += "Пол : Женский";
            }

            //Выводим анкетные данные в диалоговое окно
            MessageBox.Show(strMessage, "Анкетные данные");
        }

        
    }
}
