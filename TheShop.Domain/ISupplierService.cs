using System;
using System.Collections.Generic;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface ISupplierService
    {
        bool IsArticleInInventory(long id);
        Article GetArticle(long id, double maxExpectedPrice);

        IEnumerable<Article> GetArticles(ArticleQuery articleQuery);
        bool IsArticleAvailable(Guid articleRef);
        

        // Mechanism to order all articles or none
        //Tuple<Guid, Guid?> ReserveArticles(Guid[] articleRefs); // <articleRef, reservationRef> - reservationRef is null if unsuccessful
        //void ConfirmReservations(Guid[] reservationRefs);
        //void CancelReservations(Guid[] reservationRefs);
    }
}
