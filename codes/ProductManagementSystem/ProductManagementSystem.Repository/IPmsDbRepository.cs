namespace ProductManagementSystem.Repository
{
    public interface IPmsDbRepository<T,TId>
    {
        List<T> FetchAll();
        T Fetch(TId id);
        int Insert(T entity);
        int Update(TId id, T entity);
        int Delete(TId id);
    }
}
