using System;
using System.Diagnostics.CodeAnalysis;

namespace TheShop.Domain.Model
{
    public class BasketItem : IEquatable<BasketItem>
    {
        public Guid BasketItemRef { get; set; }
        public Guid CustomerRef { get; set; }
        public Guid ArticleRef { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }

        public bool Equals([AllowNull] BasketItem other) => other != null &&
            Equals(BasketItemRef, other.BasketItemRef) &&
            Equals(CustomerRef, other.CustomerRef) &&
            Equals(ArticleRef, other.ArticleRef) &&
            Equals(Name, other.Name) &&
            Equals(UnitPrice, other.UnitPrice) &&
            Equals(Count, other.Count);

        public override string ToString()
        {
            return $"BasketItem=BasketItemRef:{BasketItemRef}, CustomerRef:{CustomerRef}, ArticleRef:{ArticleRef}, Name:{Name}, Price:{UnitPrice:0.##}, Count:{Count}";
        }
    }
}
