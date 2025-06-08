namespace Talabat.Core.Repositories
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
