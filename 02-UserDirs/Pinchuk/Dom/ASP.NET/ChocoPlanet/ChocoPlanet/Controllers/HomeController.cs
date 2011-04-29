using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChocoPlanet.Core;
using ChocoPlanet.Models;
using ChocoPlanet.Models.File;

namespace ChocoPlanet.Controllers
{
    [HandleErrors]
    public class HomeController : Controller
    {
       
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {

            ViewBag.Message = "Добро пожаловать в ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
       
    }
}
