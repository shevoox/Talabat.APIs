using System.Collections;
using Talabat.Core;
using Talabat.Core.Repositories;
using Talabat.Infrastructure.Data;

namespace Talabat.Infrastructure
{
    //public class UnitOfWork : IUnitOfWork
    //  {
    //      private Hashtable _repositories;
    //      private readonly StoreContext _dbContext;

    //      ///public IGenaricRepository<Product> ProductRepository { get; set; }
    //      ///public IGenaricRepository<ProductBrand> BrandsRepository { get; set; }
    //      ///public IGenaricRepository<ProductCategory> CategoryRepository { get; set; }
    //      ///public IGenaricRepository<DeliveryMethod> DeliveryMethodRepository { get; set; }
    //      ///public IGenaricRepository<OrderItem> OrderItemRepository { get; set; }
    //      ///public IGenaricRepository<Order> OrderRepository { get; set; }


    //      public UnitOfWork(StoreContext dbContext)
    //      {
    //          _dbContext = dbContext;
    //          _repositories = new Hashtable();
    //          ///ProductRepository = new GenaricRepository<Product>(_dbContext);
    //          ///BrandsRepository = new GenaricRepository<ProductBrand>(_dbContext);
    //          ///CategoryRepository = new GenaricRepository<ProductCategory>(_dbContext);
    //          ///DeliveryMethodRepository = new GenaricRepository<DeliveryMethod>(_dbContext);
    //          ///OrderItemRepository = new GenaricRepository<OrderItem>(_dbContext);
    //          ///OrderRepository = new GenaricRepository<Order>(_dbContext);


    //      }
    //      public async Task<int> CompleteAsync()
    //      {
    //          return await _dbContext.SaveChangesAsync();
    //      }

    //      public async ValueTask DisposeAsync()
    //      {
    //          await _dbContext.DisposeAsync();
    //      }

    //      public IGenaricRepository<TEntity> Repository<TEntity>() where TEntity : class
    //      {
    //          var key = typeof(TEntity).Name;
    //          if (!_repositories.ContainsKey(key))
    //          {
    //              var repository = new GenaricRepository<TEntity>(_dbContext);
    //              _repositories.Add(key, repository);
    //          }
    //          return _repositories[key] as IGenaricRepository<TEntity>;
    //      }
    //  }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbContext;
        private readonly Hashtable _repositories = new();

        public UnitOfWork(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenaricRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new GenaricRepository<TEntity>(_dbContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenaricRepository<TEntity>)_repositories[type];
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }


    }

}
