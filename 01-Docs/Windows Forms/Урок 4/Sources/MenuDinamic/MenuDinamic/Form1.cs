using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuDinamic
{
    public partial class Form1 : Form
    {
        MenuStrip m;
        public Form1()
        {
            InitializeComponent();
            m = new MenuStrip();
            //добавляем меню верхнего уровня
            ToolStripMenuItem file= (ToolStripMenuItem)m.Items.Add("File");
            ToolStripMenuItem edit = (ToolStripMenuItem)m.Items.Add("Edit");
            this.MainMenuStrip = m;
            this.Controls.Add(m); //добавляем меню на форму

            //добавляем выпадающее меню для пункта Edit
            edit.DropDownItems.Add("Cut");
            //добавляем сепаратор
            edit.DropDownItems.Add(new ToolStripSeparator());
            edit.DropDownItems.Add("Copy");
            //добавляем сепаратор
            edit.DropDownItems.Add(new ToolStripSeparator());
            edit.DropDownItems.Add("Pastle");

            //Добвыляем выпадающее меню для пункта File
            ToolStripMenuItem close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            //связываем меню с акселератором Alt+C
            close.ShortcutKeys =  Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true; //отображать акселераторы
            //добавляем обработчик для пункта меня Close
            close.Click += new EventHandler(close_Click); 
        }

        void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
