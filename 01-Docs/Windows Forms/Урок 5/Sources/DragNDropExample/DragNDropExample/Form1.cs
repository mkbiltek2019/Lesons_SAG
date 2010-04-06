using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DragNDropExample
{
    public partial class Form1 : Form
    {
        bool dragstate = false;
        public Form1()
        {
            InitializeComponent();
            // разрешаем списку стать адресатом буксировки
            listBox1.AllowDrop = true;
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // при опускании клавиши мыши выполняем буксировку
            // содержимого источника
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy);
        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            // при попадании на адресат формируем соответствующую иконку 
            // для курсора
            if (e.Data.GetDataPresent(DataFormats.StringFormat)) 
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            // при отпускании кнопки производим копирование данных в элемент списка
            listBox1.Items.Add(e.Data.GetData(DataFormats.StringFormat).ToString());
            dragstate = false;
        }
/*
        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (textBox1.SelectedText.Length != 0 && e.Button == MouseButtons.Left && dragstate == false)
            {
                textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy);
                dragstate = true;
            }

        }
        */
        
        

    }
}