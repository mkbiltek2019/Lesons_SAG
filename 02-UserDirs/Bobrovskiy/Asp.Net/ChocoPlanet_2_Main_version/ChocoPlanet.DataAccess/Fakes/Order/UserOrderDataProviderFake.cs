using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.DataAccess.Fakes.Order
{
    public class UserOrderDataProviderFake : Abstraction.IDataProvider<UserOrder>
    {
        private IEnumerable<UserOrder> userOrderCollection = new List<UserOrder>();

        public UserOrderDataProviderFake()
        {
            ((List<UserOrder>)userOrderCollection).Add(
               new UserOrder()
               {
                   ID = 1,
                   ProductID = 1,
                   OrderBasketID = 1,
                   OrderStatusID = 1,
                   UserName = "user1"
               });

            ((List<UserOrder>)userOrderCollection).Add(
               new UserOrder()
               {
                   ID = 2,
                   ProductID = 2,
                   OrderBasketID = 1,
                   OrderStatusID = 1,
                   UserName = "user1"
               });

            ((List<UserOrder>)userOrderCollection).Add(
               new UserOrder()
               {
                   ID = 3,
                   ProductID = 2,
                   OrderBasketID = 2,
                   OrderStatusID = 2,
                   UserName = "user2"
               });

            ((List<UserOrder>)userOrderCollection).Add(
               new UserOrder()
               {
                   ID = 4,
                   ProductID = 2,
                   OrderBasketID = 2,
                   OrderStatusID = 2,
                   UserName = "user2"
               });

        }

        public IEnumerable<UserOrder> GetAll()
        {
            return userOrderCollection;
        }

        public UserOrder GetById(int itemId)
        {
            return GetAll().Single(userOrder => userOrder.ID == itemId);
        }

        public void Add(UserOrder newData)
        {
            ((List<UserOrder>)userOrderCollection).Add(newData);
        }

        public void Remove(UserOrder dataToRemove)
        {
            ((List<UserOrder>)userOrderCollection).Remove(dataToRemove);
        }

        public void Modify(UserOrder dataToModify)
        {
            foreach (UserOrder userOrder in ((List<UserOrder>)userOrderCollection))
            {
                if (userOrder.ID == dataToModify.ID)
                {
                    userOrder.OrderBasketID = dataToModify.OrderBasketID;
                    userOrder.OrderStatusID = dataToModify.OrderStatusID;
                    userOrder.ProductID = dataToModify.ProductID;
                    userOrder.UserName = dataToModify.UserName;

                    break;
                }
            }
        }

        public IEnumerable<UserOrder> SelectByForeignKey(int orderBasketID)
        {
            IEnumerable<UserOrder> tmpCollection = new List<UserOrder>();

            foreach (UserOrder userOrder in ((List<UserOrder>)userOrderCollection))
            {
                if (userOrder.OrderBasketID.CompareTo(orderBasketID)==0)
                {
                    ((List<UserOrder>)tmpCollection).Add(userOrder);
                }
            }

            return tmpCollection;
        }
    }
}
