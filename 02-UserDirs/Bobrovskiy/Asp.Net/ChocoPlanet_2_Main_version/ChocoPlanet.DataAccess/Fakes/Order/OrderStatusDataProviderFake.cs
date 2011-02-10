using System;
using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.DataAccess.Fakes.Order
{
    public class OrderStatusDataProviderFake : Abstraction.IDataProvider<OrderStatus>
    {
        private IEnumerable<OrderStatus> orderStatusCollection = new List<OrderStatus>();

        public OrderStatusDataProviderFake()
        {
            //add some start data
            ((List<OrderStatus>) orderStatusCollection).Add(
                new OrderStatus()
                    {
                        ID = 1,
                        OrderStateID = 1,
                        CourierPassingDate = new DateTime(2011, 01, 15),
                        DeliveryDate = new DateTime(2011, 02, 15)
                    });

            ((List<OrderStatus>)orderStatusCollection).Add(
                new OrderStatus()
                {
                    ID = 2,
                    OrderStateID = 1,
                    CourierPassingDate = new DateTime(2011, 01, 15),
                    DeliveryDate = new DateTime(2011, 02, 27)
                });

            ((List<OrderStatus>)orderStatusCollection).Add(
                new OrderStatus()
                {
                    ID = 3,
                    OrderStateID = 1,
                    CourierPassingDate = new DateTime(2011, 01, 15),
                    DeliveryDate = new DateTime(2011, 02, 15)
                });

            ((List<OrderStatus>)orderStatusCollection).Add(
                new OrderStatus()
                {
                    ID = 4,
                    OrderStateID = 2,
                    CourierPassingDate = new DateTime(2011, 01, 15),
                    DeliveryDate = new DateTime(2011, 02, 15)
                });
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return orderStatusCollection;
        }

        public OrderStatus GetById(int itemId)
        {
            return GetAll().Single(orderStatus => orderStatus.ID == itemId);
        }

        public void Add(OrderStatus newData)
        {
            ((List<OrderStatus>)orderStatusCollection).Add(newData);
        }

        public void Remove(OrderStatus dataToRemove)
        {
            ((List<OrderStatus>)orderStatusCollection).Remove(dataToRemove);
        }

        public void Modify(OrderStatus dataToModify)
        {
            foreach (OrderStatus orderState in ((List<OrderStatus>)orderStatusCollection))
            {
                if (orderState.ID == dataToModify.ID)
                {
                    orderState.OrderStateID = dataToModify.OrderStateID;
                    orderState.CourierPassingDate = dataToModify.CourierPassingDate;
                    orderState.DeliveryDate = dataToModify.DeliveryDate;
                    break;
                }
            }
        }

        public IEnumerable<OrderStatus> SelectByForeignKey(int orderStateID)
        {
            IEnumerable<OrderStatus> tmpCollection = new List<OrderStatus>();

            foreach (OrderStatus orderStatus in ((List<OrderStatus>)orderStatusCollection))
            {
                if (orderStatus.OrderStateID == orderStateID)
                {
                    ((List<OrderStatus>)tmpCollection).Add(orderStatus);
                }
            }

            return tmpCollection;
        }
    }
}
