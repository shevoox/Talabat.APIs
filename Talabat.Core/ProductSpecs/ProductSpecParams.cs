namespace Talabat.Core.ProductSpecs
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 10;
        public int pageSize = 5;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > 10 ? 10 : MaxPageSize; }
        }
        public int PageIndex { get; set; } = 1;
        public string? sort { get; set; }
        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

        public int? brandId { get; set; }
        public int? categoryId { get; set; }

    }
}
