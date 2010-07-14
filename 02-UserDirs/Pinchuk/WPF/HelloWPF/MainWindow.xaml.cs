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
using HelloWPF.Model;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Cucumber> cucumbers;

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cucumbers = CucumberStore.LoadCucumbers()
                .ToList();
            foreach (Cucumber cucumber in cucumbers)
            {
                TextBlock cucumberTextBlock = new TextBlock() { FontSize = 16, Background = new SolidColorBrush(cucumber.Color) };
                cucumberTextBlock.Inlines.Add(new Bold(new Run("Color:")));
                cucumberTextBlock.Inlines.Add(new Run(cucumber.Color + Environment.NewLine));

                cucumberTextBlock.Inlines.Add(new Bold(new Run("Dots:")));
                cucumberTextBlock.Inlines.Add(new Run(cucumber.DotsCount + Environment.NewLine));

                cucumberTextBlock.Inlines.Add(new Bold(new Run("Price:")));
                cucumberTextBlock.Inlines.Add(new Run(cucumber.TotalPrice + Environment.NewLine));

                CucumberStackPanel.Children.Add(cucumberTextBlock);
            }
        }

        private void expander_Expanded(object sender, RoutedEventArgs e)
        {
            grid.ColumnDefinitions.ElementAtOrDefault(2).Width = new GridLength(Convert.ToDouble(Properties.Resources.EpanderWidthExpandet), GridUnitType.Pixel); ;
            MyWindows.Width = MyWindows.Width + Convert.ToDouble(Properties.Resources.DeltaForms);
        }

        private void expander_Collapsed(object sender, RoutedEventArgs e)
        {
            grid.ColumnDefinitions.ElementAtOrDefault(2).Width = new GridLength(Convert.ToDouble(Properties.Resources.EpanderWidthCollapsed), GridUnitType.Pixel); ;
            MyWindows.Width = MyWindows.Width - Convert.ToDouble(Properties.Resources.DeltaForms);
        }
    }
}
