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
            yield return new Product()
            {
                Name = "Nachspeise",
                ImageName = "Fusion.jpg",
                ThumbnailName = "Fusion.jpg",
                PlacementDate = DateTime.Today,
                CategoryId = 1
            };

            yield return new Product()
            {
                Name = "Світоч темний", 
                ImageName = "Brick/big/svDark.jpg", 
                ThumbnailName = "Brick/thumbs/svDark.jpg",
                PlacementDate = DateTime.Today,
                CategoryId = 2
            };
        }

        public IEnumerable<Product> GetAllProductsWithFilter(int? categoryId)
        {
            return GetAllProducts().Where(product => product.CategoryId == categoryId);
        }
    }
}