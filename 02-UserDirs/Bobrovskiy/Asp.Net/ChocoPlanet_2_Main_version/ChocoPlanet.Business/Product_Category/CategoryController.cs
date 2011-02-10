using System.Collections.Generic;
using System.Linq;
using ChocoPlanet.DataAccess;
using ChocoPlanet.DataAccess.Abstraction;

namespace ChocoPlanet.Business
{
    public class CategoryController
    {
        private IDataProvider<Category> _categoryDataProvider;
        private const string defaultValue = "Оберіть категорію"; 
        
        public CategoryController()
        {
            _categoryDataProvider = ServiceLocator.GetType<IDataProvider<Category>>();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDataProvider.GetAll();
        }

        public IEnumerable<string> GetCategoryList()
        {
            IEnumerable<string> result = new List<string>();
            ((List<string>)result).Add(defaultValue);

            foreach (Category category in _categoryDataProvider.GetAll())
            {
                ((List<string>)result).Add(category.Name);
            }
            
            return result;
        }

        public int GetIdByName(string name)
        {
            int result = 0;

            foreach (Category category in _categoryDataProvider.GetAll())
            {
                if(category.Name == name)
                {
                    result = category.Id;
                    break;
                }
            }

            return result;
        }

        public Category GetById(int categoryId)
        {
            return _categoryDataProvider.GetById(categoryId);
        }

        public void AddCategory(int id, string name, string description)
        {
            Category tmpCategory = new Category()
            {
                Id = (id++),
                Name=name,
                Description = description
            };

            _categoryDataProvider.Add(tmpCategory);
        }

        public void RemoveCategory(int categoryId)
        {
            _categoryDataProvider.Remove(_categoryDataProvider.GetById(categoryId));
        }

        public void ModifyCategory(int id, string name, string description)
        {
            Category tmpCategory = new Category()
            {
                Id = id,
                Name = name,
                Description = description
            };

            _categoryDataProvider.Modify(tmpCategory);
        }
    }
}
