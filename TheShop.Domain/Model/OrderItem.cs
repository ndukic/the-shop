using System;

namespace TheShop.Domain.Model
{
    public class OrderItem
    {
        public Guid OrderItemRef { get; set; }
        public Guid OrderRef { get; set; }
        public Guid ArticleRef { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"OrderItem=OrderItemRef:{OrderItemRef}, OrderRef:{OrderRef}, ArticleRef:{ArticleRef}, Name:{Name}, UnitPrice:{UnitPrice:0.##}, Count:{Count}";
        }
    }
}
