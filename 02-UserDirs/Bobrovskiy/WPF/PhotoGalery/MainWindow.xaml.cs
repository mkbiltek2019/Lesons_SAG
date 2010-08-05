#define VISUALCHILD
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using ClassLibrary;
using ListBox = System.Windows.Controls.ListBox;

namespace PhotoGallery
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public PhotoList Photos;

        private void PhotoListSelection(object sender, RoutedEventArgs e)
        {
            if (sender != null && ((sender as ListBox).HasItems))
            {
                String path = ((sender as ListBox).SelectedItem.ToString());

                BitmapSource img = BitmapFrame.Create(new Uri(path));

                CurrentPhoto.Source = img;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SetFolderPath((new BrowserWrapper()).GetFolderPath());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SetFolderPath((new FolderBrowserDialogExWrapper()).GetFolderPath());
        }

        private void SetFolderPath(string folderPath)
        {
            string path = folderPath;
            if (!string.IsNullOrEmpty(path))
            {
                Photos.Clear();
                Photos.Path = path;
            }
        }
    }
}