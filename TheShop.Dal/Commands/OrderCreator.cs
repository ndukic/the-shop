using TheShop.Domain.Commands;
using TheShop.Domain.Model;

namespace TheShop.Dal.InMemory.Commands
{
    public class OrderCreator : IOrderCreator
    {
        private readonly IEntityRepository<Order> _OrderRepository;

        public OrderCreator(IEntityRepository<Order> OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public void Save(Order Order)
        {
            _OrderRepository.Save(Order);
        }
    }
}
