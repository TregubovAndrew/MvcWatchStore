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
    public class OrderRepository : IOrderRepository
    {
        private readonly WatchStoreDataContext _db;

        public OrderRepository(WatchStoreDataContext db)
        {
            _db = db;
        }

        public Order GetById(int? id)
        {
            return _db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _db.Orders;
        }


        public void MakeOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public void EditOrder(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveOrder(int? id)
        {
            Order order = _db.Orders.Find(id);
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
    }
}
