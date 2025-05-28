namespace Siemens.DotNetCore.PmsApp.DataAccessLayer
{
    public interface IPmsDao<T, TId> where T : class
    {
        T? Insert(T entity);
        T? Update(TId id, T entity);
        T? Delete(TId id);
        IEnumerable<T> GetAll();
        T? GetById(TId id);
    }
}
