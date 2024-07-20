using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        public List<Shoe> GetShoes() => ShoeDAO.GetShoes();
        public void AddShoe(Shoe shoe) => ShoeDAO.AddShoe(shoe);


        public void DeleteShoe(Shoe shoe) => ShoeDAO.DeleteShoe(shoe);


        public Shoe GetShoeById(int id) => ShoeDAO.GetShoeById(id);


        public void UpdateShoe(Shoe shoe) => ShoeDAO.UpdateShoe(shoe);

    }
}
