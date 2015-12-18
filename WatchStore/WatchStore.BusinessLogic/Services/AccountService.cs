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

        public Account GetById(int? id)
        {
            return _accountRepository.GetById(id);
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return _accountRepository.GetAllAccounts();
        }

        public Account GetByLogin(string login)
        {
            return _accountRepository.GetByLogin(login);
        }

        public void CreateAccount(Account account)
        {
            _accountRepository.CreateAccount(account);
        }

        public void UpdateAccount(Account account)
        {
            _accountRepository.UpdateAccount(account);
        }

        public void DeleteAccount(int? id)
        {
            _accountRepository.DeleteAccount(id);
        }

        public bool IsUniqueLogin(string login)
        {
            var user = GetByLogin(login);
            if (user==null)
            {
                return true;
            }
            return false;
        }
        public bool IsExistAccount(string login, string password)
        {
            var user = GetByLogin(login);
            if (user.Login == login && user.Password == password)
                return true;
            return false;
        }
    }
}
