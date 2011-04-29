using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ChocoPlanet.Models.Services
{
    public class OrderSubmitter:IOrderSubmitter
    {
       
        private ChocoPlanetDbEntities chocoPlanetDbEntities;

        public OrderSubmitter(ChocoPlanetDbEntities chocoPlanetDbEntities)
        {
            this.chocoPlanetDbEntities = chocoPlanetDbEntities;
        }

        public void SumbitterOrder(Cart cart)
        {

            try
            {
                CreateOrder(cart);
            }
            catch (Exception exception)
            {

                
            }
        }

        public void CreateOrder(Cart cart)
        {
            
            int statusID = chocoPlanetDbEntities.Status.SingleOrDefault(s => s.Name == "Новий").ID;
            int orderItemsID = (chocoPlanetDbEntities.OrderItems.Count() != 0) ? (chocoPlanetDbEntities.OrderItems.Max(id => id.ID) + 1) : 1;
            Country country = new Country()
            {
                ID = (chocoPlanetDbEntities.Country.Count() != 0) ? chocoPlanetDbEntities.Country.Max(id => id.ID) + 1 : 1,
                Name = cart.ShippingDetails.Country
            };
            Address address = new Address()
            {
                ID = (chocoPlanetDbEntities.Address.Count() != 0) ? chocoPlanetDbEntities.Address.Max(id => id.ID) + 1 : 1,
                CountryId = country.ID,
                Town = cart.ShippingDetails.Town,
                Stret = cart.ShippingDetails.Stret

            };
            Customer customer = new Customer()
            {
                ID = (chocoPlanetDbEntities.Customer.Count() != 0) ? chocoPlanetDbEntities.Customer.Max(id => id.ID) + 1 : 1,
                Name = cart.ShippingDetails.Name,
                Telefon = cart.ShippingDetails.Telefon,
                AddressId = address.ID



            };
            Order order = new Order()
            {
                ID = (chocoPlanetDbEntities.Order.Count() != 0) ? chocoPlanetDbEntities.Order.Max(id => id.ID) + 1 : 1,
                StatusId = statusID,
                CreateDate = DateTime.Now,
                ModifayDate = DateTime.Now,
                CustomerId = customer.ID


            };


            foreach (CartLine line in cart.Lines)
            {
                OrderItems orderItems = new OrderItems();
                orderItems.ID = orderItemsID;
                orderItems.OrderId = order.ID;
                orderItems.ProductId = chocoPlanetDbEntities.Product.SingleOrDefault(name => name.Name == line.Product.Name).ID;
                orderItems.Quantity = line.Quantity;
                chocoPlanetDbEntities.OrderItems.AddObject(orderItems);
                orderItemsID++;
            }
            chocoPlanetDbEntities.Order.AddObject(order);
            chocoPlanetDbEntities.Country.AddObject(country);
            chocoPlanetDbEntities.Customer.AddObject(customer);
            chocoPlanetDbEntities.Address.AddObject(address);
            chocoPlanetDbEntities.SaveChanges();
            
           

        }
    }
}