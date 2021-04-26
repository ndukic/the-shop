using TheShop.Domain.Model;

namespace TheShop.Services
{
    public interface ISupplierGateway
    {
        bool IsArticleInInventory(long id);
        Article GetArticle(long id);
    }
}
