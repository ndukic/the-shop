using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TheShop.Domain.Commands;
using TheShop.Domain.Exceptions;
using TheShop.Domain.Model;
using TheShop.Domain.Queries;

namespace TheShop.Domain
{
    public class ShopService : IShopService
	{
		private readonly ILogger<ShopService> _logger;

		private readonly ISupplierService _supplierOrchestrator;
		private readonly IArticleCreator _articleCreator;
		private readonly IArticleReader _articleReader;
		private readonly IOrderCreator _orderCreator;

		public ShopService(ILogger<ShopService> logger,
			IArticleCreator articleCreator,
			IArticleReader articleReader,
			IOrderCreator orderCreator,
			ISupplierService supplierOrchestrator)
		{	
			_logger = logger;
			_articleCreator = articleCreator;
			_articleReader = articleReader;
			_orderCreator = orderCreator;
			_supplierOrchestrator = supplierOrchestrator;
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
            try
            {
				var article = TryOrderArticle(id, maxExpectedPrice);
				TrySellArticle(article, buyerId);
			}
            catch (ArticleNotFoundException notFound)
            {
				_logger.LogWarning($"Unable to get article with id:{id}. ", notFound);
                throw;
            }
			catch (Exception e)
            {
				_logger.LogError($"Unknown error happened while trying to order. Exception: ", e);
			}
		}

		public Article TryOrderArticle(int id, int maxExpectedPrice)
        {
			_logger.LogDebug($"Trying to order article with id:{id} from supplier");
			return _supplierOrchestrator.GetArticle(id, maxExpectedPrice);
        }

		public void TrySellArticle(Article article, int buyerId)
        {
			_logger.LogDebug($"Trying to sell article with ref:{article.ArticleRef} to customer with id:{buyerId}");

			var order = CreateOrder(article, buyerId);

			try
            {
				_articleCreator.Save(article);
				_orderCreator.Save(order);
                _logger.LogInformation($"Article with ref:{article.ArticleRef} is sold. Order ref:{order.OrderRef}");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError($"Could not save order");
                throw new Exception("Could not save order");
            }
            catch (Exception)
            {
            }
        }

		public Article GetById(int id)
		{
			return _articleReader.GetById(id);
		}

		private Order CreateOrder(Article article, long buyerId)
        {
			return new Order()
			{
				CreatedDate = DateTime.Now
			};
		}

        public IEnumerable<Article> GetArticles(ArticleQuery query)
        {
            throw new NotImplementedException();
        }

        public void AddArticleToBasket(Article article, int count, Guid customerRef)
        {
            throw new NotImplementedException();
        }

        public void RemoveBasketItem(Guid basketItemRef)
        {
            throw new NotImplementedException();
        }

        public void EditBasketItem(BasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public Basket GetBasket(Guid customerRef)
        {
            throw new NotImplementedException();
        }

        public void ClearBasket(Guid customerRef)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Guid customerRef)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid orderRef)
        {
            throw new NotImplementedException();
        }
    }
}
