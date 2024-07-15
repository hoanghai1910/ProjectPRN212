using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
         public void AddCategory(Category category) => CategoryDAO.AddCategory(category);

        public void DeleteCategory(Category category) => CategoryDAO.DeleteCategory(category);


        public Category GetCategoryById(int id) => CategoryDAO.GetCategoryById(id);


        public void UpdateCategory(Category category) => CategoryDAO.UpdateCategory(category);
    }
}
