using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using TheShop.Dal.InMemory;
using TheShop.Domain;
using TheShop.TheClient;

namespace TheShop
{
    internal class Program
	{
		private static void Main(string[] args)
		{
			ConfigureLogger();

			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			var serviceProvider = serviceCollection.BuildServiceProvider();

			var logger = serviceProvider.GetService<ILogger<Program>>();
			logger.LogInformation("Application start");

			// Run client example
			var clientLogger = serviceProvider.GetService<ILogger<Client>>();
			var shopService = serviceProvider.GetService<IShopService>();
            Client.UseShopService(clientLogger, shopService);

			logger.LogInformation("Application end");
		}

		private static void ConfigureLogger()
        {
			Log.Logger = new LoggerConfiguration()
#if DEBUG
				.MinimumLevel.Debug()
#endif
				.WriteTo.File("TheShop.log")
				.WriteTo.Console()
				.CreateLogger();
		}

		private static void ConfigureServices(IServiceCollection services)
        {
			services.AddLogging(configure => configure.AddSerilog())
					.AddSingleton<IShopService, ShopService>()
					.AddSingleton<IDatabaseDriver, DatabaseDriver>();

		}
	}
}