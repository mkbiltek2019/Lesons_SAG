using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ChocoPlanet.Core;
using ChocoPlanet.Models;


namespace ChocoPlanet.Controllers
{
    [HandleErrors]
    public class NavController : Controller
    {
        
        private ChocoPlanetDbEntities chocoPlanetDbEntities;
        public NavController(ChocoPlanetDbEntities chocoPlanetDbEntities)
        {
           
            this.chocoPlanetDbEntities = chocoPlanetDbEntities;
        }

        public ActionResult Menu(string highlightCategory)
        {
            List<NavLink> navLinks = new List<NavLink>();
            navLinks.Add(new CategoryLink(null)
            {isSelected = (highlightCategory==null)});
            var categories = chocoPlanetDbEntities.Category.Select(x => x.Name);
            foreach (string category in categories.OrderBy(x=>x))
            {
                navLinks.Add(new CategoryLink(category)
                { isSelected = (category == highlightCategory ) });


            }
            return PartialView(navLinks);
            

        }

    }

    public class NavLink
    {
        public string Text { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
        public bool isSelected { get; set; }
    }
    public class CategoryLink : NavLink
    {
        public CategoryLink(string category)
        {
            Text = category ?? "Вся продукція";
            RouteValues = new RouteValueDictionary(new
                                                       {
                                                           controller = "Product",
                                                           action = "ProductCatalog",
                                                           category = category,
                                                           page = 1

                                                       });
        }
    }
}
