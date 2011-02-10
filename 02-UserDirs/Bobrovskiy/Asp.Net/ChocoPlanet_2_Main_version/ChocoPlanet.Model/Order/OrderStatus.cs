using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChocoPlanet.Model.Order
{
    public class OrderStatus
    {
        public int ID
        {
            get; 
            set;
        }

        public int OrderStateID
        {
            get;
            set;
        }

        public DateTime? CourierPassingDate
        {
            get;
            set;
        }

        public DateTime? DeliveryDate
        {
            get;
            set;
        }
        
    }
}
