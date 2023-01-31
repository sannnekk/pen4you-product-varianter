using ProductVarianter.Models;

namespace ProductVarianter.Loaders
{
    public interface ILoader
    {
        Task<IEnumerable<T>> Get<T>(int start = 0, int count = -1) where T : IModel, new();

        Task<T> Get<T>(string id) where T : IModel, new();

        Task Update<T>(T item) where T : IModel, new();

        Task Update<T>(IEnumerable<T> items) where T : IModel, new();

        Task Create<T>(T item) where T : IModel, new();

        Task Delete<T>(T item) where T : IModel, new();

        Task Delete<T>(string id) where T : IModel, new();
    }
}