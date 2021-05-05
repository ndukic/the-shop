using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;
using TheShop.Domain.Service;

namespace TheShop.Services.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly ILogger<CatalogService> _logger;

        private readonly IArticleRepository _articleRepository;

        public CatalogService(ILogger<CatalogService> logger,
            IArticleRepository articleRepository)
        {
            _logger = logger;
            _articleRepository = articleRepository;
        }

        public IEnumerable<Article> GetArticles(ArticleQuery articleQuery)
        {
            _logger.LogDebug($"Fetching articles");
            return _articleRepository.GetArticles(articleQuery);
        }

        public void RefreshCatalog()
        {
            _logger.LogDebug($"Refreshing articles data");
            // TODO: Query suppliers for articles catalog if our Article repo is empty
        }
    }
}
