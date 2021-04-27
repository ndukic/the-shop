using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TheShop.Dal.InMemory;
using TheShop.Domain;
using TheShop.Services;
using TheShop.TheClient;

namespace TheShop
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddLogging(configure => configure.AddSerilog());

            ConfigureDal.Configure(services);
            ConfigureShopServices.Configure(services);
            ConfigureDomain.Configure(services);

            services.AddTransient<Client>();

            return services;
        }
    }
}
