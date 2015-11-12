using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WatchStoreDataContext>
    {
        //private readonly bool _pendingMigrations;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //var migrator = new DbMigrator(this);
            //_pendingMigrations = migrator.GetPendingMigrations().Any();
        }

        protected override void Seed(WatchStoreDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //if (!_pendingMigrations) return;

            context.Accounts.AddOrUpdate(a => a.Login,
                new Account()
                {
                    Login = "admin",
                    Password = "admin"
                }
                );
             context.Accounts.AddOrUpdate(a =>a.Login,
                new Account()
                {
                    Login = "manager",
                    Password = "manager"
                }
                );
            context.Watches.AddOrUpdate(w =>w.Name,
                new Watch()
                {
                    Name = "BUCHANAN CHRONOGRAPH LEATHER WATCH",
                    Brand = "Buchanan",
                    Colour = "Light brown",
                    WaterResistance = "5 ATM",
                    Warranty = 11,
                    Category = "Men"
                },
                 new Watch()
                 {
                     Name = "BUCHANAN LEATHER WATCH",
                     Brand = "Buchanan",
                     Colour = "Dark brown",
                     WaterResistance = "5 ATM",
                     Warranty = 11,
                     Category = "Women"
                 },
                 new Watch()
                 {
                     Name = "DEAN CHRONOGRAPH LEATHER WATCH",
                     Brand = "Dean",
                     Colour = "Dark brown",
                     WaterResistance = "10 ATM",
                     Warranty = 11,
                     Category = "Men"
                 }
                 ,
                 new Watch()
                 {
                     Name = "MACHINE AUTOMATIC STAINLESS STEEL WATCH",
                     Brand = "Machine",
                     Colour = "Black",
                     WaterResistance = "5 ATM",
                     Warranty = 11,
                     Category = "Women"
                 }
                 ,
                 new Watch()
                 {
                     Name = "MACHINE CHRONOGRAPH LEATHER WATCH",
                     Brand = "Machine",
                     Colour = "Dark brown",
                     WaterResistance = "5 ATM",
                     Warranty = 11,
                     Category = "Men"
                 }
                 ,
                 new Watch()
                 {
                     Name = "NATE CHRONOGRAPH LEATHER WATCH",
                     Brand = "Nate",
                     Colour = "Dark brown",
                     WaterResistance = "10 ATM",
                     Warranty = 11,
                     Category = "Men"
                 }
                 ,
                 new Watch()
                 {
                     Name = "WAKEFIELD AUTOMATIC LEATHER WATCH",
                     Brand = "Wakefield",
                     Colour = "Black",
                     WaterResistance = "10 ATM",
                     Warranty = 11,
                     Category = "Women"
                 });
            context.SaveChanges();


        }
    }
}
