using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain.Model;

namespace TheShop.Domain.OrderHandling
{
    public class ShippingStartedHandler
    {
        private readonly ILogger<ShippingStartedHandler> _logger;
        private readonly IOrderStateUpdater _orderStateUpdater;

        public ShippingStartedHandler(ILogger<ShippingStartedHandler> logger,
            IOrderStateUpdater orderStateUpdater)
        {
            _logger = logger;
            _orderStateUpdater = orderStateUpdater;
        }

        public void Handle(Guid orderRef)
        {
            _logger.LogDebug($"Order shipping have started. OrderRef: {orderRef}");
            _orderStateUpdater.UpdateOrderStatus(orderRef, OrderState.SHIPPING_INITIATED);
        }
    }
}
