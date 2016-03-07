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
    public class WatchStoreDataContextInitializer :  CreateDatabaseIfNotExists<WatchStoreDataContext>
    {
        protected override void Seed(WatchStore.DataAccess.WatchStoreDataContext context)
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

            context.Customers.AddOrUpdate(a => a.UserName,
               new Customer()
               {
                   UserName = "admin",
                   Password = "admin",
                   Email = "admin@gmail.com",
                   FirstName = "John",
                   LastName = "Smith",
                   PostalCode = 11,
                   Country = "USA",
                   City = "New York",
                   Address = "Holy wood",
                   Phone = 0937847612
               }
               );

            context.Brands.AddOrUpdate(b =>b.Name,
                new Brand
                {
                    Name = "Paulin",
                    Description = "In response to the decline of British watchmaking in recent decades, sisters Elizabeth and Charlotte Paulin were moved to act. " +
                                  "They founded the watch brand Paulin in 2012, a project the duo says is about 'bringing together designing and making," +
                                  " and restarting an industry that’s been dead for generations.'"     
                },
                new Brand
                {
                    Name = "Squarestreet",
                    Description = "Launched in 2010 by Swedish designer Alexis Holm, lifestyle brand Squarestreet takes its name from the road it was founded on in Hong Kong’s creative district of Sheung Wan." +
                                  "A similarly self-explanatory method is used to name the brand’s watches. Minuteman is a one-handed watch that takes a somewhat unorthodox approach to timekeeping."
                });

            //context.Accounts.AddOrUpdate(a => a.Login,
            //    new Account()
            //    {
            //        Login = "manager",
            //        Password = "manager"
            //    }
            //    );
            context.Watches.AddOrUpdate(w => w.Name,
                new Watch()
                {
                    Name = "C201 Chronograph",
                    BrandOld = "Paulin",
                    Price = 162.50M,
                    Colour = "Black",
                    Description = "The C201 chronograph is an updated version of the C200, the first Chronograph timepiece from Glasgow based brand Paulin." +
                                  "Designed and built in Glasgow, Paulin watches use components sourced from worldwide suppliers." +
                                  "The watch uses a Japanese Miyotoa quartz movement and comes with a hand-stitched bridle leather strap from Clayton’s Tannery in England." +
                                  "C201 has a 40mm stainless steel case and three chronograph sub-dials; a 24h dial, 30 minute and 60 second stopwatch and a date window at 4-o’clock. " +
                                  "Adjustments are made using the crown and pushers on the right.",
                    CaseMaterial = "Stainless steel",
                    CaseDiameter = 40,
                    Lens = "Crystal domed mineral glass",
                    Strap = "Leather",
                    Mechanism = "Japanese quartz Miyota movement",
                    WaterResistance = "5 ATM",
                    Warranty = 1,
                    Category = "Men",
                    Brand = context.Brands.Single(b =>b.Name=="Paulin")
                },
                 new Watch()
                 {
                     Name = "Aluminium",
                     BrandOld = "Squarestreet",
                     Price = 149.17M,
                     Colour = "Gold",
                     Description = "The Aluminium by squarestreet has a slim 42mm brushed aluminium case that houses a Swiss Ronda movement." +
                                   "The dial is decorated with printed micro-concentric rings, like the age markings inside of tree trunks." +
                                   "The minutes are numbered from 1 to 60 and the hours are marked by numberless indices. " +
                                   "The watch has a date window and features a sub-dial that contains the seconds hand. A crown at 3 o, clock adjusts the time and date. " +
                                   "The watch has an Italian leather strap and is incredibly lightweight, weighing in at just 33g.",
                     CaseMaterial = "T6061 Aluminium",
                     CaseDiameter = 42,
                     Lens = "Crystal domed mineral glass",
                     Strap = "Italian leather",
                     Mechanism = "Swiss Ronda Movement",
                     WaterResistance = "5 ATM",
                     Warranty = 2,
                     Category = "Men",
                     Brand = context.Brands.Single(b => b.Name == "Squarestreet")
                 },
                 new Watch()
                 {
                     Name = "Long Distance 1.0",
                     BrandOld = "Kitmen Keung",
                     Price = 240.00M,
                     Colour = "Brown",
                     Description = "The Long Distance watch is the first watch from Hong Kong-based designer Kitmen Keung." +
                                   "Designed to act as a reminder of the distance between the wearer and a loved one, the face " +
                                   "features two dials which can be set to different time zones.The secondary face is a lighter shade of grey." +
                                   "Other features include matte-finish aluminium hands, applied markers and a 39mm stainless steel dial with a brushed IP finish." +
                                   "The dial is topped with a hardened mineral crystal lens." +
                                   "The Long Distance watch is powered by Japanese 3-hand movement and also includes a soft calf leather brown strap.",
                     CaseMaterial = "316L Stainless steel",
                     CaseDiameter = 39,
                     Lens = "Hardened mineral",
                     Strap = "Argentinian calf leather",
                     Mechanism = "Japanese quartz 3 hand",
                     WaterResistance = "5 ATM",
                     Warranty = 2,
                     Category = "Men"
                 }
                 ,
                 new Watch()
                 {
                     Name = "Läder",
                     BrandOld = "Larsson & Jennings",
                     Price = 179.17M,
                     Colour = "Black",
                     Description = "Larsson & Jennings is an Anglo-Swedish brand that designs and manufacturers contemporary watches that combine classic " +
                                   "British aesthetic and Swedish minimalistic design." +
                                   "The Läder series celebrates classic British dress watch aesthetic. The watch has a 40mm stainless steel case and a black dial." +
                                   "Läder means Leather in Swedish and the watch features an Italian calf leather strap.",
                     CaseMaterial = "Polished stainless steel",
                     CaseDiameter = 40,
                     Lens = "Sapphire crystal glass",
                     Strap = "Italian calf leather",
                     Mechanism = "Ronda 762 Quartz",
                     WaterResistance = "5 ATM",
                     Warranty = 2,
                     Category = "Women"
                 }
                 ,
                 new Watch()
                 {
                     Name = "The Bradley Voyager",
                     BrandOld = "Eone",
                     Price = 205.00M,
                     Colour = "Silver",
                     Description = "Created by US design company Eone, The Bradley Compass is a revolutionary tactile timepiece designed for everyone to wear." +
                                   "Originally developed for blind people, The Bradley contains a magnet that rotates two ball bearings around the watch face " +
                                   "allowing users to tell the time without needing to look — the front ball indicates minutes, while the rear ball shows the hour." +
                                   "The timepiece is named after Bradley Snyder, an ex-naval officer who lost his eyesight in an explosion in Afghanistan in 2011 " +
                                   "yet went on to win gold and silver medals at the London 2012 Paralympic Games." +
                                   "The Bradley was launched after a hugely successful crowdfunding campaign and was nominated for Design Museum’s Design of the Year award in 2014.",
                     CaseMaterial = "Stainless steel",
                     CaseDiameter = 40,
                     Lens = "Sapphire crystal glass",
                     Strap = "Leather",
                     Mechanism = "Quartz",
                     WaterResistance = "Good for splashes or brief immersion in water, but not sufficient for water sports, swimming or bathing",
                     Warranty = 1,
                     Category = "Women"
                 });
            context.SaveChanges();
        }
    }
}
