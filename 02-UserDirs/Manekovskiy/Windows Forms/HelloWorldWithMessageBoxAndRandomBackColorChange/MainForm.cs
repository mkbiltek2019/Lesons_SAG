using System;
using System.Windows.Forms;

using Helpers; // Подключаем пространство имен в котором содержится класс RandomColorGenerator


namespace HelloWorldWithMessageBoxAndRandomBackColorChange
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowMessageBoxButton_Click(object sender, EventArgs e)
        {
            // TODO: Вывести MessageBox с текстом из текстовых полей ввода
        }

        private void ChangeBackColorOfEveryControlButton_Click(object sender, EventArgs e)
        {
            this.BackColor = RandomColorGenerator.Generate24BytesColor();
            // TODO: дописать логику для изменения цвета BackColor для всех элементов управления на форме
        }
    }
}