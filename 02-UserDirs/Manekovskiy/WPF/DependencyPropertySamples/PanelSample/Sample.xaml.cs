using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace PanelSample
{
    /// <summary>
    /// Interaction logic for Sample.xaml
    /// </summary>
    public partial class Sample : Window
    {
        public Sample()
        {
            InitializeComponent();
        }

        private void IsLeftToRightArrangeDirectionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SpacePanel.ArrangeDirection = IsLeftToRightArrangeDirectionCheckBox.IsChecked.Value ? ArrangeDirection.LeftToRight : ArrangeDirection.TopToBottom;
        }  
    }
}