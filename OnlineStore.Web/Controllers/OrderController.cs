using Microsoft.AspNetCore.Mvc;
using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.GetAll();

            var ordersData = ConvertToOrderData(orders);

            return Ok(ordersData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var createdOrder = await _orderService.Create(order);

            return Ok(createdOrder);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var updatedOrder = await _orderService.Update(order);

            return Ok(updatedOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);

            return Ok();
        }

        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var userOrders = await _orderService.GetByUserId(userId);

            var ordersData = ConvertToOrderData(userOrders);

            return Ok(ordersData);
        }

        [HttpGet("notOrdered")]
        public async Task<IActionResult> GetNotOrdered()
        {
            //Переписать на получение из клеймсов
            var userId = 0;

            var notOrderedOrder = await _orderService.GetNotOrdered(userId);

            return Ok(notOrderedOrder);
        }

        private List<OrderData> ConvertToOrderData(IEnumerable<Order> orders)
        {
            var ordersData = new List<OrderData>();

            foreach (var order in orders)
            {
                ordersData.Add(new OrderData
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    State = order.State
                });
            }

            return ordersData;
        }
    }
}
