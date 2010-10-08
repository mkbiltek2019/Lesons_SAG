using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using TheatreTicketBooking.Client.Entities;
//using TheatreTicketBooking.Client.Entities;

namespace TheatreTicketBooking.Client
{
    public class PremiereSelectedMessage : MessageBase
    {
        public Premiere Premiere { get; set; }
    }
}
