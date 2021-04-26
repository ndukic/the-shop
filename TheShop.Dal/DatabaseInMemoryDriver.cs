using System.Collections.Generic;
using System.Linq;
using TheShop.Domain;
using TheShop.Domain.Model;

namespace TheShop.Dal.InMemory
{
    public class DatabaseInMemoryDriver : IDatabaseDriver
    {
		private List<Article> _articles = new List<Article>();
        private List<Order> _orders = new List<Order>();

        public Article GetById(long id)
		{
			return _articles.FirstOrDefault(x => x.Id == id);
		}

        public void Save(Article article)
		{
			_articles.Add(article);
        }

        public Order GetOrderById(long id)
        {
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Order order)
        {
            _orders.Add(order);
        }
    }
}
