using System;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Order GetOrderByRef(Guid orderRef);
        void UpdateOrder(Order order);
        // void RemoveOrder(Guid orderRef); // should we ever delete it?
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
    }
}
