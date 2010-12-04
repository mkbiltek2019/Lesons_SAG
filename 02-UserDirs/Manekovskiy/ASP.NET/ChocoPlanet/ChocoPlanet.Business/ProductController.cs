using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChocoPlanet.Business
{
    public class ProductController
    {
        public IEnumerable<Product> GetAllProducts()
        {
            yield return new Product() { Name = "Olenka" };
            yield return new Product() { Name = "SEagull" };
            //ChocoPlanetDBEntities dataContext = new ChocoPlanetDBEntities();
            //return dataContext.Product
            //    .ToList();
        }
    }
}