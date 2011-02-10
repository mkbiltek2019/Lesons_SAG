using System;

namespace ChocoPlanet.Business.Managers
{
    public class BasketItemModel
    {
        public int OrderID
        {
            get;
            set;
        }

        public int BasketID
        {
            get;
            set;
        }

        public int OrderStatusID
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        public double ProductPrice
        {
            get;
            set;
        }

        public string OrderState
        {
            get;
            set;
        }

        public DateTime? CurierPassingDate
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
