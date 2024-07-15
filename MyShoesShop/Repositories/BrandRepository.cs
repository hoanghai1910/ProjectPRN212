using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public void AddBrand(Brand brand) => BrandDAO.AddBrand(brand);

        public void DeleteBrand(Brand brand) => BrandDAO.DeleteBrand(brand);


        public Brand GetBrandById(int id) => BrandDAO.GetBrandById(id);


        public void UpdateBrand(Brand brand) => BrandDAO.UpdateBrand(brand);

    }
}
