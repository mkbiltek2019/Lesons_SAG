using System;
using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.DataAccess.Fakes.Order
{
    public class OrderStateDataProviderFake : Abstraction.IDataProvider<OrderState>
    {
        private IEnumerable<OrderState> orderStateCollection = new List<OrderState>();

        public OrderStateDataProviderFake()
        {
            ((List<OrderState>)orderStateCollection).Add(new OrderState
            {
                ID = 1,
                Name = "Розміщений"
            });

            ((List<OrderState>)orderStateCollection).Add(new OrderState
            {
                ID = 2,
                Name = "Оплачений"
            });

            ((List<OrderState>)orderStateCollection).Add(new OrderState
            {
                ID = 3,
                Name = "Підтверджений"
            });

            ((List<OrderState>)orderStateCollection).Add(new OrderState
            {
                ID = 4,
                Name = "Відмінений"
            });

            ((List<OrderState>)orderStateCollection).Add(new OrderState
            {
                ID = 5,
                Name = "Доставляється"
            });

            ((List<OrderState>)orderStateCollection).Add(new OrderState
            {
                ID = 6,
                Name = "Доставлений"
            });

        }

        public IEnumerable<OrderState> GetAll()
        {
            return orderStateCollection;
        }

        public OrderState GetById(int itemId)
        {
            return GetAll().Single(category => category.ID == itemId);
        }

        public void Add(OrderState newData)
        {
            ((List<OrderState>)orderStateCollection).Add(newData);
        }

        public void Remove(OrderState dataToRemove)
        {
            ((List<OrderState>)orderStateCollection).Remove(dataToRemove);
        }

        public void Modify(OrderState dataToModify)
        {
            foreach (OrderState orderState in ((List<OrderState>)orderStateCollection))
            {
                if (orderState.ID == dataToModify.ID)
                {
                    orderState.Name = dataToModify.Name;
                    break;
                }
            }
        }

        public IEnumerable<OrderState> SelectByForeignKey(int foreignKeyId)
        {
            throw new NotImplementedException();
        }
    }
}
