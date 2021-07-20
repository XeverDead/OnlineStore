using OnlineStore.Bll.Services.Interfaces;
using OnlineStore.Common.Enums;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Bll.Services.DefaultServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Create(Product product)
        {
            return await _productRepository.Create(product);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            return await _productRepository.GetByCategory(category);
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await _productRepository.GetByName(name);
        }

        public async Task<IEnumerable<Product>> GetByPrice(int price, PriceComparison comparisonType)
        {
            return await _productRepository.GetByPrice(price, comparisonType);
        }

        public async Task<Product> Update(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task AddToCurrentOrder(int userId, Product product)
        {
            await _productRepository.AddToCurrentOrder(userId, product);
        }
    }
}
