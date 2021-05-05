﻿using Microsoft.Extensions.Logging;
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

        //public bool IsArticleInInventory(long id)
        //{
        //    return AtLeastOneSupplierHaveAvailableArticle(id);
        //}

        //public Article GetArticle(long id, double maxPrice)
        //{
        //    var articles = GetAvailableArticles(id);
        //    articles = SelectArticlesWithinExpectedPrice(articles, maxPrice);
        //    var article = SelectCheapestArticle(articles);

        //    AssureArticleExists(article, id, maxPrice);

        //    return article;
        //}

        //private bool AtLeastOneSupplierHaveAvailableArticle(long id)
        //{
        //    _logger.LogInformation($"Querying over suppliers for article id: {id}");
        //    foreach (var supplierGateway in _supplierGateways)
        //    {
        //        if (supplierGateway.IsArticleInInventory(id))
        //        {
        //            _logger.LogInformation($"Found article with id: {id}");
        //            return true;
        //        }
        //    }

        //    _logger.LogInformation($"Couldn't find article with id: {id}");
        //    return false;
        //}

        //private IEnumerable<Article> GetAvailableArticles(long id)
        //{
        //    _logger.LogInformation($"Collecting articles with id:{id} from all suppliers");

        //    var list = new List<Article>();
        //    foreach (var supplierGateway in _supplierGateways)
        //    {
        //        bool articleExists = supplierGateway.IsArticleInInventory(id);
        //        if (articleExists)
        //        {
        //            var article = supplierGateway.GetArticle(id);
        //            list.Add(article);
        //        }
        //    }

        //    return list;
        //}

        private IEnumerable<Article> SelectArticlesWithinExpectedPrice(IEnumerable<Article> articles, double maxPrice)
        {
            return articles.Where(a => a.Price <= maxPrice);
        }

        private Article SelectCheapestArticle(IEnumerable<Article> articles)
        {
            return articles.FirstOrDefault(a => a.Price == articles.Min(cheapest => cheapest.Price));
        }

        private void AssureArticleExists(Article article, long id, double maxPrice)
        {
            if (article == null)
            {
                _logger.LogWarning($"Article with id:{id} and price limit:{maxPrice} is not found");
                throw new ArticleNotFoundException($"Article with id:{id} and price limit:{maxPrice} is not found");
            }
        }

        public IEnumerable<Article> GetArticles(ArticleQuery articleQuery)
        {
            throw new NotImplementedException();
        }

        public bool IsArticleAvailable(Guid articleRef)
        {
            throw new NotImplementedException();
        }
    }
}
