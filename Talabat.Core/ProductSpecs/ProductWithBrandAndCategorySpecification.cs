using Talabat.Core.Entityies;
using Talabat.Core.Specifications;

namespace Talabat.Core.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecification : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecification() : base()
        {
            AddIncludes();
        }



        public ProductWithBrandAndCategorySpecification(int id) : base(p => p.Id == id)
        {
            AddIncludes();
        }
        private void AddIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
