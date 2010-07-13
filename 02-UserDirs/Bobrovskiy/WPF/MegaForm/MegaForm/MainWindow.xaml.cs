using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaForm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private Color startColor = new Color();
        private Color endColor = new Color();
        private double Angle = 0;

        private void LoadColorToComboBox(ComboBox comboBox)
        {
            Type colors = typeof(Colors);
            PropertyInfo[] colorInfo = colors.GetProperties(BindingFlags.Public |
                BindingFlags.Static);
            foreach (PropertyInfo info in colorInfo)
            {
                comboBox.Items.Add(info.Name);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadColorToComboBox(startColorComboBox);
            LoadColorToComboBox(endColorComboBox);
        }

        private void startColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startColor = (Color)ColorConverter.ConvertFromString(startColorComboBox.SelectedItem.ToString());
            this.mainCanvas.Background = createGradient(Angle);
        }

        private void endColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            endColor = (Color)ColorConverter.ConvertFromString(endColorComboBox.SelectedItem.ToString());

            this.mainCanvas.Background = createGradient(Angle);
        }

        private Brush createGradient(double angle)
        {
            if (startColor!=null &&(endColor!=null))
             {
                 //new RadialGradientBrush(startColor, endColor);
                 return new LinearGradientBrush(startColor, endColor, angle);
             }

            return //new RadialGradientBrush(Colors.Black, Colors.Wheat);
                new LinearGradientBrush(Colors.Black, Colors.Wheat, angle);
        }

        private void gradientSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Angle = (e.NewValue);
            this.mainCanvas.Background = createGradient(Angle);
        }
    }
}
