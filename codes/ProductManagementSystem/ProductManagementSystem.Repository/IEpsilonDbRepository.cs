namespace ProductManagementSystem.Repository
{
    public interface IEpsilonDbRepository<T, TId>
    {
        List<T> FetchAll();
        T Fetch(TId id);
        bool Insert(T entity);
        bool Update(TId id, T entity);
        bool Delete(TId id);
    }
}
