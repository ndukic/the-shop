using TheShop.Domain.Model;
using TheShop.Domain.Queries;

namespace TheShop.Dal.InMemory.Queries
{
    public class OrderReader : IOrderReader
    {
        private readonly IEntityRepository<Order> _orderRepository;

        public OrderReader(IEntityRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetById(long id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
