using System;
using System.Collections.Generic;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.Business
{
    public class UserOrderController
    {
        private IDataProvider<UserOrder> _userOrderDataProvider;

        public UserOrderController()
        {
            _userOrderDataProvider = ServiceLocator.GetType<IDataProvider<UserOrder> >();
        }

        public IEnumerable<UserOrder> GetAllUserOrders()
        {
            return _userOrderDataProvider.GetAll();
        }

        public IEnumerable<UserOrder> SelectByOrderBasketId(int orderBasketID)
        {
            return _userOrderDataProvider.SelectByForeignKey(orderBasketID);
        }

        public UserOrder GetById(int itemId)
        {
            return _userOrderDataProvider.GetById(itemId);
        }

        public void AddUserOrder(int userOrderID, int orderBasketID,
                               int orderStatusID, int productID,
                               string userName)
        {
            //TODO: modify AddProduct method and ModifyProduct make one method remove code duplication
            UserOrder tmpProduct = new UserOrder()
            {
                ID = (userOrderID++),
                OrderBasketID = orderBasketID,
                OrderStatusID = orderStatusID,
                ProductID = productID,
                UserName = userName
            };

            _userOrderDataProvider.Add(tmpProduct);
        }

        public void ModifyProduct(int userOrderID, int orderBasketID,
                               int orderStatusID, int productID,
                               string userName)
        {
            UserOrder tmpProduct = new UserOrder()
            {
                ID = userOrderID,
                OrderBasketID = orderBasketID,
                OrderStatusID = orderStatusID,
                ProductID = productID,
                UserName = userName
            };

            _userOrderDataProvider.Modify(tmpProduct);
        }

        public void RemoveProduct(int userOrderId)
        {
            _userOrderDataProvider.Remove(_userOrderDataProvider.GetById(userOrderId));
        }

    }
}
