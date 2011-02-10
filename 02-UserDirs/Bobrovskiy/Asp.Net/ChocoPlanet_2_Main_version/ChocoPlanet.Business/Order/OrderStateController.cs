using System.Collections.Generic;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.Business.Product_Category
{
    public class OrderStateController
    {
        private IDataProvider<OrderState> _orderStateDataProvider;
        private const string defaultValue = "Оберіть статус"; 

        public OrderStateController()
        {
            _orderStateDataProvider = ServiceLocator.GetType<IDataProvider<OrderState> >();
        }

        public IEnumerable<OrderState> GetAllOrderState()
        {
            return _orderStateDataProvider.GetAll();
        }

        public IEnumerable<string> GetOrderStateList()
        {
            IEnumerable<string> result = new List<string>();
            ((List<string>)result).Add(defaultValue);

            foreach (OrderState category in _orderStateDataProvider.GetAll())
            {
                ((List<string>)result).Add(category.Name);
            }

            return result;
        }

        public int GetIdByName(string name)
        {
            int result = 0;

            foreach (OrderState category in _orderStateDataProvider.GetAll())
            {
                if (category.Name == name)
                {
                    result = category.ID;
                    break;
                }
            }

            return result;
        }

        public OrderState GetById(int itemId)
        {
            return _orderStateDataProvider.GetById(itemId);
        }

        public void AddOrderStatus(int lastID, string name)
        {
            //TODO: modify AddProduct method and ModifyProduct make one method remove code duplication
            OrderState tmpProduct = new OrderState()
            {
                ID = (lastID++),
                Name = name
            };

            _orderStateDataProvider.Add(tmpProduct);
        }
    }
}
