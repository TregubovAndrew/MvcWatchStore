using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Repositories;

namespace WatchStore.DataAccess
{
    public class WatchStoreDataContextInitializer :  DropCreateDatabaseIfModelChanges<WatchStoreDataContext>
    {
        protected override void Seed(WatchStoreDataContext context)
        {

            context.Accounts.Add(
                new Account()
                {
                    Login = "admin",
                    Password = "admin"
                }
                );
            context.Accounts.Add(
                new Account()
                {
                    Login = "manager",
                    Password = "manager"
                }
                );
            context.Watches.AddOrUpdate(
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
                     Name = "BUCHANAN CHRONOGRAPH LEATHER WATCH",
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
            base.Seed(context);
        }
    }
}
