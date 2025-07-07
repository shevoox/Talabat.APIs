using System.Text.Json;
using Talabat.Core.Entityies.Order_Aggregate;

namespace Talabat.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext dbContext)
        {
            try
            {
                Console.WriteLine("🚀 Seeding started...");

                // 🔹 Seeding Product Brands
                //if (!dbContext.ProductBrands.Any())
                //{
                //    Console.WriteLine("🟡 Seeding Brands...");

                //    var brandsData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/brands.json");
                //    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                //    if (brands != null && brands.Any(b => !string.IsNullOrEmpty(b.Name)))
                //    {
                //        dbContext.ProductBrands.AddRange(brands);
                //        Console.WriteLine($"✅ Added {brands.Count} brands");
                //    }
                //}

                // 🔹 Seeding Product Categories
                //if (!dbContext.ProductCategories.Any())
                //{
                //    Console.WriteLine("🟡 Seeding Categories...");
                //    var categoriesData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/categories.json");
                //    var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                //    if (categories != null && categories.Any(c => !string.IsNullOrEmpty(c.Name)))
                //    {
                //        dbContext.ProductCategories.AddRange(categories);
                //        Console.WriteLine($"✅ Added {categories.Count} categories");
                //    }
                //}

                // 🔹 Seeding Products
                //if (!dbContext.Products.Any())
                //{
                //    Console.WriteLine("🟡 Seeding Products...");

                //    var productsData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/products.json");
                //    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                //    if (products != null && products.Any(p => !string.IsNullOrEmpty(p.Name)))
                //    {
                //        dbContext.Products.AddRange(products);
                //        Console.WriteLine($"✅ Added {products.Count} products");
                //    }
                //}

                // 🔹 Seeding Delivery Methods
                if (!dbContext.DeliveryMethods.Any())
                {
                    Console.WriteLine("🟡 Seeding Delivery Methods...");
                    var deliveryData = File.ReadAllText("../Talabat.Infrastructure/Data/Data Seeding JSON Files/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);

                    if (methods != null && methods.Any(m => !string.IsNullOrEmpty(m.ShortName)))
                    {
                        dbContext.DeliveryMethods.AddRange(methods);
                        Console.WriteLine($"✅ Added {methods.Count} delivery methods");
                    }
                }

                try
                {
                    await dbContext.SaveChangesAsync();
                    Console.WriteLine("🎉 Seeding completed successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("🔥 Error while seeding:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException?.Message);
                    throw;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error during seeding:");
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("➡ INNER: " + ex.InnerException.Message);
                }
            }
        }
    }
}
