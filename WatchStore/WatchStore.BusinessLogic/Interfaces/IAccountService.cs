﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Account GetById(int? id);
        IEnumerable<Account> GetAllAccount();
        Account GetByLogin(string login);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int? id);
        bool IsUniqueLogin(string login);
        bool IsExistAccount(string login, string password);

    }
}
