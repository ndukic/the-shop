using System;
using TheShop.Domain.Model;

namespace TheShop.Domain.Helpers
{
    public interface IBasketReader
    {
        Basket GetBasketByCustomerRef(Guid customerRef);
    }
}
