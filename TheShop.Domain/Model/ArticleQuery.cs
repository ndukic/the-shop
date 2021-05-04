namespace TheShop.Domain.Model
{
    public class ArticleQuery
    {
        public string Name { get; set; }
        public double? PriceMin { get; set; }
        public double? PriceMax { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}