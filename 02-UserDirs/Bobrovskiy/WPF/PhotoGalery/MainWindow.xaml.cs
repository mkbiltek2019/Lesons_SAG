#define VISUALCHILD

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ClassLibrary;

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
            String path = ((sender as ListBox).SelectedItem.ToString());
            BitmapSource img = BitmapFrame.Create(new Uri(path));
            CurrentPhoto.Source = img;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClassLibrary.BrowserWrapper browserWrapper = new BrowserWrapper();
           
            Photos.Path = browserWrapper.GetFolderPath(); 
           
        }

    }
}