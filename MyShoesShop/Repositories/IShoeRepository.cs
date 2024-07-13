using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IShoeRepository
    {
        Shoe GetShoeById(int id);
        void UpdateShoe(Shoe shoe);
        void AddShoe(Shoe shoe);
        void DeleteShoe(Shoe shoe);
    }
}
