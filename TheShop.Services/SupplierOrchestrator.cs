using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TheShop.Domain;
using TheShop.Domain.Exceptions;
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

        public Article GetArticle(int id, int maxExpectedPrice)
        {
            var articles = GetAvailableArticles(id);

            var article = articles
                .Where(a => a.Price <= maxExpectedPrice)
                .FirstOrDefault(a => a.Price == articles.Min(cheapest => cheapest.Price));

            if (article == null)
            {
                _logger.LogWarning($"Article with id:{id} and price limit:{maxExpectedPrice} is not found");
                throw new ArticleNotFoundException($"Article with id:{id} and price limit:{maxExpectedPrice} is not found");
            }

            return article;
        }

        private List<Article> GetAvailableArticles(int id)
        {
            _logger.LogInformation($"Collecting articles with id:{id} from all suppliers");

            var list = new List<Article>();
            foreach (var supplierGateway in _supplierGateways)
            {
                bool articleExists = supplierGateway.IsArticleInInventory(id);
                if (articleExists)
                {
                    var article = supplierGateway.GetArticle(id);
                    list.Add(article);
                }
            }

            return list;
        }
    }
}
