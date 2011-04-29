using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChocoPlanet.Core;
using ChocoPlanet.Models;
using ChocoPlanet.Models.Services;


namespace ChocoPlanet.Controllers
{
    [HandleErrors]
    public class CartController : Controller
    {
        
        private IOrderSubmitter _orderSubmitter;
        private ChocoPlanetDbEntities chocoPlanetDbEntities;
        public CartController(IOrderSubmitter orderSubmitter, ChocoPlanetDbEntities chocoPlanetDbEntities)
        {
            _orderSubmitter = orderSubmitter;
            
            this.chocoPlanetDbEntities = chocoPlanetDbEntities;
        }

        
        public RedirectToRouteResult AddToCart(Cart cart, int id,string returnUrl)
        {
            Product product = chocoPlanetDbEntities.Product.FirstOrDefault(p => p.ID == id);
            cart.AddItem(product,1);
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart,int ID, string returnUrl)
        {
            Product product = chocoPlanetDbEntities.Product.FirstOrDefault(p => p.ID == ID);
            cart.RemoteLine(product);
            return RedirectToAction("Index", new {returnUrl});
        }
        public ActionResult Index(Cart cart, string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            ViewData["CurrentCategory"] = "Cart";
            return View(cart);
        }
        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        [HttpGet]
        public ActionResult CheckOut(Cart cart)
        {
            return View(cart.ShippingDetails);
        }
        [HttpPost]
        public ActionResult CheckOut(Cart cart, /*ShippingDetails spDetails*/ FormCollection form)
        {
            if (cart.Lines.Count == 0)
            {
                ModelState.AddModelError("Cart", "Ваша корзина пуста");
                return View();
            }
            if (TryUpdateModel(cart.ShippingDetails, form.ToValueProvider()))
            {
                _orderSubmitter.SumbitterOrder(cart);
                cart.Clear();
                return View("Comleted");
            }
            else
            {
                return View();
            }
            //if (!ModelState.IsValid)
            //    RedirectToAction("CheckOut");
            //_dataManager.Order.CreateOrder(cart, spDetails);
            //return View("Comleted");
        }

       
    }
}
