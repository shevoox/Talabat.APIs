using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetWithSpecAsync(Ispecifications<T> spec);
        Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecifications<T> spec);
        Task<int> GetCountAsync(Ispecifications<T> spec);
        Task AddAsync(T entiy);
        void Update(T entiy);
        void Delete(T entiy);
    }
}
