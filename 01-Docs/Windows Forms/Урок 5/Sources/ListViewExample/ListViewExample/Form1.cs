using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ListViewExample
{
    public partial class Form1 : Form
    {
        ListView table;
        ListBox box;
        public Form1()
        {
            InitializeComponent();
            // создаем экземпляр ListView
            table = new ListView();
            table.SetBounds(400, 10, 300, 200);
            this.Controls.Add(table);
            // добавляем элементы
            table.Items.Add(new ListViewItem("Первый"));
            table.Items.Add(new ListViewItem("Второй"));
            table.Items.Add(new ListViewItem("Третий"));
            table.Items.Add(new ListViewItem("Четвертый"));
            table.Items.Add(new ListViewItem("Пятый"));
            table.View = View.Details;// отображение в виде таблицы
            //Добавляем столбцы
            table.Columns.Add("Столбец 1");
            table.Columns[0].Width = 100;
            table.Columns.Add("Столбец 2");
            table.Columns[1].Width = 100;
            //добавляем подэлементы
            int k=1;
            foreach (ListViewItem i in table.Items)
            {
                i.SubItems.Add("подэлемент " + String.Format("{0}",(k++)));
            }
            // добавляем обработчик DoubleClick
            table.DoubleClick += new System.EventHandler(this.listView_DoubleClick);

            //Добавляем listBox
            box = new ListBox();
            box.SetBounds(300, 300, 300, 200);
            this.Controls.Add(box);
            viewToBox();

        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListView table = (ListView)sender;
            //MessageBox.Show(table.SelectedItems[0].Text);
            // удаляем выбранный элемент
            table.Items.Remove(table.SelectedItems[0]);
        }
        //вывод содержимого ListView в виде ListBox
        private void viewToBox()
        {
            // просмотр коллекции элементов
            foreach (ListViewItem i in table.Items)
            {
                string text = i.Text;
                // просмотр подэлементов в коллекции элементов
                foreach (ListViewItem.ListViewSubItem si in i.SubItems)
                {
                    text += ":" + si.Text;
                }
                box.Items.Add(text);
            }
        }
    }
}