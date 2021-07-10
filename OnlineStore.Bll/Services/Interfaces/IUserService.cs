using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Bll.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        public Task<IEnumerable<User>> GetByUsername(string username);
    }
}
