using Microsoft.EntityFrameworkCore;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Infrastructure.Data;

namespace Talabat.Infrastructure
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly StoreContext _dbcontext;

        public GenaricRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecifications<T> spec)
        {
            return await ApplySpecifications(spec).AsNoTracking().ToListAsync();
        }
        public async Task<T?> GetWithSpecAsync(Ispecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(Ispecifications<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecifications(Ispecifications<T> spec)
        {
            return SpecificationsEvaluater<T>.GetQuery(_dbcontext.Set<T>(), spec);
        }

        public async Task AddAsync(T entiy)
            => await _dbcontext.AddAsync(entiy);

        public void Update(T entiy)
            => _dbcontext.Update(entiy);

        public void Delete(T entiy)
            => _dbcontext.Remove(entiy);
    }
}
