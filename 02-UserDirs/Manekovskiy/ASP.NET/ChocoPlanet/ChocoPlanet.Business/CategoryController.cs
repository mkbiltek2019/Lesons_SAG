using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;

namespace ChocoPlanet.Business
{
    public class CategoryController
    {
        private IDataProvider<Category> _categoryDataProvider;

        public CategoryController()
        {
            _categoryDataProvider = ServiceLocator.GetType<IDataProvider<Category>>();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDataProvider.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDataProvider.GetById(categoryId);
        }
    }
}
