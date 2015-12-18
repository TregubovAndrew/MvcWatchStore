using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.DataAccess.Repositories
{
    public class OrderWatchRepository : IOrderWatchRepository
    {
        private readonly WatchStoreDataContext _db;

        public OrderWatchRepository(WatchStoreDataContext db)
        {
            _db = db;
        }

        public void MakeDependency(Order order, Watch watch,int quantity)
        {
           var orderwatch = new OrderWatch
           {
               OrderId = order.Id,
               WatchId = watch.Id,
               Quantity = quantity
           };
            _db.OrderWatches.Add(orderwatch);
            _db.SaveChanges();
        }

        public void RemoveDependency(Order order, Watch watch, int quantity)
        {
            var orderwatch = _db.OrderWatches.FirstOrDefault(ow => ow.Order.Id == order.Id && ow.Watch.Id == watch.Id);
            _db.OrderWatches.Remove(orderwatch);
        }
    }
}
