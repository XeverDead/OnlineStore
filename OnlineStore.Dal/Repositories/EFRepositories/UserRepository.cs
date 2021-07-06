using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Databases;
using OnlineStore.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Dal.Repositories.EFRepositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly StoreContext _dbContext;

        public UserRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User user)
        {
            var addedUerEntry = _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return addedUerEntry.Entity;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await GetById(id);

            if (userToDelete == null)
            {
                throw new ArgumentException($"There is no user with id = {id}", nameof(id));
            }

            _dbContext.Users.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _dbContext.Users.AsNoTracking().ToListAsync();

            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users.AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);

            return user;
        }

        public async Task<User> Update(User user)
        {
            var userToUpdate = await GetById(user.Id);

            if (userToUpdate == null)
            {
                throw new ArgumentException($"There is no user with id = {user.Id}", nameof(user));
            }

            var userEntry = _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return userEntry.Entity;
        }
    }
}
