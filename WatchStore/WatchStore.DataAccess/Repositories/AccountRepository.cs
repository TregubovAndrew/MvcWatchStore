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
        private readonly WatchStoreDataContext _db = new WatchStoreDataContext();
        public Account GetById(int? id)
        {
            return _db.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _db.Accounts;
        }

        public Account GetByLogin(string login)
        {
            return _db.Accounts.FirstOrDefault(a => a.Login == login);
        }

        public void CreateAccount(Account account)
        {
            _db.Accounts.Add(account);
            _db.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            _db.Entry(account).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteAccount(int? id)
        {
            Account account = _db.Accounts.Find(id);
            _db.Accounts.Remove(account);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
