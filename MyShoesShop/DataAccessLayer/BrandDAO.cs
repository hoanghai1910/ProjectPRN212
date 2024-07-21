using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class BrandDAO
    { 
        public static List<Brand> GetBrands()
        {
            var brands = new List<Brand>();
            try
            {
                var db = new MyShoesShopContext();
                brands = db.Brands.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return brands;
        }
        public static Brand GetBrandById(int id)
        {
            var db = new MyShoesShopContext();
            return db.Brands.SingleOrDefault(s => s.BrandId.Equals(id));
        }

        public static void UpdateBrand(Brand brand)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<Brand>(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddBrand(Brand brand)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Brands.Add(brand);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBrand(Brand brand)
        {
            try
            {
                using var context = new MyShoesShopContext();
                Brand s = context.Brands.SingleOrDefault(s => s.BrandId.Equals(brand.BrandId));
                context.Brands.Remove(s);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
