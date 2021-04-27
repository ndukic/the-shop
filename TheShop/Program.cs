using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TheShop.TheClient;

namespace TheShop
{
    internal class Program
	{
		private static void Main(string[] args)
		{
			var services = Startup.ConfigureServices();
			var serviceProvider = services.BuildServiceProvider();

			var logger = serviceProvider.GetService<ILogger<Program>>();
			logger.LogInformation("Application start");

			serviceProvider.GetService<Client>().UseShopService();

			logger.LogInformation("Application end");

			Console.ReadKey();
		}
	}
}