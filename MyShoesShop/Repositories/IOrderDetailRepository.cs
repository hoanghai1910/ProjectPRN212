using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> getOrderDetails();
        void UpdateOrderDetail(OrderDetail orderDetail);
        void AddOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
