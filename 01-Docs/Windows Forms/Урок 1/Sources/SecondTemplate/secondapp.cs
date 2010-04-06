using System;
// пространство для Windows.Forms
using System.Windows.Forms;
namespace HelloWinFormsWorld
{
    // пользовательский класс
    class MyForm : Form
    {
        // конструктор класса
        public MyForm(string caption)
        {
            // задаём заголовок формы
            Text = caption;
        }
    }
    class FirstWinFormApp
    {
        public static void Main()
        {
            // создание объекта пользовательского класса формы
            MyForm frm = new MyForm("Hello, world!!!");
            // отображаем форму на экран пользователю 
            // для этого мы используем метод для отображения модальных диалогов
            frm.ShowDialog();
        }
    }
}