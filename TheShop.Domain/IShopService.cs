using System;
using System.Collections.Generic;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IShopService
    {
        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
        Article GetById(int id);

        // Customer should be able to browse articles catalog
        IEnumerable<Article> GetArticles(ArticleQuery query);
        // Customer should be able to see article details (is it really needed?)
        //Article GetArticleByRef(Guid articleRef);

        // BASKET
        // Customer should be able to add articles to the basket
        void AddArticleToBasket(Article article, int count, Guid customerRef);
        // Customer should be able to remove items from the basket
        void RemoveBasketItem(Guid basketItemRef);
        // Customer should be able to edit basket item (e.g. change count)
        void EditBasketItem(BasketItem basketItem);
        // Customer should be able to fetch his Basket
        Basket GetBasket(Guid customerRef);
        // Customer should be able to empty the basket (delete all basket items)
        void ClearBasket(Guid customerRef);

        // ORDER
        // Customer should be able to make Order from Basket
        void CreateOrder(Guid customerRef);
        // Customer should be able to get his order (e.g. to check the status)
        Order GetOrder(Guid orderRef);
        // Customer should be able to get his order history. OrderQuery should be used for filtering (e.g. set page, set date range, etc)
        //IEnumerable<Order> GetOrders(OrderQuery query);
    }
}
