using TheShop.Domain.Model;

namespace TheShop.Services
{
    public interface ISupplierGateway
    {
        bool IsArticleInInventory(int id);
        Article GetArticle(int id);
    }
}
