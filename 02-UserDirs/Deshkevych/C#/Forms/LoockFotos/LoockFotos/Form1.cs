using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LoockFotos
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
       private 
            int pbh,//исходная высота
                pbw;//ширина элемента pictureBox1
        

        //формирует список иллюстраций в ListBox,
        //aPath-путь к папке с файлами
        private Boolean FillListBox(string Path)
        {
            //информация о каталоге
            DirectoryInfo di = new DirectoryInfo(Path);

            //массив информации о файлах
            FileInfo[] fi = di.GetFiles("*.jpg");

            //очищаем ранее полученный список файлов
            listBox1.Items.Clear();

            //добавляем в ListBox1 имена jpg-файлов,
            //содержащихся в каталоге Path

            foreach (FileInfo fc in fi)
            {
                listBox1.Items.Add(fc.Name);
            }

            label1.Text = Path;
            if (fi.Length == 0)
            {
                return false;
            }
            else
            {
                //выбираем первый файл из полученого списка
                listBox1.SelectedIndex = 0;
                return true;
            }
        }
        //загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            pbh = pictureBox1.Height;
            pbw = pictureBox1.Width;

            //элементы ListBox1 сортируются в алфовитном порядке
            listBox1.Sorted = true;

            //Application.StartupPath возвращает путь к каталогу,
            //из которого была запущена программа;
            //заполняем ListBox1 списком иллюстраций
            FillListBox(Application.StartupPath + "\\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //диалоговое окно выбора каталога
            FolderBrowserDialog fb = new FolderBrowserDialog();

            fb.Description = "Выберите папку";
            fb.ShowNewFolderButton = false;

            //отображаем диалоговое окно
            if (fb.ShowDialog() == DialogResult.OK)
                //пользователь выбрал каталог и 
                //щелкнул на кнопке OK
                if (!FillListBox(fb.SelectedPath + "\\"))
                    //в каталоге нет файлов , выгружаем
                    //из pictureBox1 ранее отображаемый файл
                    pictureBox1.Image = null;
           
        }

        //пользователь выбрал файл щелчком кнопки мыши
        //или перемещением по списку при помощи клавиатуры
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double mh, mw;//коэфициэнт масштабирования

            //загружаем изображения в pictureBox1
            pictureBox1.Image = new Bitmap(label1.Text + listBox1.SelectedItem.ToString());

            //масштабируем, если нужно
            if ((pictureBox1.Image.Width > pbw)||(pictureBox1.Image.Height > pbh))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                mh = (double)pbh/(double) pictureBox1.Image.Height;
                mw = (double) pbw/(double) pictureBox1.Image.Width; 

                if (mh<mw)
                {
                    //масштабируем по ширине
                    pictureBox1.Width = Convert.ToInt16(pictureBox1.Image.Width*mh);
                    pictureBox1.Height = pbh;

                }
                else
                {
                    //масштабируем по высоте
                    pictureBox1.Width = pbw;
                    pictureBox1.Height = Convert.ToInt16(pictureBox1.Image.Height*mw);

                }
            }
            else
            {
                //если предыдущее изображение масштабировалось
                if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }
            }

        }


    }

        
}

