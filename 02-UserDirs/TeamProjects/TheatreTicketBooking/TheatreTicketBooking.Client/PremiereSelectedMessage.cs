using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using TheatreTicketBooking.DataAccess.Entities;

namespace TheatreTicketBooking.Client
{
    public class PremiereSelectedMessage : MessageBase
    {
        public Primiere Primiere { get; set; }
    }
}
