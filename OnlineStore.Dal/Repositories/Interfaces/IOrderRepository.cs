using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Dal.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<IEnumerable<Order>> GetByUserId(int userId);
    }
}
