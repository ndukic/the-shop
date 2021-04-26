using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IShopService
    {
        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
        Article GetById(int id);
    }
}
