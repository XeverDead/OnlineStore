using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Bll.Services.DefaultServices;
using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Databases;
using OnlineStore.Dal.Repositories.EFRepositories;
using OnlineStore.Dal.Repositories.Interfaces;

namespace OnlineStore.Di
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connctionString)
        {
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(connctionString));
        }

        public static void AddStoreServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();

            services.AddTransient<IService<User>, UserService>();
            services.AddTransient<IService<Order>, OrderService>();
            services.AddTransient<IService<Product>, ProductService>();
        }
    }
}
