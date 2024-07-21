using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrderById(int id);
        void UpdateOrder(Order order);
        void AddOrder(Order order);
        void DeleteOrder(Order order);
    }
}
