using OnlineStore.Common.Enums;
using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Dal.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<IEnumerable<Product>> GetByCategory(string category);

        public Task<IEnumerable<Product>> GetByName(string name);

        public Task<IEnumerable<Product>> GetByPrice(int price, PriceComparison comparisonType);
    }
}
