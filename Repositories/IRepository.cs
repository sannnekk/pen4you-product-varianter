using ProductVarianter.Models;

namespace ProductVarianter.Repositories
{
    public interface IRepository<T> where T : IModel, new()
    {
        Task<IEnumerable<T>> Get(int start = 0, int count = -1);

        Task<IEnumerable<T>> Get(Func<T, bool> predicate, int count = -1);

        Task Change(T item);

        Task Delete(T item);
    }
}