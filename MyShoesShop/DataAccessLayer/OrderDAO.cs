using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        public static Order GetOrderById(int id)
        {
            var db = new MyShoesShopContext();
            return db.Orders.SingleOrDefault(s => s.OrderId.Equals(id));
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddOrder(Order order)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order order)
        {
            try
            {
                using var context = new MyShoesShopContext();
                Order s = context.Orders.SingleOrDefault(s => s.OrderId.Equals(order.OrderId));
                context.Orders.Remove(s);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

