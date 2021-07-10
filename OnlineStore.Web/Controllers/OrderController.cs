using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var prders = await _orderService.GetAll();

            return new ObjectResult(prders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return new ObjectResult(order);
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

            return Ok(userOrders);
        }

        [HttpGet("notOrdered")]
        public async Task<IActionResult> GetNotOrdered()
        {
            //Переписать на получение из клеймсов
            var userId = 0;

            var notOrderedOrder = await _orderService.GetNotOrdered(userId);

            return Ok(notOrderedOrder);
        }
    }
}
