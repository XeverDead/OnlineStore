using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Dal.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>> GetByUsername(string username);
    }
}
