using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimplyNotepadCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Можно программно задавать доступные для обзора расширения файлов. 
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            //Если выбран диалог открытия файла, выполняем условие
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
           
                //Если файл не выбран, возвращаемся (появится встроенное предупреждение)
                if (openFileDialog1.FileName == "")
                {
                    return;
                }
                else
                {
                    //Создаем новый объект StreamReader и передаем ему переменную OpenFileName
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    //Читаем весь файл и записываем его в richTextBox1
                    richTextBox1.Text = sr.ReadToEnd();
                    // Закрываем поток
                    sr.Close();
                    //Переменной DocName присваиваем адресную строку.
                    DocName = openFileDialog1.FileName;
                }			

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fontDialog1.ShowColor = true;
            //Связываем свойства SelectionFont и SelectionColor элемента RichTextBox 
            //с соответствующими свойствами диалога
            fontDialog1.Font = richTextBox1.SelectionFont;
            fontDialog1.Color = richTextBox1.SelectionColor;
            //Если выбран диалог открытия файла, выполняем условие
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.SelectionColor = fontDialog1.Color;
            }
            
            
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            colorDialog1.Color = richTextBox1.SelectionColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Если файл не выбран, возвращаемся (появится встроенное предупреждение)
            if (DocName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamWriter и передаем ему переменную OpenFileName
                StreamWriter sw = new StreamWriter(DocName);
                //Содержимое richTextBox1 записываем в файл
                sw.WriteLine(richTextBox1.Text);
                //Закрываем поток
                sw.Close();
                
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Можно программно задавать доступные для обзора расширения файлов. 
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            //Если выбран диалог открытия файла, выполняем условие
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //Создаем новый объект StreamWriter и передаем ему переменную OpenFileName
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                //Содержимое richTextBox1 записываем в файл
                sw.WriteLine(richTextBox1.Text);
                //Закрываем поток
                sw.Close();       

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }

        private void cutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = BufferText;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll(); 
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
            BufferText = "";
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDlg dlg = new AboutDlg();
            dlg.Show();
        }

           
    }
}