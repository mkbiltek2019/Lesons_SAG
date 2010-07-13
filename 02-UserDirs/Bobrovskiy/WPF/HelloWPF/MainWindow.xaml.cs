using System;
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

            LoadColorToComboBox(this.colorComboBox);

            cucumbers = CucumberStore.LoadCucumbers()
               .ToList();
        }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.cucumberListBox.Items.Clear();
           
            foreach (Cucumber cucumber in cucumbers)
	        { 
                TextBlock cucumberTextBlock = new TextBlock() { FontSize = 16, Background = new SolidColorBrush(cucumber.Color) };
                cucumberTextBlock.Inlines.Add(new Bold(new Run("Color:")));
                cucumberTextBlock.Inlines.Add(new Run(cucumber.Color + Environment.NewLine));

                cucumberTextBlock.Inlines.Add(new Bold(new Run("Dots:")));
                cucumberTextBlock.Inlines.Add(new Run(cucumber.DotsCount + Environment.NewLine));

                cucumberTextBlock.Inlines.Add(new Bold(new Run("Price:")));
                cucumberTextBlock.Inlines.Add(new Run(cucumber.TotalPrice + Environment.NewLine));

                cucumberListBox.Items.Add(cucumberTextBlock);
	        }

            //cucumberListBox.Height = this.CucumberStackPanel.Height;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {   // cucumber add

            int dots = Convert.ToInt32(this.dotsTextBox.Text);
            int pricePerDot = Convert.ToInt32(this.pricePerDotTextBox.Text);
            Color color = (Color)ColorConverter.ConvertFromString(colorComboBox.SelectedItem.ToString());

            cucumbers.Add(new Cucumber()
                              {
                                  DotsCount = dots,
                                  Color = color,
                                  PricePerDot = pricePerDot 
                              });

        }
    }
}
