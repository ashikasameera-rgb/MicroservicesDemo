using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        private Order() { }

        public Order(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
