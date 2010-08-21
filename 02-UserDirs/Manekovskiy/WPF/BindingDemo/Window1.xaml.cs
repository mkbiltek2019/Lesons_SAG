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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private DataModel dataModel;
        protected DataModel MyDataModel
        {
            get
            {
                if (dataModel == null)
                {
                    dataModel = GetDataModel();
                }
                return dataModel;
            }
        }

        private DataModel GetDataModel()
        {
            return new DataModel();
        }

        public Window1()
        {
            InitializeComponent();
        }
    }
}
