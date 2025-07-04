using Talabat.Core.Repositories;

namespace Talabat.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        ///public IGenaricRepository<Product> ProductRepository { get; set; }
        ///public IGenaricRepository<ProductBrand> BrandsRepository { get; set; }
        ///public IGenaricRepository<ProductCategory> CategoryRepository { get; set; }
        ///public IGenaricRepository<DeliveryMethod> DeliveryMethodRepository { get; set; }
        ///public IGenaricRepository<OrderItem> OrderItemRepository { get; set; }
        ///public IGenaricRepository<Order> OrderRepository { get; set; }

        public IGenaricRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync();

    }
}
