using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Order GetById(int? id);
        IEnumerable<Order> GetAllOrders();
        void MakeOrder(Order order);
        void EditOrder(Order order);
        void RemoveOrder(int? id);
        void MakeDependency(Order order, Watch watch, int quantity);
        void RemoveDependency(Order order, Watch watch, int quantity);
        decimal CalculateTotalSum(int? id);
        void IncreaseQuantityByOne(int orderId, int watchId);
        void DecreaseQuantityByOne(int orderId, int watchId);
    }
}
