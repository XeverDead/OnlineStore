using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Models;
using OnlineStore.Dal.Databases;
using OnlineStore.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Dal.Repositories.EFRepositories
{
    public class ProductRepository : IRepository<Product>
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
            var productToUpdate = await GetById(product.Id);

            var productEntry = _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            return productEntry.Entity;
        }
    }
}
