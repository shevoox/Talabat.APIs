using Talabat.Core.Entityies;
using Talabat.Core.Specifications;

namespace Talabat.Core.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecification : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecification(string? sort, int? brandId, int? categoryId) : base(P =>
        (!brandId.HasValue || P.BrandId == brandId.Value)
        && (!categoryId.HasValue || P.CategoryId == categoryId.Value))
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);


            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            else
                AddOrderBy(P => P.Name);
        }



        public ProductWithBrandAndCategorySpecification(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }

    }
}
