using System.Collections.Generic;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;

namespace TheShop.Services.Supplier
{
    public interface ISupplierGateway
    {
        IEnumerable<Article> FetchAllArticles();
        IEnumerable<Article> GetArticles(ArticleQuery query);

    }
}
