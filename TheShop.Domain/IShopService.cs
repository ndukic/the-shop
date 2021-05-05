using System;
using System.Collections.Generic;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IShopService
    {
        IEnumerable<Article> GetArticles(ArticleQuery query);

        void AddArticleToTheBasket(Article article, int count, Guid customerRef);
        void RemoveBasketItem(Guid basketItemRef);
        void EditBasketItem(BasketItem basketItem);
        Basket GetBasket(Guid customerRef);
        void ClearBasket(Guid customerRef);

        void PlaceOrder(Basket basket, Guid customerRef);
        Order GetOrder(Guid orderRef);
        //IEnumerable<Order> GetOrders(OrderQuery query); TODO
    }
}
