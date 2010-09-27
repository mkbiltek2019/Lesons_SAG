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
using GalaSoft.MvvmLight.Messaging;
using TheatreTicketBooking.Client.Entities;

namespace TheatreTicketBooking.Client
{
    /// <summary>
    /// Interaction logic for TicketWindows.xaml
    /// </summary>
    public partial class TicketWindows : Window
    {
        //public TicketWindows(Primiere primiere)
        //{
        //    InitializeComponent();
        //}

         private Primiere myPremier;

         public TicketWindows()
        {
            Messenger.Default.Register<PremiereSelectedMessage>(this, OnPrimiereSelectedChanged);
            InitializeComponent();
            // myPremier = primiere;
            myPremier = new Primiere();
            myPremier.Name = "1111111111111111";

        }

        private void OnPrimiereSelectedChanged(PremiereSelectedMessage message)
        {
            // message.Primiere
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
