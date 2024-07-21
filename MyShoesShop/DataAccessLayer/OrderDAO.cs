using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var db = new MyShoesShopContext();
            return db.Orders.Include("OrderDetails").ToList();
        }

        public static Order GetOrderById(int id)
        {
            var db = new MyShoesShopContext();
            return db.Orders.Include("OrderDetails").SingleOrDefault(s => s.OrderId.Equals(id));
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.Entry(order).State = EntityState.Modified;
                foreach (var detail in order.OrderDetails)
                {
                    if (detail.OrderId == 0) // New detail
                    {
                        context.Entry(detail).State = EntityState.Added;
                    }
                    else // Existing detail
                    {
                        context.Entry(detail).State = EntityState.Modified;
                    }
                }
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
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
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

