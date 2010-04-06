using System;
// пространство для Windows.Forms
using System.Windows.Forms;
namespace HelloWinFormsWorld{
	class MyForm : Form{
		public MyForm(string caption){
			Text = caption;
		}
	}
	class FirstWinFormApp{
		public static void Main(){
			// создание объекта пользовательского класса формы
			// запуск обработки очереди сообщений и отображение формы
			Application.Run(new MyForm("Hello, world!!!"));
		}
	}
}




