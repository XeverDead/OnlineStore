using Microsoft.AspNetCore.Mvc;
using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Models;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _productService;

        public ProductController(IService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();

            return new ObjectResult(products);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return new ObjectResult(product);
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
    }
}
