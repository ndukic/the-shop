using Microsoft.Extensions.DependencyInjection;
using TheShop.Domain;

namespace TheShop.Dal.InMemory
{
    public class ConfigureDal
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseDriver, DatabaseInMemoryDriver>();
        }
    }
}
