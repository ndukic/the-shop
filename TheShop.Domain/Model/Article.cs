using System;

namespace TheShop.Domain.Model
{
    public class Article : IArticle
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public bool IsSold { get; set; }
		public DateTime SoldDate { get; set; }
		public int BuyerUserId { get; set; }
	}
}
