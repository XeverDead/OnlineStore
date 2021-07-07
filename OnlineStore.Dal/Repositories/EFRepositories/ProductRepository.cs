using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Databases;
using OnlineStore.Dal.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Common.Enums;
using System;

namespace OnlineStore.Dal.Repositories.EFRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _dbContext;

        public ProductRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Create(Product product)
        {
            var productEntry = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return productEntry.Entity;
        }

        public async Task Delete(int id)
        {
            var productToDelete = await GetById(id);

            _dbContext.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _dbContext.Products.AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            var productEntry = _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            return productEntry.Entity;
        }

        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            var products = await _dbContext.Products
                .Where(product => product.Category.Contains(category))
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            var products = await _dbContext.Products
                .Where(product => product.Name.Contains(name))
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetByPrice(int price, PriceComparison comparisonType)
        {
            return await Task.Run(() =>
            {
                var comparison = GetComparisonByType(price, comparisonType);

                var products = _dbContext.Products.Where(comparison);

                return products;
            });
        }

        private Func<Product, bool> GetComparisonByType(int price, PriceComparison comparisonType)
        {
            Func<Product, bool> result = comparisonType switch
            {
                PriceComparison.GreaterOrEqual => product => product.Price >= price,
                PriceComparison.LessOrEqual => product => product.Price <= price,
                _ => product => product.Price == price
            };

            return result;
        }
    }
}
