using System;
using System.Threading;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using TheatreTicketBooking.Business;
using TheatreTicketBooking.Client.Entities;

namespace TheatreTicketBooking.Client
{
    /// <summary>
    /// Interaction logic for TicketWindows.xaml
    /// </summary>
    public partial class TicketWindows : Window
    {
        private Premiere myPremier;

        public TicketWindows()
        {           
            InitializeComponent();

            Messenger.Default.Register<PremiereSelectedMessage>(this, OnPrimiereSelectedChanged);
            myPremier = new Premiere();
        }       
      
        private void OnPrimiereSelectedChanged(PremiereSelectedMessage message)
        {
            if (message.Premiere != null)  
            {
                myPremier = message.Premiere;
                ticketCount.Text = string.Format("Aviable ticket count: <{0}>", myPremier.TicketCount);
                Genre.Text = string.Format("\t{0}", myPremier.Genre);
                NameW.Text = string.Format("\t{0}", myPremier.Name);
               // Description.Text = string.Format("\t{0}", myPremier.Description);
                Price.Text = string.Format("\t{0}", Convert.ToString(myPremier.Price));
            }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new TicketManager()).SubTicket(myPremier);
            Thread.Sleep(200);
            this.Close();
        }
    }
}
