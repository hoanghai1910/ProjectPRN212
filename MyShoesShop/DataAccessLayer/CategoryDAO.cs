using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CategoryDAO
    {   

        public static Category GetCategoryById(int id)
        {
            var db = new MyShoesShopContext();
            return db.Categories.SingleOrDefault(s => s.CategoryId.Equals(id));
        }

        public static void UpdateCategory(Category category)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddCategory(Category category)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCategory(Category category)
        {
            try
            {
                using var context = new MyShoesShopContext();
                Category s = context.Categories.SingleOrDefault(s => s.CategoryId.Equals(category.CategoryId));
                context.Categories.Remove(s);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
