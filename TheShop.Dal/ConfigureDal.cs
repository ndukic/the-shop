using Microsoft.Extensions.DependencyInjection;
using TheShop.Dal.InMemory.Commands;
using TheShop.Dal.InMemory.Queries;
using TheShop.Domain.Commands;
using TheShop.Domain.Model;
using TheShop.Domain.Queries;

namespace TheShop.Dal.InMemory
{
    public class ConfigureDal
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IArticleCreator, ArticleCreator>();
            services.AddSingleton<IArticleReader, ArticleReader>();
            services.AddSingleton<IOrderCreator, OrderCreator>();
            services.AddSingleton<IOrderReader, OrderReader>();
            services.AddSingleton<IEntityRepository<Article>, InMemoryEntityRepository<Article>>();
            services.AddSingleton<IEntityRepository<Order>, InMemoryEntityRepository<Order>>();
        }
    }
}
