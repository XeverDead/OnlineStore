using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Models;
using OnlineStore.Common.Models.SubModels;
using System.Collections.Generic;

namespace OnlineStore.Dal.Databases
{
    public class StoreContext : DbContext
    {
        internal DbSet<User> Users { get; set; }

        internal DbSet<Order> Orders { get; set; }

        internal DbSet<Product> Products { get; set; }

        internal DbSet<EmailModel> Emails { get; set; }

        internal DbSet<PhoneNumberModel> PhoneNumbers { get; set; }

        public StoreContext(DbContextOptions options) : base (options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Order>()
                .HasMany(order => order.Products)
                .WithMany(product => product.Orders)
                .UsingEntity<Dictionary<string, object>>("OrderProduct",
                    entity => entity.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    entity => entity.HasOne<Order>().WithMany().HasForeignKey("OrderId"),
                    entity => entity.ToTable("OrderProduct"));
        }
    }
}
