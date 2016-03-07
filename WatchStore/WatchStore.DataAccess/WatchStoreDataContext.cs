using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using WatchStore.DataAccess.Entities;

namespace WatchStore.DataAccess
{
    public class WatchStoreDataContext : DbContext
    {
        public DbSet<Watch> Watches { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderWatch> OrderWatches { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Brand> Brands { get; set; } 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Watch

            modelBuilder.Entity<Watch>()
                .HasMany(w => w.Images)
                .WithRequired(i => i.Watch)
                .HasForeignKey(i => i.WatchId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Watch>()
                .HasMany(w => w.OrderWatches)
                .WithRequired(ow => ow.Watch)
                .HasForeignKey(ow => ow.WatchId)
                .WillCascadeOnDelete(false);

            #endregion

            #region OrderWatch

            modelBuilder.Entity<OrderWatch>()
                .HasRequired(ow => ow.Watch)
                .WithMany(w => w.OrderWatches)
                .HasForeignKey(ow => ow.WatchId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderWatch>()
                .HasRequired(ow => ow.Order)
                .WithMany(o => o.OrderWatches)
                .HasForeignKey(ow => ow.OrderId)
                .WillCascadeOnDelete(false);

            #endregion

            #region Order

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderWatches)
                .WithRequired(ow => ow.Order)
                .HasForeignKey(ow => ow.OrderId)
                .WillCascadeOnDelete(false);

            #endregion

            #region User

            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(128).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(128).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(128);


            #endregion

            #region Customer

            modelBuilder.Entity<Customer>().ToTable("Customer");

            #endregion

            #region Brand

            modelBuilder.Entity<Brand>()
                .HasMany(b =>b.Watches)
                .WithOptional(w =>w.Brand)
                .HasForeignKey(w =>w.BrandId)
                .WillCascadeOnDelete(false);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
