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
    public class CategoryController : Controller
    {
       
        private ChocoPlanetDbEntities chocoPlanetDbEntities;
        public CategoryController( ChocoPlanetDbEntities chocoPlanetDbEntities)
        {
          
            this.chocoPlanetDbEntities = chocoPlanetDbEntities;
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult CategoryCatalog()
        {

            return View(chocoPlanetDbEntities.Category);
        }
        [HttpGet]
        [Authorize(Roles = "Администратори")]
        public ActionResult Edit(int id)
        {


            return View(chocoPlanetDbEntities.Category.SingleOrDefault(c=>c.ID==id));
        }
        [HttpPost]
        [Authorize(Roles = "Администратори")]
        public ActionResult Edit(int id,Category category)
        {

            Category _category = chocoPlanetDbEntities.Category.SingleOrDefault(c=>c.ID==category.ID);
            _category.Name = category.Name;
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("CategoryCatalog");
        }
        [HttpGet]
        [Authorize(Roles = "Администратори")]
        public ActionResult Create()
        {

            return View();
        }
       [Authorize(Roles = "Администратори")]
        [HttpPost]
        public ActionResult Create(Category category)
        {

           // if (ModelState.IsValid)
            {
                Category _category = new Category() { Name = category.Name };
                chocoPlanetDbEntities.AddToCategory(_category);
                chocoPlanetDbEntities.SaveChanges(); 
            }
          //  else
            {
                ModelState.AddModelError("user","eroorr");
            }
           
            return RedirectToAction("CategoryCatalog");
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult Delete(int id)
        {
          
           
                Category category = chocoPlanetDbEntities.Category.SingleOrDefault(c => c.ID == id);
                chocoPlanetDbEntities.DeleteObject(category);
                chocoPlanetDbEntities.SaveChanges();
           
               
           

            return RedirectToAction("CategoryCatalog");
        }
    }
}
