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
    public class AccountRepository : IAccountRepository
    {
        private readonly WatchStoreDataContext _db;
        public AccountRepository(WatchStoreDataContext db)
        {
            _db = db;
        }

        public Customer GetById(int? id)
        {
            return _db.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAllAccounts()
        {
            return _db.Customers;
        }

        public Customer GetByUserName(string name)
        {
            return _db.Customers.FirstOrDefault(a => a.UserName == name);
        }

        public void CreateAccount(Customer account)
        {
            _db.Customers.Add(account);
            _db.SaveChanges();
        }

        public void UpdateAccount(Customer account)
        {
            _db.Entry(account).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteAccount(int? id)
        {
            Customer account = _db.Customers.Find(id);
            _db.Customers.Remove(account);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
