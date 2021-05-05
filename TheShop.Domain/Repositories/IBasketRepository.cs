using System;
using System.Collections.Generic;
using TheShop.Domain.Model;

namespace TheShop.Domain.Repositories
{
    public interface IBasketRepository
    {
        IEnumerable<BasketItem> GetBasketItemsByCustomerRef(Guid customerRef);
        void RemoveAllBasketItems(Guid customerRef);
        BasketItem CreateBasketItem(BasketItem basketItem);
        void UpdateBasketItem(BasketItem basketItem);
        void RemoveBasketItem(Guid basketItem);
    }
}
