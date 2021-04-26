using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface ISupplierOrchestrator
    {
        bool IsArticleInInventory(int id);
        Article GetArticle(int id, int maxExpectedPrice);
    }
}
