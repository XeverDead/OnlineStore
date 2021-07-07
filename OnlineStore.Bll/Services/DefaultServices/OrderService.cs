using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Bll.Services.DefaultServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Create(Order order)
        {
            return await _orderRepository.Create(order);
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> GetById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<IEnumerable<Order>> GetByUserId(int userId)
        {
            return await _orderRepository.GetByUserId(userId);
        }

        public async Task<Order> Update(Order order)
        {
            return await _orderRepository.Update(order);
        }
    }
}
