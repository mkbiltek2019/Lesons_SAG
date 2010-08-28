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
using System.Windows.Threading;

namespace DependencyPropertyDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static event PropertyChangedCallback MySuperFlagChanged;

        public bool MySuperFlag
        {
            get 
            { 
                return (bool)GetValue(MySuperFlagProperty); 
            }
            set 
            { 
                SetValue(MySuperFlagProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for MySuperFlag.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MySuperFlagProperty =
            DependencyProperty.Register("MySuperFlag", 
                                        typeof(bool), 
                                        typeof(Window1), 
                                        new UIPropertyMetadata(false, OnMySuperFlagChanged));

        public Window1()
        {
            InitializeComponent();

            MySuperFlagChanged += Window1_MySuperFlagChanged;
        }

        void Window1_MySuperFlagChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            oldValueTextblock.Text = Convert.ToString(e.OldValue);
            newValueTextblock.Text = Convert.ToString(e.NewValue);
        }

        public static void OnMySuperFlagChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (MySuperFlagChanged != null)
            {
                MySuperFlagChanged.Invoke(sender, e);
            }
        }
    }
}
