using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public interface IDatabaseDriver
    {
		Article GetById(int id);
		void Save(Article article);
	}
}
