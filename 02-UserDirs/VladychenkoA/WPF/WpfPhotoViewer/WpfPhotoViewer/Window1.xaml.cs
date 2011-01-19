using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using ListBox = System.Windows.Controls.ListBox;

namespace WpfPhotoViewer
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public List<Photo> ListPhoto = new List<Photo>();

        private void PhotoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             if (sender != null && ((sender as ListBox).HasItems))
             {
                string path = ((sender as ListBox).SelectedItem.ToString());
                BitmapSource image = BitmapFrame.Create(new Uri(path));
                ImagePhoto.Source = image;
             }
        }

        private void Открыть_Click(object sender, RoutedEventArgs e)
        {
            SetFolder(GetFolderPath());
            PhotoListBox.DataContext = ListPhoto;
        }

        
        private void SetFolder(string path)
        {
           DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (FileInfo file in directoryInfo.GetFiles("*.jpg"))
            {
                ListPhoto.Add(new Photo(file.FullName));
            }
        }
        private string GetFolderPath()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                DialogResult result = fbd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return fbd.SelectedPath;
                }
            }
            return string.Empty;
        }
        public class Photo
        {
            private string _path;
            private Uri _uri;
            private BitmapFrame _image;
            public string Path
            {
                get { return _path; }
                set { _path = value; }
            }
            public Uri Uri
            {
                set { _uri = value; }
                get { return _uri; }
            }
            public BitmapFrame Image
            {
                set { _image = value; }
                get { return _image; }
            }
            public Photo(string path)
            {
                _path = path;
                _uri = new Uri(_path);
                _image = BitmapFrame.Create(_uri);
            }
            public override string ToString()
            {
                return Path;
            }
        }
    }
}
