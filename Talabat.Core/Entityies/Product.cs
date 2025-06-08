namespace Talabat.Core.Entityies
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //[ForeignKey(nameof(Product.Brand))]
        public int BrandId { get; set; }//foregin key
        public ProductBrand Brand { get; set; }//Navigation PROP
        public int CategoryId { get; set; }//foregin key
        public ProductCategory Category { get; set; }
    }
}
