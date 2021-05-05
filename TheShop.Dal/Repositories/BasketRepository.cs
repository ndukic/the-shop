using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;

namespace TheShop.Dal.InMemory.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ILogger<BasketRepository> _logger;
        private readonly TheShopDbContext _context;

        public BasketRepository(ILogger<BasketRepository> logger, TheShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public BasketItem CreateBasketItem(BasketItem basketItem)
        {
            _logger.LogDebug($"Creating basket item: {basketItem}");
            basketItem.BasketItemRef = Guid.NewGuid();
            var createdItem = _context.BasketItems.Add(basketItem).Entity;
            _context.SaveChanges();
            return createdItem;
        }

        public void UpdateBasketItem(BasketItem basketItem)
        {
            _logger.LogDebug($"Updating basket item: {basketItem}");
            _context.Entry(basketItem).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<BasketItem> GetBasketItemsByCustomerRef(Guid customerRef)
        {
            _logger.LogDebug($"Fetching basket items for customerRef: {customerRef}");
            return _context.BasketItems.Where(x => x.CustomerRef == customerRef).ToList();
        }

        public void RemoveAllBasketItems(Guid customerRef)
        {
            _logger.LogDebug($"Removing basket items for customerRef: {customerRef}");
            var itemsToDelete = _context.BasketItems.Where(x => x.CustomerRef == customerRef);
            _context.BasketItems.RemoveRange(itemsToDelete);
            _context.SaveChanges();
        }

        public void RemoveBasketItem(Guid basketItemRef)
        {
            _logger.LogDebug($"Removing basket item with basketItemRef: {basketItemRef}");
            var itemToDelete = _context.BasketItems.Where(x => x.BasketItemRef == basketItemRef);
            _context.Remove(itemToDelete);
            _context.SaveChanges();
        }
    }
}
