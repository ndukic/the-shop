using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain;

namespace TheShop.TheClient
{
    public class Client
    {
        public static void UseShopService(ILogger logger, IShopService shopService)
        {
			try
			{
				//order and sell
				shopService.OrderAndSellArticle(1, 20, 10);
			}
			catch (Exception ex)
			{
				logger.LogWarning(ex, "OrderAndSellArticle failed");
			}

			try
			{
				//print article on console
				var article = shopService.GetById(1);
				logger.LogInformation($"Found article with ID:{article.Id}");
			}
			catch (Exception ex)
			{
				logger.LogWarning($"Article not found: {ex}");
			}

			try
			{
				//print article on console				
				var article = shopService.GetById(12);
				logger.LogInformation($"Found article with ID:{article.Id}");
			}
			catch (Exception ex)
			{
				logger.LogWarning($"Article not found: {ex}");
			}

			Console.ReadKey();
		}
    }
}
