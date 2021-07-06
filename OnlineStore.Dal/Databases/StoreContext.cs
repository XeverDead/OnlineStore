using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Models;

namespace OnlineStore.Dal.Databases
{
    public class StoreContext : DbContext
    {
        internal DbSet<User> Users { get; set; }

        internal DbSet<Order> Orders { get; set; }

        internal DbSet<Product> Products { get; set; }

        public StoreContext(DbContextOptions options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
