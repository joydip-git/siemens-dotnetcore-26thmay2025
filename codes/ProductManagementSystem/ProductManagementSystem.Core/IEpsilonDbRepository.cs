namespace ProductManagementSystem.Core
{
    public interface IEpsilonDbRepository<T,TId>
    {
        List<T>? FetchAll();
        T? Fetch(TId id);
        T? Insert(T entity);
        T? Update(TId id, T entity);
        int Delete(TId id);
    }
}
