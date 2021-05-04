using System;

namespace TheShop.Domain.Model
{
    public class OrderItem
    {
        public Guid OrderItemRef { get; set; }
        public Guid OrdeRef { get; set; }
        public Guid ArticleRef { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
