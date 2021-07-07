using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Bll.Services.Interfaces
{
    public interface IOrderService : IService<Order>
    {
        public Task<IEnumerable<Order>> GetByUserId(int userId);
    }
}
