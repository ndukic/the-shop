using System;
using TheShop.Domain.Model;

namespace TheShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order GetOrderByOrderRef(Guid orderRef);
        Order GetOrderWithItemsByOrderRef(Guid orderRef);
        void UpdateOrder(Order order);
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
    }
}
