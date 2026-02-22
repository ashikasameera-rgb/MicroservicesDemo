using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.ProductServiceRepositories
{
    public class ProductServiceRepository : IProductServiceRepository
    {
        private readonly ProductServiceDbContext _dbContext;
        public ProductServiceRepository(ProductServiceDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task AddAsync(Product product)
        {
           await _dbContext.Products.AddAsync(product);  
            await _dbContext.SaveChangesAsync();
    
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return  await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
