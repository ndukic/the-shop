using System;
using System.Collections.Generic;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;

namespace TheShop.Domain.Repositories
{
    public interface IArticleRepository
    {
        Article CreateArticle(Article article);
        Article GetArticle(Guid articleRef);
        void UpdateArticle(Article article);
        void RemoveArticle(Guid articleRef);
        IEnumerable<Article> GetArticles(ArticleQuery query);
    }
}
