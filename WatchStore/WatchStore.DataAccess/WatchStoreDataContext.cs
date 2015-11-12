using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess
{
    public class WatchStoreDataContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Image> Images { get; set; } 

        public WatchStoreDataContext()
        {
            //Database.SetInitializer(new WatchStoreDataContextInitializer());
        }

        
    }
}
