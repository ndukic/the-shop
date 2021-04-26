using Microsoft.Extensions.Logging;
using System;
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
			#region ordering article

			IArticle tempArticle = null;

			tempArticle = _supplierOrchestrator.GetArticle(id, maxExpectedPrice);

			#endregion

			#region selling article

			if (tempArticle is ArticleNotFound)
			{
				throw new Exception("Could not order article");
			}

			var article = (Article)tempArticle;

			_logger.LogDebug("Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				_databaseDriver.Save(article);
				_logger.LogInformation("Article with id=" + id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				_logger.LogError("Could not save article with id=" + id);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}

			#endregion
		}

		public Article GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}
}
