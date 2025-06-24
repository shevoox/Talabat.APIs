using Talabat.Core.Entityies;
using Talabat.Core.ProductSpecs;

namespace Talabat.Core.Specifications
{
    public class ProductWithFilterationForCountSpecifications : BaseSpecifications<Product>
    {
        public ProductWithFilterationForCountSpecifications(ProductSpecParams specParams) :
            base(P =>
            (string.IsNullOrEmpty(specParams.Search) || P.Name.Contains(specParams.Search)) &&
        (!specParams.brandId.HasValue || P.BrandId == specParams.brandId.Value)
        && (!specParams.categoryId.HasValue || P.CategoryId == specParams.categoryId.Value))
        {

        }
    }
}
