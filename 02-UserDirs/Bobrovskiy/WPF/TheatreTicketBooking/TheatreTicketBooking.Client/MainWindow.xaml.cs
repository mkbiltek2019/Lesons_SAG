using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using TheatreTicketBooking.Client.Entities;

namespace TheatreTicketBooking.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }      

        private void ShowForm(object sender, EventArgs e)
        {
            TicketWindows win3 = new TicketWindows();

            Messenger.Default.Send<PremiereSelectedMessage>(new PremiereSelectedMessage()
            { Premiere = (Premiere)mainListBox.SelectedItem });

            win3.ShowDialog();
        }
       
    }
}
