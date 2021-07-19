using Microsoft.AspNetCore.Mvc;
using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Enums;
using OnlineStore.Common.Models;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var createdProduct = await _productService.Create(product);

            return Ok(createdProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.Update(product);

            return Ok(updatedProduct);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);

            return Ok();
        }

        [HttpGet("byCategory/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var productsOfCategory = await _productService.GetByCategory(category);

            return Ok(productsOfCategory);
        }

        [HttpGet("byName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var productsOfName = await _productService.GetByName(name);

            return Ok(productsOfName);
        }

        [HttpGet("byPrice")]
        public async Task<IActionResult> GetByCategory([FromQuery]int price, [FromQuery]PriceComparison comparisonType)
        {
            var products = await _productService.GetByPrice(price, comparisonType);

            return Ok(products);
        }

        [HttpPost("addToOrder")]
        public async Task AddToCurrentUserOrder([FromBody]Product product)
        {
            // Заменить на получение из клеймсов
            var userId = 1;

            await _productService.AddToCurrentOrder(userId, product);
        }
    }
}
