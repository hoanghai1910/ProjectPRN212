using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        public static Customer GetCustomerByEmail(string email)
        {
            var db = new MyShoesShopContext();
            return db.Customers.FirstOrDefault(c => c.Email.Equals(email));
        }

        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddCustomer(Customer customer)
        {
            try
            {
                using var context = new MyShoesShopContext();
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using var context = new MyShoesShopContext();
                Customer c = context.Customers.SingleOrDefault(c => c.Email.Equals(customer.Email));
                context.Customers.Remove(c);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
