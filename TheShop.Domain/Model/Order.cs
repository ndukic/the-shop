using System;

namespace TheShop.Domain.Model
{
    public class Order : Entity
    {
        public long ArticleId { get; set; }
        public long BuyerId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
