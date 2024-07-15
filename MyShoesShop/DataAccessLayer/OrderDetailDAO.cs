using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var context = new MyShoesShopContext();
                OrderDetail s = context.OrderDetails.SingleOrDefault(s => s.OrderId.Equals(orderDetail.OrderId));
                context.OrderDetails.Remove(s);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

