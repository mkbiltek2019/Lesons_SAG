using System;
using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Business;

namespace ChocoPlanet.DataAccess.Fakes
{
    public class ProductDataProviderFakes : Abstraction.IDataProvider<Product>
    {
        private IEnumerable<Product> productCollection = new List<Product>();

        public ProductDataProviderFakes()
        {
            ((List<Product>)productCollection).Add(new Product
            {
                Name = "Світоч темний",
                ImageName = "images/Brick/big/svDark.jpg",
                ThumbnailName = "images/Brick/thumbs/svDark.jpg",
                Description = "Світоч темний темний темний темний",
                PlacementDate = DateTime.Today,
                Price = 12.123,
                ProductId = 1,
                CategoryId = 2
            });

            ((List<Product>)productCollection).Add(new Product
            {
                Name = "СВІТОЧ особливий",
                ImageName = "images/Brick/big/svSpecial.jpg",
                ThumbnailName = "images/Brick/thumbs/svSpecial.jpg",
                Description = "СВІТОЧ  особливий особливий особливий особливий",
                PlacementDate = DateTime.Today,
                Price = 12.233,
                ProductId = 2,
                CategoryId = 2
            });

            ((List<Product>)productCollection).Add(new Product
            {
                Name = "Ромашка Світоч",
                ImageName = "images/Candy/big/svRomashka.jpg",
                ThumbnailName = "images/Candy/thumbs/svRomashka.jpg",
                Description = "Улюблена шоколадна цукерка з помадною начинкою",
                PlacementDate = DateTime.Today,
                Price = 22.123,
                ProductId = 3,
                CategoryId = 1
            });
        }

        public IEnumerable<Product> GetAll()
        {
            return productCollection;
        }

        public Product GetById(int itemId)
        {
            return GetAll().Single(product => product.ProductId == itemId);
        }

        public void Add(Product newData)
        {
            ((List<Product>)productCollection).Add(newData);
        }

        public void Remove(Product dataToRemove)
        {
            ((List<Product>)productCollection).Remove(dataToRemove);
        }

        public void Modify(Product dataToModify)
        {
            foreach (Product product in ((List<Product>)productCollection))
            {
                if (product.ProductId == dataToModify.ProductId)
                {
                    product.Name = dataToModify.Name;
                    product.Description = dataToModify.Description;
                    product.CategoryId = dataToModify.CategoryId;
                    product.ImageName = dataToModify.ImageName;
                    product.ThumbnailName = dataToModify.ThumbnailName;
                    product.PlacementDate = dataToModify.PlacementDate;
                    product.Price = dataToModify.Price;
                    break;
                }
            }
        }

        public IEnumerable<Product> SelectByForeignKey(int foreignKeyId)
        {
            IEnumerable<Product> tmpCollection = new List<Product>();

            foreach (Product product in ((List<Product>)productCollection))
            {
                if (product.CategoryId == foreignKeyId)
                {
                    ((List<Product>)tmpCollection).Add(product); 
                }
            }

            return tmpCollection;
        }
    }
}
