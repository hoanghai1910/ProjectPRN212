using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.Identity.Client;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerByEmail(string email) => CustomerDAO.GetCustomerByEmail(email);

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);

        public void AddCustomer(Customer customer) => CustomerDAO.AddCustomer(customer);
        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);


    }
}
