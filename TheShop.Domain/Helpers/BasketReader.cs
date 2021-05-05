using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;

namespace TheShop.Domain.Helpers
{
    public class BasketReader : IBasketReader
    {
        private readonly ILogger<BasketReader> _logger;
        private readonly IBasketRepository _basketRepository;

        public BasketReader(ILogger<BasketReader> logger, IBasketRepository basketRepository)
        {
            _logger = logger;
            _basketRepository = basketRepository;
        }

        public Basket GetBasketByCustomerRef(Guid customerRef)
        {
            _logger.LogDebug($"Creating Basket from basket items for customer: {customerRef}");

            return new Basket()
            {
                CustomerRef = customerRef,
                BasketItems = _basketRepository.GetBasketItemsByCustomerRef(customerRef)
            };
        }
    }
}
