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

namespace DispatcherSample
{
    /// <summary>
    /// Interaction logic for Sample.xaml
    /// </summary>
    public partial class Sample : Window
    {
        private Dispatcher UiDispatcher { get; set; }
        private Dispatcher BackgroundDispatcher { get; set; }

        private readonly object SyncObj = new object();
        private bool stop;

        private bool Stop
        {
            get
            {
                lock (SyncObj)
                {
                    return stop;
                }
            }
            set
            {
                lock (SyncObj)
                {
                    stop = value;
                }
            }
        }
        
        public Sample()
        {
            InitializeComponent();
            UiDispatcher = Dispatcher.CurrentDispatcher;
            new Thread(CreateBackgoundThread).Start();
        }

        private void CreateBackgoundThread()
        {
            BackgroundDispatcher = Dispatcher.CurrentDispatcher;
            Dispatcher.Run();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            prg.Value = prg.Minimum;
            Stop = false;
            BackgroundDispatcher.BeginInvoke(new Action(Start));
        }

        private void Start()
        {
            while ((bool) UiDispatcher.Invoke(new Func<bool>(() => prg.Value < prg.Maximum)))
            {
                if (Stop) return;
                UiDispatcher.Invoke(new Action(() => prg.Value++));
                Thread.Sleep(100);
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Stop = true;
        }
    }
}