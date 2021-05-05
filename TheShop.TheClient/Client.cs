using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain;

namespace TheShop.TheClient
{
    public class Client
    {
		private readonly ILogger<Client> _logger;
		private readonly IShopService _shopService;

		public Client(ILogger<Client> logger, IShopService shopService)
        {
			_logger = logger;
			_shopService = shopService;
        }

        public void UseShopService()
        {
			//try
			//{
			//	//order and sell
			//	_shopService.OrderAndSellArticle(1, 20, 10);
			//}
			//catch (Exception ex)
			//{
			//	_logger.LogWarning(ex, "OrderAndSellArticle failed");
			//}

			//try
			//{
			//	//print article
			//	var article = _shopService.GetById(1);
			//	_logger.LogInformation($"Found article with ArticleRef:{article.ArticleRef}");
			//}
			//catch (Exception ex)
			//{
			//	_logger.LogWarning($"Article not found: {ex}");
			//}

			//try
			//{
			//	//print article				
			//	var article = _shopService.GetById(12);
			//	_logger.LogInformation($"Found article with ArticleRef:{article.ArticleRef}");
			//}
			//catch (Exception ex)
			//{
			//	_logger.LogWarning($"Article not found: {ex}");
			//}
		}
    }
}
