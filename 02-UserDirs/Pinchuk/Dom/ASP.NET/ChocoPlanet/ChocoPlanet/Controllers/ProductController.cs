using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChocoPlanet.Core;
using ChocoPlanet.Models;
using ChocoPlanet.Models.File;

namespace ChocoPlanet.Controllers
{
    [HandleErrors]
    public class ProductController : Controller
    {
        //private readonly DataManager _dataManager;
        private readonly ChocoPlanetDbEntities chocoPlanetDbEntities;


        private ViewResult viewResultProduct;
        private IFileStore _fileStore = new DiskFileStore();
        public int PageSize = 1;
        public ViewResult ViewResultProduct { get; private set; }


        public string GetFileName()
        {

            return _fileStore.SaveUploadedFile(Request.Files[0]);
        }
        public ProductController(ChocoPlanetDbEntities chocoPlanetDbEntities)
        {

            this.chocoPlanetDbEntities = chocoPlanetDbEntities;


        }

        public ActionResult ProductCatalog(string category, int page)
        {
            int categoryId = 0;
            IQueryable<Product> productsInCategory;
            if (!string.IsNullOrEmpty(category))
            {
                categoryId = chocoPlanetDbEntities.Category.SingleOrDefault(c => c.Name == category).ID;
            }
            productsInCategory =
                GetAllProductOrFilter(categoryId).OrderBy(x => x.ID).Skip((page - 1) * PageSize).Take(PageSize);

            ViewResultProduct = View(productsInCategory.ToList());
            int numProduct = GetAllProductOrFilter(categoryId).Count();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)numProduct / PageSize);
            ViewData["CurrentPage"] = page;

            ViewData["CurrentCategory"] = (string.IsNullOrEmpty(category)) ? string.Empty : chocoPlanetDbEntities.Category.SingleOrDefault(p => p.ID == categoryId).Name;

            return ViewResultProduct;

        }
        [Authorize(Roles = "Администратори")]
        public ActionResult SecurityProductCatalog([Bind(Include = "ID")]Category category)
        {
            ViewData["ID"] = new SelectList(chocoPlanetDbEntities.Category, "ID", "Name");
            ViewResultProduct = View(GetAllProductOrFilter(category.ID));
            return ViewResultProduct;
        }
        [HttpGet]
        [Authorize(Roles = "Администратори")]
        public ActionResult Edit(int id)
        {
            Product product = chocoPlanetDbEntities.Product.SingleOrDefault(p => p.ID == id);
            ViewData["Category"] = new SelectList(chocoPlanetDbEntities.Category, "ID", "Name"); ;
            return View(chocoPlanetDbEntities.Product.SingleOrDefault(p => p.ID == id));
        }
        [HttpPost]
        [Authorize(Roles = "Администратори")]
        public ActionResult Edit(int id, Product product, string photo_filename)
        {
            Product _product = chocoPlanetDbEntities.Product.SingleOrDefault(p => p.ID == product.ID);
            _product.Name = product.Name;
            if (!String.IsNullOrEmpty(photo_filename))
                _product.Foto = _fileStore.UploadFolderAbsolute + photo_filename;
            _product.Price = product.Price;
            _product.Description = product.Description;
            _product.categoryID = product.categoryID;

            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("SecurityProductCatalog");
        }
        [HttpGet]
        [Authorize(Roles = "Администратори")]
        public ActionResult Create()
        {
            ViewData["Category"] = new SelectList(chocoPlanetDbEntities.Category, "ID", "Name"); ;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Администратори")]
        public ActionResult Create(Product product, string photo_filename)
        {
            product.Foto = _fileStore.UploadFolderAbsolute + photo_filename;
            chocoPlanetDbEntities.AddToProduct(product);
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("SecurityProductCatalog");
        }
        [Authorize(Roles = "Администратори")]
        public ActionResult Delete(int id)
        {
            Product product = chocoPlanetDbEntities.Product.SingleOrDefault(p => p.ID == id);
            chocoPlanetDbEntities.Product.DeleteObject(product);
            chocoPlanetDbEntities.SaveChanges();
            return RedirectToAction("SecurityProductCatalog");
        }
        [Authorize(Roles = "Администратори")]
        public IQueryable<Product> GetAllProductOrFilter(int categoryId)
        {
            IQueryable<Product> products;
            if (categoryId == 0)
            {
                products = chocoPlanetDbEntities.Product;
            }
            else
            {
                products = chocoPlanetDbEntities.Product.Where(p => p.categoryID == categoryId);
            }
            return products;
        }
    }
}
