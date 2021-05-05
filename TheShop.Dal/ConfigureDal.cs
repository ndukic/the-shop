using Microsoft.Extensions.DependencyInjection;
using TheShop.Dal.InMemory.Repositories;
using TheShop.Domain.Repositories;
using TheShop.Services.Catalog;

namespace TheShop.Dal.InMemory
{
    public class ConfigureDal
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<TheShopDbContext>();
            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddSingleton<IBasketRepository, BasketRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
        }
    }
}
