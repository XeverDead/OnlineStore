using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Bll.Services.DefaultServices;
using OnlineStore.Bll.Services.Interfaces;
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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
