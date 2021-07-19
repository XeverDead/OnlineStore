using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Databases;
using OnlineStore.Dal.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Common.Enums;

namespace OnlineStore.Dal.Repositories.EFRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _dbContext;

        public OrderRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Create(Order order)
        {
            var orderEntry = _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return orderEntry.Entity;
        }

        public async Task Delete(int id)
        {
            var orderToDelete = await GetById(id);

            _dbContext.Orders.Remove(orderToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _dbContext.Orders.AsNoTracking().ToListAsync();

            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _dbContext.Orders
                .AsNoTracking()
                .Include(order => order.User)
                .FirstOrDefaultAsync(order => order.Id == id);

            return order;
        }

        public async Task<Order> Update(Order order)
        {
            var orderEntry = _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();

            return orderEntry.Entity;
        }

        public async Task<IEnumerable<Order>> GetByUserId(int userId)
        {
            var orders = await _dbContext.Orders
                .AsNoTracking()
                .Where(order => order.User.Id == userId)
                .Include(order => order.User)
                .ToListAsync();

            return orders;
        }

        public async Task<Order> GetNotOrdered(int userId)
        {
            var notOrderedOrder = await _dbContext.Orders
                .AsNoTracking()
                .Include(order => order.User)
                .FirstOrDefaultAsync(order => (order.UserId == userId)
                && (order.State == OrderState.NotOrdered));

            return notOrderedOrder;
        }
    }
}
