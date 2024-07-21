using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByEmail(string email);
        List<Customer> GetCustomers();
        void UpdateCustomer(Customer customer);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
