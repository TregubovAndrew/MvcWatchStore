using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        Account GetById(int? id);
        IEnumerable<Account> GetAllAccounts();
        Account GetByLogin(string login);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int? id);
        void Dispose();
    }



}
