using System;
using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Business.Product_Category;

namespace ChocoPlanet.Business
{
    public class UserOrderManager
    {
        private List<int> ProductIDList = null;
        
        private const int defaultOrderState = 1;//identifier of order placed state from OrderState
        
        private int BasketID
        {
            get; 
            set;
        }

        private int OrderStatusID
        {
            get;
            set;
        }
        
        private DateTime? BasketCreateDate
        {
            get; 
            set;
        }

        public void CreateBasket()
        {
            ProductIDList = new List<int>();
        }

        public void AddProduct(int productID)
        {
            if (ProductIDList!=null)
            {
                ProductIDList.Add(productID);
            }
        }

        public void DeleteProduct(int productID)
        {
            ProductIDList.Remove(productID);
        }

        public void PlaceOrder(string userName)
        {   
            /* mini plan
             *1 add basket
             *2 add orderStatus
             *3 add userOrder
             */
            const int defaultUp = 1;
            
            OrderBasketController basketController = new OrderBasketController();
            BasketID = basketController.GetAllBasket().Count() + defaultUp; // need change !!!

            BasketCreateDate = DateTime.Now;
            basketController.AddBasket(BasketID, BasketCreateDate);

            OrderStatusController orderStatusController = new OrderStatusController();
            OrderStatusID = orderStatusController.GetAllOrderStatus().Count() + defaultUp; //need change !!!

            orderStatusController.AddOrderStatus(OrderStatusID,
                                                 null,
                                                 null,
                                                 defaultOrderState);

            UserOrderController userOrderController = new UserOrderController();

            foreach (int productId in ProductIDList)
            {
                int id = userOrderController.GetAllUserOrders().Count() + defaultUp;//need change !!!

                userOrderController.AddUserOrder(id,
                                                 BasketID,
                                                 OrderStatusID,
                                                 productId,
                                                 userName);
            }

            //after PlaceOrder clear productlist
            ClearBasket();
        }

        public IEnumerable<Product> GetAllProductsInBasket()
        {
            List<Product> result = new List<Product>();
            ProductController productController = new ProductController();

            if (ProductIDList!=null)
            {
                if (ProductIDList.Count > 0)
                {
                    foreach (int id in ProductIDList)
                    {
                        result.Add(productController.GetById(id));
                    }
                }
            }

            return result;
        }

        public void ClearBasket()
        {
            if (ProductIDList != null)
            {
                ProductIDList.Clear();
            }
            
            BasketID = 0;
            OrderStatusID = 0;
            BasketCreateDate = null;
        }

    }
}
