using System;
using System.Collections.Generic;
using TheShop.Domain.Contract;
using TheShop.Domain.Model;

namespace TheShop.Domain.Service
{
    public interface ISupplierService
    {
        IEnumerable<Article> GetArticles(ArticleQuery articleQuery);
        bool IsArticleAvailable(Guid articleRef);


        // TODO: Mechanism to order all articles or none
        //Tuple<Guid, Guid?> ReserveArticles(Tuple<Guid, int>[] articleRefsAndCounts); // <articleRef, reservationRef> - reservationRef is null if unsuccessful
        //void ConfirmReservations(Guid[] reservationRefs);
        //void CancelReservations(Guid[] reservationRefs);
    }
}
