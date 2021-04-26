using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain.Exceptions;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public class ShopService : IShopService
	{
		private readonly ILogger<ShopService> _logger;
		private readonly IDatabaseDriver _databaseDriver;
		private readonly ISupplierOrchestrator _supplierOrchestrator;

		public ShopService(ILogger<ShopService> logger,
			IDatabaseDriver databaseDriver,
			ISupplierOrchestrator supplierOrchestrator)
		{
			_logger = logger;
			_databaseDriver = databaseDriver;
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
			_logger.LogDebug($"Trying to sell article with id:{article.Id} to buyer with id:{buyerId}");

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                _databaseDriver.Save(article);
                _logger.LogInformation($"Article with id={article.Id} is sold.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError("Could not save article with id=" + article.Id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }
        }

		public Article GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}
}
