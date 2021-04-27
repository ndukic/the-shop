using TheShop.Domain.Model;

namespace TheShop.Domain.Queries
{
    public interface IArticleReader
    {
        Article GetById(long id);
    }
}
