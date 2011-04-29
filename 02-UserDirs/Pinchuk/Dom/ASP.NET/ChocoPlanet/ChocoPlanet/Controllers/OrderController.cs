using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChocoPlanet.Core;
using ChocoPlanet.Models;


namespace ChocoPlanet.Controllers
{
    [HandleErrors]
    public class OrderController : Controller
    {
        private ChocoPlanetDbEntities chocoPlanetDbEntities;

        public OrderController(ChocoPlanetDbEntities chocoPlanetDbEntities)
        {
            this.chocoPlanetDbEntities = chocoPlanetDbEntities;
        }

        [Authorize(Roles = "Администратори")]
        public ActionResult Index()
        {
            return View(chocoPlanetDbEntities.Order);
        }

        [Authorize(Roles = "Администратори")]
        public ActionResult Details(int id)
        {

            return View(chocoPlanetDbEntities.Order.SingleOrDefault(o => o.ID == id));
        }
        [HttpGet]
        [Authorize(Roles = "Администратори")]
        public ActionResult Edit(int id)
        {
            ViewData["Status"] = new SelectList(chocoPlanetDbEntities.Status, "ID", "Name");
            return View(chocoPlanetDbEntities.Order.SingleOrDefault(o => o.ID == id));
        }
        [HttpPost]
        [Authorize(Roles = "Администратори")]
        public ActionResult Edit(int id, Order ordersInfo)
        {
            Order order = chocoPlanetDbEntities.Order.SingleOrDefault(o => o.ID == ordersInfo.ID);
            order.ModifayDate = DateTime.Now;
            order.StatusId = ordersInfo.StatusId;
            order.Customer.Name = ordersInfo.Customer.Name;
            order.Customer.Telefon = ordersInfo.Customer.Telefon;
            order.Customer.Address.Stret = ordersInfo.Customer.Address.Stret;
            order.Customer.Address.Town = ordersInfo.Customer.Address.Town;
            order.Customer.Address.Country.Name = ordersInfo.Customer.Address.Country.Name;
            chocoPlanetDbEntities.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult Delete(int id)
        {
            Order order = chocoPlanetDbEntities.Order.SingleOrDefault(o => o.ID == id);
            foreach (OrderItems items in chocoPlanetDbEntities.OrderItems.Where(i => i.OrderId == id))
            {
                chocoPlanetDbEntities.OrderItems.DeleteObject(items);
            }
            chocoPlanetDbEntities.Order.DeleteObject(order);
            // chocoPlanetDbEntities.Order.DeleteObject(order);
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult RemoveItems(int id, int orderId)
        {
            OrderItems orderItems = chocoPlanetDbEntities.OrderItems.SingleOrDefault(p => p.ID == orderId);
            chocoPlanetDbEntities.OrderItems.DeleteObject(orderItems);
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult Add(int id, int orderId)
        {
            OrderItems orderItems = chocoPlanetDbEntities.OrderItems.SingleOrDefault(p => p.ID == orderId);
            orderItems.Quantity++;
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult Minus(int id, int orderId)
        {
            OrderItems orderItems = chocoPlanetDbEntities.OrderItems.SingleOrDefault(p => p.ID == orderId);
            orderItems.Quantity--;
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }

    }
}
