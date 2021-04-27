using TheShop.Domain.Model;

namespace TheShop.Domain.Commands
{
    public interface IOrderCreator
    {
        void Save(Order order);
    }
}
