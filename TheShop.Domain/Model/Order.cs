using System;
using System.Collections.Generic;

namespace TheShop.Domain.Model
{
    public class Order
    {
        public Guid OrderRef { get; set; }
        public Guid CustomerRef { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderState OrderStatus { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
