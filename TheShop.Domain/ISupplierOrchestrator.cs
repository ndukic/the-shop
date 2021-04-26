using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface ISupplierOrchestrator
    {
        bool IsArticleInInventory(long id);
        Article GetArticle(long id, double maxExpectedPrice);
    }
}
