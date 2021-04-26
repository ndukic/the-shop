using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TheShop.Domain;
using TheShop.Domain.Model;

namespace TheShop.Services
{
    public class SupplierOrchestrator : ISupplierOrchestrator
    {
        private readonly ILogger<SupplierOrchestrator> _logger;
        private readonly IEnumerable<ISupplierGateway> _supplierGateways;

        public SupplierOrchestrator(ILogger<SupplierOrchestrator> logger,
            IEnumerable<ISupplierGateway> supplierGateways)
        {
            _logger = logger;
            _supplierGateways = supplierGateways;
        }

        public bool IsArticleInInventory(int id)
        {
            _logger.LogInformation($"Querying over suppliers for article id: {id}");
            foreach (var supplierGateway in _supplierGateways)
            {
                if (supplierGateway.IsArticleInInventory(id))
                {
                    _logger.LogInformation($"Found article with id: {id}");
                    return true;
                }
            }

            _logger.LogInformation($"Couldn't find article with id: {id}");
            return false;
        }

        public IArticle GetArticle(int id, int maxExpectedPrice)
        {
            Article article = null;
            foreach (var supplierGateway in _supplierGateways)
            {
                bool articleExists = supplierGateway.IsArticleInInventory(id);
                if (articleExists)
                {
                    var articleCandidate = supplierGateway.GetArticle(id);
                    bool isPriceLessThanMax = articleCandidate.Price <= maxExpectedPrice;
                    if (isPriceLessThanMax)
                    {
                        bool isPriceBetterThanCurrentBest = article == null || articleCandidate.Price < article.Price;
                        if (isPriceBetterThanCurrentBest)
                        {
                            article = articleCandidate;
                        }
                    }
                }
            }

            if (article == null)
            {
                return new ArticleNotFound();
            }

            return article;
        }
    }
}
