﻿using Microsoft.Extensions.DependencyInjection;
using TheShop.Domain;

namespace TheShop.Services
{
    public class ConfigureShopServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<ISupplierOrchestrator, SupplierOrchestrator>();
            services.AddSingleton<ISupplierGateway, SupplierGatewayMock1>();
            services.AddSingleton<ISupplierGateway, SupplierGatewayMock2>();
            services.AddSingleton<ISupplierGateway, SupplierGatewayMock3>();
            services.AddSingleton<ISupplierGateway, SupplierGatewayMock4>();
        }
    }
}
