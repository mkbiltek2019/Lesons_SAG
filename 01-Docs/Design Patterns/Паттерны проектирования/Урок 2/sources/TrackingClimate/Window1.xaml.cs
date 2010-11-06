using System;
using System.Windows;

namespace TrackingClimate
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        FacadeCalculateSystem LogicSystem;
        ProxyHardware Hardes;
        
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortDateString();
            LogicSystem = new FacadeCalculateSystem();
            Hardes = new ProxyHardware();
        }

        // Записать погоду
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            LogicSystem.AddDay(Convert.ToDateTime(textBox2.Text), Convert.ToInt32(textBox1.Text));
        }

        // Подсчет данных
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Plan a = LogicSystem.GetPlan(Convert.ToDateTime(textBox2.Text));
            textBoxLitter.Text = a.Litters.ToString();
            textBoxMinuts.Text = a.Interval.TotalMinutes.ToString();
        }

        // Выполнить полив.
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Plan NewPlan = new Plan();
            NewPlan.Litters = Convert.ToInt32(textBoxLitter.Text);
            NewPlan.Interval = new TimeSpan(0, 0, Convert.ToInt32(textBoxMinuts.Text), 0);
            Hardes.Watering(NewPlan);
        }
    }
}
