using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;

namespace TheShop.Dal.InMemory.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ILogger<ArticleRepository> _logger;
        private readonly TheShopDbContext _context;
        private readonly int DefaultPage = 0;
        private readonly int DefaultPageSize = 20;

        public ArticleRepository(ILogger<ArticleRepository> logger, TheShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Article CreateArticle(Article article)
        {
            _logger.LogDebug($"Creating article: {article}");
            var created = _context.Articles.Add(article).Entity;
            _context.SaveChanges();
            return created;
        }

        public Article GetArticle(Guid articleRef)
        {
            _logger.LogDebug($"Fetching article with articleRef: {articleRef}");
            return _context.Articles.FirstOrDefault(x => x.ArticleRef == articleRef);
        }

        public IEnumerable<Article> GetArticles(ArticleQuery query)
        {
            _logger.LogDebug($"Fetching articles for params {query}");

            var filteredArticles = ApplyFilters(query);

            return filteredArticles.ToList();
        }

        public void RemoveArticle(Guid articleRef)
        {
            _logger.LogDebug($"Removing article with articleRef: {articleRef}");
            var articleToRemove = _context.Articles.FirstOrDefault(x => x.ArticleRef == articleRef);
            _context.Articles.Remove(articleToRemove);
            _context.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            _logger.LogDebug($"Updating article: {article.ArticleRef}");
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private IQueryable<Article> ApplyFilters(ArticleQuery query)
        {
            var page = query.Page ?? DefaultPage;
            var pageSize = query.PageSize ?? DefaultPageSize;

            var tempQuery = _context.Articles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                tempQuery = tempQuery.Where(x => x.Name.Contains(query.Name, StringComparison.InvariantCultureIgnoreCase));
            }
            if (query.PriceMin.HasValue)
            {
                tempQuery = tempQuery.Where(x => x.Price >= query.PriceMin.Value);
            }
            if (query.PriceMax.HasValue)
            {
                tempQuery = tempQuery.Where(x => x.Price <= query.PriceMax.Value);
            }

            return tempQuery.Skip(page * pageSize).Take(pageSize);
        }
    }
}
