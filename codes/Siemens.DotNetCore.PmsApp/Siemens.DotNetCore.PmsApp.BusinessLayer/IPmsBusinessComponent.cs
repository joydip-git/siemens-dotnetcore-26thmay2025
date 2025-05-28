namespace Siemens.DotNetCore.PmsApp.BusinessLayer
{
    internal interface IPmsBusinessComponent<T,TId> where T : class
    {
        T? Add(T entity);
        T? Modify(TId id, T entity);
        T? Remove(TId id);
        IEnumerable<T> FetchAll();
        T? FetchById(TId id);
    }
}
