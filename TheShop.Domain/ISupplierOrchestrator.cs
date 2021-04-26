using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface ISupplierOrchestrator
    {
        bool IsArticleInInventory(int id);
        IArticle GetArticle(int id, int maxExpectedPrice);
    }
}
