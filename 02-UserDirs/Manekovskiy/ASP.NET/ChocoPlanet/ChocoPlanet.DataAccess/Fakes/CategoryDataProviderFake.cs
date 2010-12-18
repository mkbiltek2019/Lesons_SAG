using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.Business;

namespace ChocoPlanet.DataAccess.Fakes
{
    public class CategoryDataProviderFake : Abstraction.IDataProvider<Category>
    {
        #region Implementation of IDataProvider<Category>

        public IEnumerable<Category> GetAll()
        {
            yield return new Category { Id = 1, Name = "Десерты", Description = "" };
            yield return new Category { Id = 2, Name = "Шоколадные плитки", Description = "" };
        }

        public Category GetById(int categoryId)
        {
            return GetAll().Single(category => category.Id == categoryId);
        }

        #endregion
    }
}
