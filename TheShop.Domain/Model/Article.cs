using System;

namespace TheShop.Domain.Model
{
    public class Article
    {
		public Guid ArticleRef { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

        public override string ToString()
        {
            return $"Article=ArticleRef:{ArticleRef}, Name:{Name}, Price:{Price:0.##}";
        }
    }
}
