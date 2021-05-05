using System;
using TheShop.Domain.Model;

namespace TheShop.Domain.OrderHandling
{
    public interface IOrderStateUpdater
    {
        void UpdateOrderStatus(Guid orderRef, OrderState status);
    }
}
