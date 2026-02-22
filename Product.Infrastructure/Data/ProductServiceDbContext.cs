using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Data
{
    public class ProductServiceDbContext:DbContext
    {
        public ProductServiceDbContext(DbContextOptions<ProductServiceDbContext> options):base(options) 
        {

        }

        public DbSet<Product> Products => Set<Product>();
    }
}
