using OnlineStore.Common.Enums;
using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Bll.Services.Interfaces
{
    public interface IProductService : IService<Product>
    {
        public Task<IEnumerable<Product>> GetByCategory(string category);

        public Task<IEnumerable<Product>> GetByName(string name);

        public Task<IEnumerable<Product>> GetByPrice(int price, PriceComparison comparisonType);

        public Task AddToCurrentOrder(int userId, Product product);
    }
}
