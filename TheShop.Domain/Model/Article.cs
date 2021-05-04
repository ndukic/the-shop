using System;

namespace TheShop.Domain.Model
{
    public class Article : Entity
    {
		public Guid ArticleRef { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
