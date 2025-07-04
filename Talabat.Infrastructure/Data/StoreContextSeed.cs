using System.Text.Json;
using Talabat.Core.Entityies;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext dbContext)
        {
            if (!dbContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/delivery.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands?.Count > 0)
                {
                    dbContext.ProductBrands.AddRange(brands);
                }
            }

            if (!dbContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products?.Count > 0)
                {
                    dbContext.Products.AddRange(products);
                }
            }

            if (!dbContext.DeliveryMethods.Any())
            {
                var deliveryData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                if (methods?.Count > 0)
                {
                    dbContext.DeliveryMethods.AddRange(methods);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
