using System;
using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Business;

namespace ChocoPlanet.DataAccess.Fakes
{
    public class CategoryDataProviderFake : Abstraction.IDataProvider<Category>
    {
        #region Implementation of IDataProvider<Category>

        private IEnumerable<Category> categoryCollection = new List<Category>();

        public CategoryDataProviderFake()
        {
            ((List<Category>)categoryCollection).Add(new Category
                        {
                            Id = 1,
                            Name = "Цукерки вагові",
                            Description = "Цукерки вагові Цукерки вагові"
                        });

            ((List<Category>)categoryCollection).Add(new Category
            {
                Id = 2,
                Name = "Шоколадні плитки",
                Description = "Шоколадні плитки Шоколадні плитки Шоколадні плитки"
            });
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryCollection;
        }

        public Category GetById(int categoryId)
        {
            return GetAll().Single(category => category.Id == categoryId);
        }

        public void Add(Category newCategory)
        {
            ((List<Category>)categoryCollection).Add(newCategory);
        }

        public void Modify(Category newCategory)
        {
            foreach (Category category in ((List<Category>)categoryCollection))
            {
                if (category.Id == newCategory.Id)
                {
                    category.Name = newCategory.Name;
                    category.Description = newCategory.Description;
                    break;
                }
            }
        }

        public IEnumerable<Category> SelectByForeignKey(int foreignKeyId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category categoryToRemove)
        {
            ((List<Category>)categoryCollection).Remove(categoryToRemove);
        }

        #endregion
    }
}
