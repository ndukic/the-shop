using Microsoft.Extensions.DependencyInjection;
using TheShop.Domain.Service;
using TheShop.Services.Supplier;

namespace TheShop.Services
{
    public class ConfigureShopServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<ISupplierService, SupplierService>();
            //services.AddSingleton<ISupplierGateway, SupplierGatewayMock1>();
            //services.AddSingleton<ISupplierGateway, SupplierGatewayMock2>();
            //services.AddSingleton<ISupplierGateway, SupplierGatewayMock3>();
            //services.AddSingleton<ISupplierGateway, SupplierGatewayMock4>();
        }
    }
}
