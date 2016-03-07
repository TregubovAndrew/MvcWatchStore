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
        Customer GetById(int? id);
        IEnumerable<Customer> GetAllAccounts();
        Customer GetByUserName(string name);
        void CreateAccount(Customer account);
        void UpdateAccount(Customer account);
        void DeleteAccount(int? id);
        void Dispose();
    }



}
