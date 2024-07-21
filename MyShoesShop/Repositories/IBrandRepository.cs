using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetBrands();
        Brand GetBrandById(int id);
        void UpdateBrand(Brand brand);
        void AddBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}
