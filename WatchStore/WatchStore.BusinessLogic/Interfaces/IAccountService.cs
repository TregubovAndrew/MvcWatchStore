using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Customer GetById(int? id);
        IEnumerable<Customer> GetAllAccount();

        Customer GetByUserName(string name);

        void CreateAccount(Customer account);

        void UpdateAccount(Customer account);

        void DeleteAccount(int? id);

        bool IsUniqueLogin(string login);

        bool IsExistAccount(string login, string password);

        
    }
}
