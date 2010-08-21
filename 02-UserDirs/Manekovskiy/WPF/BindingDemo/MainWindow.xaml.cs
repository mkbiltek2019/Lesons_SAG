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

namespace BindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataModel _dataModel;
        private DataModel DataModel
        {
            get
            {
                if(_dataModel == null)
                    _dataModel = (Resources["MyDataModel"] as DataModel);
                return _dataModel;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ChangeRandomUserButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomUserIndex = random.Next(DataModel.Users.Count);

            DataModel.Users[randomUserIndex].Name = Guid.NewGuid().ToString();
            NewUserNameTextBlock.Text = DataModel.Users[randomUserIndex].Name;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User() { Name = Guid.NewGuid().ToString(), Address = new Address() { Country = Guid.NewGuid().ToString(), City = Guid.NewGuid().ToString() } };
            DataModel.Users.Add(newUser);
        }
    }
}
