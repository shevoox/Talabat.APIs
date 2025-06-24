using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetWithSpecAsync(Ispecifications<T> spec);
        Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecifications<T> spec);
        Task<int> GetCountAsync(Ispecifications<T> spec);
    }
}
