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

			System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionResolver;

			serviceProvider.GetService<TestClient>().UseShopService();

            logger.LogInformation("Application end");

			Console.ReadKey();
		}

		static void UnhandledExceptionResolver(object sender, UnhandledExceptionEventArgs e)
		{
			Console.WriteLine(e.ExceptionObject.ToString());
			Console.WriteLine("Press Enter to Exit");
			Console.ReadKey();
			Environment.Exit(0);
		}
	}
}