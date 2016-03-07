using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;
using WatchStore.DataAccess.Repositories;

namespace WatchStore.BusinessLogic.Services
{
    
    public class AccountService :IAccountService
    {
        private readonly IAccountRepository _accountRepository;
    
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Customer GetById(int? id)
        {
            return _accountRepository.GetById(id);
        }

        public IEnumerable<Customer> GetAllAccount()
        {
            return _accountRepository.GetAllAccounts();
        }

        public Customer GetByUserName(string name)
        {
            return _accountRepository.GetByUserName(name);
        }

        public void CreateAccount(Customer account)
        {
            account.DateRegistered = DateTime.Now;
            _accountRepository.CreateAccount(account);
        }

        public void UpdateAccount(Customer account)
        {
            _accountRepository.UpdateAccount(account);
        }

        public void DeleteAccount(int? id)
        {
            _accountRepository.DeleteAccount(id);
        }

        public bool IsUniqueLogin(string login)
        {
            var user = GetByUserName(login);
            if (user==null)
            {
                return true;
            }
            return false;
        }
        public bool IsExistAccount(string login, string password)
        {
            var user = GetByUserName(login);
            if (user == null)
                return false;
            if (user.UserName == login && user.Password == password)
                return true;
            return false;
        }

       
    }
}
