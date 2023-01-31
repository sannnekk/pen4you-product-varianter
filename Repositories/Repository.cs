using ProductVarianter.Loaders;
using ProductVarianter.Models;

namespace ProductVarianter.Repositories
{
    public class Repository<T> : IRepository<T> where T : IModel, new()
    {
        private readonly ILoader loader;

        public Repository(ILoader loader)
        {
            this.loader = loader;
        }

        public async Task Delete(T item)
        {
            await this.loader.Delete<T>(item);
        }

        public async Task<IEnumerable<T>> Get(int start = 0, int count = -1)
        {
            return await this.loader.Get<T>(start, count);
        }

        public async Task<IEnumerable<T>> Get(Func<T, bool> predicate, int count = -1)
        {
            return (await this.Get(0)).Where(predicate);
        }

        public async Task Change(T item)
        {
            await this.loader.Update<T>(item);
        }
    }
}