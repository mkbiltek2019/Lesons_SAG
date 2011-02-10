using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChocoPlanet.DataAccess.Abstraction;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.DataAccess.Fakes.Order
{
    public class BasketDataProviderFake : Abstraction.IDataProvider<Basket>
    {
        private IEnumerable<Basket> basketCollection = new List<Basket>();

        public BasketDataProviderFake()
        {
            ((List<Basket>)basketCollection).Add(new Basket
            {
                ID = 1,
                CreationDate = new DateTime(2011,01,10)
            });

            ((List<Basket>)basketCollection).Add(new Basket
            {
                ID = 2,
                CreationDate = new DateTime(2011, 01, 14)
            });

        }

        public IEnumerable<Basket> GetAll()
        {
            return basketCollection;
        }

        Basket IDataProvider<Basket>.GetById(int itemId)
        {
            return GetAll().Single(category => category.ID == itemId);
        }

        public void Add(Basket newData)
        {
            ((List<Basket>)basketCollection).Add(newData);
        }

        public void Remove(Basket dataToRemove)
        {
            ((List<Basket>)basketCollection).Remove(dataToRemove);
        }

        public void Modify(Basket dataToModify)
        {
            foreach (Basket orderState in ((List<Basket>)basketCollection))
            {
                if (orderState.ID == dataToModify.ID)
                {
                    orderState.CreationDate = dataToModify.CreationDate;
                    break;
                }
            }
        }

        public IEnumerable<Basket> SelectByForeignKey(int foreignKeyId)
        {
            throw new NotImplementedException();
        }
    }
}
