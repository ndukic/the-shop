using System.Collections.Generic;
using System.Linq;
using TheShop.Domain.Model;

namespace TheShop.Dal.InMemory
{
    public class InMemoryEntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        private readonly List<T> _entities = new List<T>();

        public T GetById(long id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public void Save(T entity)
        {
            _entities.Add(entity);
        }
    }
}
