using Microsoft.Extensions.DependencyInjection;
using TheShop.Domain;
using TheShop.Domain.Model;

namespace TheShop.Dal.InMemory
{
    public class ConfigureDal
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IEntityRepository<Article>, InMemoryEntityRepository<Article>>();
            services.AddSingleton<IEntityRepository<Order>, InMemoryEntityRepository<Order>>();
        }
    }
}
