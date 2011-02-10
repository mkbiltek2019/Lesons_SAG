using System;
using System.Collections.Generic;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.Business.Product_Category
{
    public class OrderStatusController
    {
        private IDataProvider<OrderStatus> _orderStatusDataProvider;

        public OrderStatusController()
        {
            _orderStatusDataProvider = ServiceLocator.GetType<IDataProvider<OrderStatus>>();
        }

        public IEnumerable<OrderStatus> GetAllOrderStatus()
        {
            return _orderStatusDataProvider.GetAll();
        }

        public OrderStatus GetById(int itemId)
        {
            return _orderStatusDataProvider.GetById(itemId);
        }

        public void AddOrderStatus(int lastID, DateTime? courierPassingDate,
                                   DateTime? deliveryDate, int orderStateID)
        {
            //TODO: modify AddProduct method and ModifyProduct make one method remove code duplication
            OrderStatus tmpProduct = new OrderStatus()
            {
                ID = (lastID++),
                CourierPassingDate = courierPassingDate,
                DeliveryDate = deliveryDate,
                OrderStateID = orderStateID
            };

            _orderStatusDataProvider.Add(tmpProduct);
        }

        public void ModifyOrderStatus(int lastID, DateTime? courierPassingDate,
                                     DateTime? deliveryDate, int orderStateID)
        {
            OrderStatus tmpProduct = new OrderStatus()
            {
                ID = lastID,
                CourierPassingDate = courierPassingDate,
                DeliveryDate = deliveryDate,
                OrderStateID = orderStateID
            };

            _orderStatusDataProvider.Modify(tmpProduct);
        }

        public void RemoveProduct(int userOrderId)
        {
            _orderStatusDataProvider.Remove(_orderStatusDataProvider.GetById(userOrderId));
        }
    }
}
