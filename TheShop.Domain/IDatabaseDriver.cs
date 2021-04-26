using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IDatabaseDriver
    {
		Article GetById(long id);
		void Save(Article article);

		Order GetOrderById(long id);
		void Save(Order order);
	}
}
