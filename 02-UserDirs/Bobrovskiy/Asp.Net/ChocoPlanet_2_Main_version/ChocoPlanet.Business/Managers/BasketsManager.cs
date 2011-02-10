using System;
using System.Collections.Generic;
using ChocoPlanet.Business.Product_Category;
using ChocoPlanet.Model.Order;

namespace ChocoPlanet.Business.Managers
{
    public class BasketsManager
    {
        private List<int> basketList = new List<int>();

        public BasketsManager()
        {
            OrderBasketController basketController = new OrderBasketController();

            foreach (Basket basket in basketController.GetAllBasket())
            {
                basketList.Add(basket.ID);
            }
        }

        public void SetOrderStatus(int orderID)
        {
             
        }

        public IEnumerable<Basket> GetBasketList()
        {
            OrderBasketController basketController = new OrderBasketController();

            return basketController.GetAllBasket();
        }

        public IEnumerable<BasketItemModel> GetProductListByBasketID(int basketID)
        {
            UserOrderController userOrderController = new UserOrderController();
            OrderStatusController orderStatusController = new OrderStatusController();
            OrderStateController orderStateController = new OrderStateController();
            ProductController productController = new ProductController();

            List<BasketItemModel> basketDetails = new List<BasketItemModel>();

            foreach (UserOrder userOrder in userOrderController.GetAllUserOrders())
            {
                if (basketID == userOrder.OrderBasketID)
                {
                    basketDetails.Add(new BasketItemModel()
                    {
                        BasketID = userOrder.OrderBasketID,
                        CurierPassingDate = orderStatusController.GetById(userOrder.OrderStatusID).CourierPassingDate,
                        DeliveryDate = orderStatusController.GetById(userOrder.OrderStatusID).DeliveryDate,
                        OrderState = orderStateController.GetById(orderStatusController.GetById(userOrder.OrderStatusID).OrderStateID).Name,
                        OrderStatusID = orderStatusController.GetById(userOrder.OrderStatusID).ID,
                        ProductName = productController.GetById(userOrder.ProductID).Name,
                        ProductPrice = productController.GetById(userOrder.ProductID).Price,
                        OrderID = userOrder.ID
                    });
                }
            }

            return basketDetails;
        }
    }
}
