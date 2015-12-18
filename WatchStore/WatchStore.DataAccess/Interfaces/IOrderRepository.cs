using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Order GetById(int? id);
        IEnumerable<Order> GetAllOrders();
        void MakeOrder(Order order);
        void EditOrder(Order order);
        void RemoveOrder(int? id);
    }
}
