using System;
// пространство для Windows.Forms
using System.Windows.Forms;
namespace HelloWinFormsWorld{
	class FirstWinFormApp{
		public static void Main(){
			// создание объекта класса формы
			Form frm = new Form();
			// задаём заголовок формы
			frm.Text = "First Windows Forms application";
			// отображаем форму на экран пользователю 
			// для этого мы используем метод для отображения модальных диалогов
			frm.ShowDialog();	
		}
	}
}