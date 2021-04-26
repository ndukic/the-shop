using Microsoft.Extensions.DependencyInjection;
using System;
using TheShop.Dal.InMemory;
using TheShop.Domain;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IDatabaseDriver, DatabaseDriver>()
				.AddSingleton<ShopService>()
				.BuildServiceProvider();

			var shopService = serviceProvider.GetService<ShopService>();
			ClientSequence(shopService);
		}

		private static void ClientSequence(ShopService shopService)
        {
			try
			{
				//order and sell
				shopService.OrderAndSellArticle(1, 20, 10);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = shopService.GetById(12);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}
	}
}