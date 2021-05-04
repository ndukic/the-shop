using System;

namespace TheShop.Domain.Model
{
    public class BasketItem
    {
        public Guid BasketItemRef { get; set; }
        public Guid CustomerRef { get; set; }
        public Guid ArticleRef { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
