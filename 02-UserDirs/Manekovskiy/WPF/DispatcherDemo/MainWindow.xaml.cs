using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DispatcherDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly object LockObject = new object();
        private bool _stopped;
        public bool Stopped
        {
            get
            {
                lock(LockObject)
                {
                    return _stopped;
                }
            }
            set
            {
                lock(LockObject)
                {
                    _stopped = value;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Stopped = false;
            ProgressBar.Value = 0;
            new Thread(ChangeProgressBar).Start();
        }

        private void ChangeProgressBar()
        {
            int minimum = (int) Dispatcher.Invoke(new Func<int>(() => (int) ProgressBar.Minimum));
            int maximum = (int) Dispatcher.Invoke(new Func<int>(() => (int) ProgressBar.Maximum));

            for (int i = minimum; i < maximum; i++)
            {
                if (Stopped)
                {
                    return;
                }

                Dispatcher.Invoke(new Action(() => ProgressBar.Value++));
                Thread.Sleep(30);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Stopped = true;
        }
    }
}
