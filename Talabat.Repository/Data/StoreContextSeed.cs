using System.Text.Json;
using Talabat.Core.Entityies;

namespace Talabat.Repository.Data
{
    internal class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext _dbContext)
        {
            var brandsData = File.ReadAllText("../Talabat.Repository/Data Seeding JSON Files/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            foreach (var brand in brands)
            {
                _dbContext.Set<ProductBrand>().Add(brand);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
