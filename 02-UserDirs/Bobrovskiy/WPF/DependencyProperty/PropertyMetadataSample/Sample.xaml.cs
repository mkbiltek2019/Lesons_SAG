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
using System.Windows.Shapes;

namespace PropertyMetadataSample
{
    public partial class Sample : Window
    {
        public DepObj1 Obj1 { get; set; }
        public DepObj2 Obj2 { get; set; }
        public DepObj3 Obj3 { get; set; }
        public DepObj4 Obj4 { get; set; }
        
        public Sample()
        {
            Obj1 = new DepObj1();
            Obj2 = new DepObj2();
            Obj3 = new DepObj3();
            Obj4 = new DepObj4();
            InitializeComponent();
            HandleChangesPropertyMetadata.AddPropertyChanged(DepObj1.TestProperty, Obj2.DependencyObjectType,
                                                             OnTestChanged);
            HandleChangesPropertyMetadata.AddPropertyChanged(DepObj1.TestProperty, Obj3.DependencyObjectType,
                                                             OnTestChanged);
            HandleChangesPropertyMetadata.AddPropertyChanged(DepObj4.TestProperty, Obj4.DependencyObjectType,
                                                             OnTestChanged);
        }

        private static void OnTestChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show(string.Format("Type: {0}, Old value: {1}, New value: {2}", sender.GetType(), e.OldValue,
                                          e.NewValue));
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Obj1.Test++;
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Obj2.Test++;
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Obj3.Test++;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Obj4.Test++;
        }
    }
}
