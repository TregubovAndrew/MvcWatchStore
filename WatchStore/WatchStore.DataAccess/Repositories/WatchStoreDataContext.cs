using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Repositories
{
    public class WatchStoreDataContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public WatchStoreDataContext()
        {
            Database.SetInitializer(new WatchStoreDataContextInitializer());
        }


    }
}
