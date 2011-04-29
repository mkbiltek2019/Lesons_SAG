using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChocoPlanet.Models;

namespace ChocoPlanet.Controllers
{
    public class AdministratorController : Controller
    {
       
        public AdministratorController()
        {
            
        }


        public ActionResult ListOptions()
        {
            return View();
        }

    }
}
