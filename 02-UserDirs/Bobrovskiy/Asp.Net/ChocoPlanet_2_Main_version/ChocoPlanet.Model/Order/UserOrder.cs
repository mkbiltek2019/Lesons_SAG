
using System;

namespace ChocoPlanet.Model.Order
{
    public class UserOrder
    {
        public int ID
        {
            get;
            set;
        }

        public string UserName
        {
            get; 
            set; 
        }

        public int OrderBasketID
        {
            get; 
            set;
        }

        public int ProductID
        {
            get; 
            set;
        }

        public int OrderStatusID
        {
            get; 
            set;
        }
        
    }
}
