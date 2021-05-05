using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;

namespace TheShop.Dal.InMemory.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;
        private readonly TheShopDbContext _context;

        public OrderRepository(ILogger<OrderRepository> logger, TheShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            order.OrderRef = Guid.NewGuid();
            order.CreatedDate = DateTime.Now;
            var created = _context.Orders.Add(order).Entity;
            _context.SaveChanges();
            return created;
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            orderItem.OrderItemRef = Guid.NewGuid();
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public Order GetOrderByOrderRef(Guid orderRef)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderRef == orderRef);
        }

        public Order GetOrderWithItemsByOrderRef(Guid orderRef)
        {
            var order = GetOrderByOrderRef(orderRef);
            order.OrderItems = _context.OrderItems.Where(item => item.OrderRef == orderRef);
            return order;
        }

        public void UpdateOrder(Order order)
        {
            _logger.LogDebug($"Editing order: {order}");
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _logger.LogDebug($"Editing order item: {orderItem}");
            _context.Entry(orderItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
