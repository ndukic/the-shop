using TheShop.Domain.Model;

namespace TheShop.Domain.Queries
{
    public interface IOrderReader
    {
        Order GetById(long id);
    }
}
