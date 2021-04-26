using System;

namespace TheShop.Domain.Model
{
    public class Order
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long BuyerId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
