using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;

namespace TheShop.Domain.OrderHandling
{
    public class OrderStateUpdater : IOrderStateUpdater
    {
        private readonly ILogger<OrderStateUpdater> _logger;
        private readonly IOrderRepository _orderRepository;
        //private readonly Tuple<OrderState, OrderState> _allowedTransitions; TODO

        public OrderStateUpdater(ILogger<OrderStateUpdater> logger,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public void UpdateOrderStatus(Guid orderRef, OrderState newState)
        {
            _logger.LogDebug($"Updating order state to {newState} for orderRef: {orderRef}");

            var order = _orderRepository.GetOrderByOrderRef(orderRef);

            order.OrderStatus = newState;

            _orderRepository.UpdateOrder(order);
        }
    }
}
