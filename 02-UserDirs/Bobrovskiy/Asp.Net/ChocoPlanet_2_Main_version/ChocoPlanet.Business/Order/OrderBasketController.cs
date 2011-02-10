using System;
using System.Collections.Generic;
using ChocoPlanet.DataAccess;
using ChocoPlanet.Model.Order;
using ChocoPlanet.DataAccess.Abstraction;

namespace ChocoPlanet.Business
{
    public class OrderBasketController
    {
        private IDataProvider<Basket> _basketDataProvider;

        public OrderBasketController()
        {
            _basketDataProvider = ServiceLocator.GetType<IDataProvider<Basket>>();
        }

        public IEnumerable<Basket> GetAllBasket()
        {
            return _basketDataProvider.GetAll();
        }

        public Basket GetById(int itemId)
        {
            return _basketDataProvider.GetById(itemId);
        }

        public void AddBasket(int lastID, DateTime? date)
        {
            //TODO: modify AddProduct method and ModifyProduct make one method remove code duplication
            Basket tmpProduct = new Basket()
            {
                ID = (lastID++),
                CreationDate = date
            };

            _basketDataProvider.Add(tmpProduct);
        }
    }
}
