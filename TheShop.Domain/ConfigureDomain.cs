using Microsoft.Extensions.DependencyInjection;
using TheShop.Domain.Helpers;

namespace TheShop.Domain
{
    public class ConfigureDomain
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IShopService, ShopService>();
            services.AddSingleton<IBasketReader, BasketReader>();
        }
    }
}
