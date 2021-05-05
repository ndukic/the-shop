using System.Collections.Generic;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;

namespace TheShop.Domain.Service
{
    public interface ICatalogService
    {
        void RefreshCatalog();
        IEnumerable<Article> GetArticles(ArticleQuery articleQuery);
    }
}
