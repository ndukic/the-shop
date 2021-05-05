using TheShop.Domain.Common;

namespace TheShop.Domain.Contract
{
    public class ArticleQuery
    {
        public string Name { get; set; }
        public double? PriceMin { get; set; }
        public double? PriceMax { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public override string ToString()
        {
            return $"ArticleQuery=Name:{Name}, PriceMin:{PriceMin.TwoSpacesOrNull()}, PriceMax:{PriceMax.TwoSpacesOrNull()}, Page:{Page.IntOrNull()}, PageSize{PageSize.IntOrNull()}";
        }
    }
}