using System;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IBasketRepository
    {
        Basket GetBasketByCustomerRef(Guid customerRef);
        void RemoveBasket(Guid customerRef);
        Basket AddBasketItem(Article article, Guid customerRef);
        Basket EditBasketItem(BasketItem basketItem);
        void RemoveBasketItem(Guid basketItem);
    }
}
