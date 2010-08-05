using System;
using System.Windows;
using System.Windows.Data;

namespace PhotoGallery
{
    public partial class app : Application
    {

        void AppStartup(object sender, StartupEventArgs args)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            mainWindow.Photos = 
                (PhotoList)(this.Resources["Photos"] as ObjectDataProvider).Data;

            mainWindow.Photos.Path = "..\\..\\Photos";                    
        }

    }
}