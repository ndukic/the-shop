using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Domain.Contract;
using TheShop.Domain.Exceptions;
using TheShop.Domain.Helpers;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;
using TheShop.Domain.Service;

namespace TheShop.Domain
{
    public class ShopService : IShopService
	{
		private readonly ILogger<ShopService> _logger;

        private readonly ICatalogService _catalogService;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketReader _basketReader;
        private readonly IOrderRepository _orderRepository;

        public ShopService(ILogger<ShopService> logger,
            ICatalogService catalogService,
            IBasketRepository basketRepository,
            IBasketReader basketReader,
            IOrderRepository orderRepository)
		{	
			_logger = logger;
            _catalogService = catalogService;
            _basketRepository = basketRepository;
            _basketReader = basketReader;
            _orderRepository = orderRepository;
        }

        public IEnumerable<Article> GetArticles(ArticleQuery query)
        {
            return _catalogService.GetArticles(query);
        }

        public void AddArticleToTheBasket(Article article, int count, Guid customerRef)
        {
            var basketItem = BuildBasketItem(article, count, customerRef);
            _basketRepository.CreateBasketItem(basketItem);
        }

        public void RemoveBasketItem(Guid basketItemRef)
        {
            _basketRepository.RemoveBasketItem(basketItemRef);
        }

        public void EditBasketItem(BasketItem basketItem)
        {
            _basketRepository.UpdateBasketItem(basketItem);
        }

        public Basket GetBasket(Guid customerRef)
        {
            return _basketReader.GetBasketByCustomerRef(customerRef);
        }

        public void ClearBasket(Guid customerRef)
        {
            _basketRepository.RemoveAllBasketItems(customerRef);
        }

        public void PlaceOrder(Basket basket, Guid customerRef)
        {
            if (!basket.BasketItems.Any())
            {
                _logger.LogInformation($"Order was not created because basket is empty");
                throw new BasketIsEmptyException();
            }

            Order order = BuildOrder(customerRef);
            var createdOrder = _orderRepository.CreateOrder(order);

            SaveOrderItems(basket, createdOrder);

            // TODO: initiate each article availability check
            // TODO: after availability is confirmed, initiate shipping - we draw the line here, shipping is another service
            // TODO(bonus): Make event handler after order have been shipped to update the status
        }

        public Order GetOrder(Guid orderRef)
        {
            _logger.LogDebug($"Fetch order with items, orderRef: {orderRef}");
            return _orderRepository.GetOrderWithItemsByOrderRef(orderRef);
        }

        private BasketItem BuildBasketItem(Article article, int count, Guid customerRef)
        {
            var basketItem = MapArticleToBasketItem(article);
            basketItem.Count = count;
            basketItem.CustomerRef = customerRef;
            return basketItem;
        }

        private BasketItem MapArticleToBasketItem(Article article)
        {
            return new BasketItem()
            {
                ArticleRef = article.ArticleRef,
                Name = article.Name,
                UnitPrice = article.Price
            };
        }

        private Order BuildOrder(Guid customerRef)
        {
            var order = new Order();
            order.CustomerRef = customerRef;
            order.OrderStatus = OrderState.ORDER_CREATED;
            return order;
        }

        private void SaveOrderItems(Basket basket, Order createdOrder)
        {
            foreach (var basketItem in basket.BasketItems)
            {
                var orderItem = new OrderItem();
                orderItem.OrderRef = createdOrder.OrderRef;
                orderItem.ArticleRef = basketItem.ArticleRef;
                orderItem.Count = basketItem.Count;
                orderItem.Name = basketItem.Name;
                orderItem.UnitPrice = basketItem.UnitPrice;

                _orderRepository.CreateOrderItem(orderItem);
            }
        }
    }
}
