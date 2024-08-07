﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ShoeDAO
    {   
        public static List<Shoe> GetShoes()
        {
            var db = new MyShoesShopContext();
            return db.Shoes.ToList();
        }
        public static Shoe GetShoeById(int id)
        {
            var db = new MyShoesShopContext();
            return db.Shoes.SingleOrDefault(s => s.ShoesId.Equals(id));
        }

        public static void UpdateShoe(Shoe shoe)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<Shoe>(shoe).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public static void AddShoe(Shoe shoe)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Shoes.Add(shoe);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteShoe(Shoe shoe)
        {
            try
            {
                using var context = new MyShoesShopContext();
                Shoe s = context.Shoes.SingleOrDefault(s => s.ShoesId.Equals(shoe.ShoesId));
                context.Shoes.Remove(s);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
