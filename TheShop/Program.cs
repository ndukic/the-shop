using Microsoft.Extensions.DependencyInjection;
using TheShop.Dal.InMemory;
using TheShop.Domain;
using TheShop.TheClient;

namespace TheShop
{
    internal class Program
	{
		private static void Main(string[] args)
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IShopService, ShopService>()
				.AddSingleton<IDatabaseDriver, DatabaseDriver>()
				
				.BuildServiceProvider();

			var shopService = serviceProvider.GetService<IShopService>();
            Client.UseShopService(shopService);
		}
	}
}