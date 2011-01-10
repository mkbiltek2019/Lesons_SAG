using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;

namespace ChocoPlanet.Business
{
    public class ProductController
    {
        private IDataProvider<Product> _productDataProvider;

        public ProductController()
        {
            _productDataProvider = ServiceLocator.GetType<IDataProvider<Product>>();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productDataProvider.GetAll();
        }

        public IEnumerable<Product> SelectByCategoryId(int categoryId)
        {
            return _productDataProvider.SelectByForeignKey(categoryId);
        }

        public Product GetById(int itemId)
        {
            return _productDataProvider.GetById(itemId);
        }

        public void AddProduct(int productId, int categoryId, 
                               string name, string description,
                               string imageName, string thumbnailName,
                               double price, DateTime? placementDate)
        { 
            //TODO: modify AddProduct method and ModifyProduct make one method remove code duplication
            Product tmpProduct = new Product()
            {
                ProductId = (productId++),
                CategoryId = categoryId,
                Name = name,
                Description = description,
                ImageName = imageName,
                ThumbnailName = thumbnailName,
                Price = price,
                PlacementDate = placementDate
            };
            
            _productDataProvider.Add(tmpProduct);
        }
        
        public void ModifyProduct(int productId, int categoryId,
                                   string name, string description,
                                   string imageName, string thumbnailName,
                                   double price, DateTime? placementDate)
        {
            Product tmpProduct = new Product()
            {
                ProductId = productId,
                CategoryId = categoryId,
                Name = name,
                Description = description,
                ImageName = imageName,
                ThumbnailName = thumbnailName,
                Price = price,
                PlacementDate = placementDate
            };

            _productDataProvider.Modify(tmpProduct);
        }
        
        public void RemoveProduct(int productId)
        {
            _productDataProvider.Remove(_productDataProvider.GetById(productId));
        }

    }
}
