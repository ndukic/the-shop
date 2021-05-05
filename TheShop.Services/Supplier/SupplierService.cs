using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Domain.Contract;
using TheShop.Domain.Exceptions;
using TheShop.Domain.Model;
using TheShop.Domain.Service;

namespace TheShop.Services.Supplier
{
    public class SupplierService : ISupplierService
    {
        private readonly ILogger<SupplierService> _logger;
        private readonly IEnumerable<ISupplierGateway> _supplierGateways;

        public SupplierService(ILogger<SupplierService> logger,
            IEnumerable<ISupplierGateway> supplierGateways)
        {
            _logger = logger;
            _supplierGateways = supplierGateways;
        }

        public IEnumerable<Article> GetArticles(ArticleQuery articleQuery)
        {
            throw new NotImplementedException(); // TODO
        }

        public bool IsArticleAvailable(Guid articleRef)
        {
            throw new NotImplementedException(); // TODO
        }
    }
}
