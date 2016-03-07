using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Interfaces
{
    public interface IOrderWatchRepository
    {
        void MakeDependency(Order order, Watch watch, int quantity);
        void RemoveDependency(Order order, Watch watch, int quantity);
        void IncreaseQuantityByOne(int orderId, int watchId);
        void DecreaseQuantityByOne(int orderId, int watchId);
    }
}
