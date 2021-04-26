using Microsoft.Extensions.DependencyInjection;

namespace TheShop.Domain
{
    public class ConfigureDomain
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IShopService, ShopService>();
        }
    }
}
