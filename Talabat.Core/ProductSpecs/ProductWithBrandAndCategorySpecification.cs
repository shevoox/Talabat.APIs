using Talabat.Core.Entityies;
using Talabat.Core.Specifications;

namespace Talabat.Core.ProductSpecs
{
    public class ProductWithBrandAndCategorySpecification : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecification(ProductSpecParams specParams)
            : base(P =>
               (string.IsNullOrEmpty(specParams.Search) || P.Name.Contains(specParams.Search)) &&
        (!specParams.brandId.HasValue || P.BrandId == specParams.brandId.Value)
        && (!specParams.categoryId.HasValue || P.CategoryId == specParams.categoryId.Value))
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);


            if (!string.IsNullOrEmpty(specParams.sort))
            {
                switch (specParams.sort)
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

            ApplyPagination((specParams.PageIndex - 1) * specParams.pageSize, specParams.pageSize);
        }



        public ProductWithBrandAndCategorySpecification(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }


    }
}
