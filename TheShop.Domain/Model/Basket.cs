using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop.Domain.Model
{
    public class Basket
    {
        public Guid CustomerRef { get; set; }
        public IEnumerable<BasketItem> BasketItems { get; set; }
        public double TotalPrice => BasketItems.Select(x => x.Count * x.UnitPrice).Sum();
    }
}
