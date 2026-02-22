using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Data
{
    public class OrderServiceDbContext:DbContext
    {
        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options)
        : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
    }
}
