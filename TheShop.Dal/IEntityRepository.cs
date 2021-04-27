namespace TheShop.Dal.InMemory
{
    public interface IEntityRepository<T>
    {
        T GetById(long id);

        void Save(T entity);
    }
}
