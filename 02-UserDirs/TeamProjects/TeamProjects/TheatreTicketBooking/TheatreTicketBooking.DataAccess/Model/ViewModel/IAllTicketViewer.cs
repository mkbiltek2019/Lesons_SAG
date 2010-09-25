using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheatreTicketBooking.Client.ViewModel
{
    public interface IAllTicketViewer
    {
        void ClearBookList();
        void ShowBookList();
    }
}
