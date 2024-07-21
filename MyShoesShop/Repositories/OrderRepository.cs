using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order) => OrderDAO.AddOrder(order);

        public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);


        public Order GetOrderById(int id) => OrderDAO.GetOrderById(id);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public void UpdateOrder(Order order) => OrderDAO.UpdateOrder(order);

    }
}
