using System;
using System.Windows.Forms;

namespace FifthSample
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
            string strMessage = "ФИО: " + textBoxSName.Text
                + " " + textBoxName.Text + " " + textBoxPatronymic.Text+"\n";
            strMessage += "Место проживания: " + textBoxCountry.Text
                + ", г." + textBoxCity.Text + "\n";
            strMessage += "Телефон: " + textBoxPhone.Text + "\n";

            strMessage += "Дата рождения: " + dateTimePickerBirthday.Value.ToLongDateString()
                + "\n";

            if (radioButtonMale.Checked == true)
            {
                strMessage += "Пол: мужской";
            }
            else
            {
                strMessage += "Пол: женский";
            }

            //выводим анкетные данные в диалоговое окно
            MessageBox.Show(strMessage,"Анкетные данные");
        }
    }
}
