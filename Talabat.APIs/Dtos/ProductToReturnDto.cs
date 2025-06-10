namespace Talabat.APIs.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        //[ForeignKey(nameof(Product.Brand))]
        public int BrandId { get; set; }//foregin key
        public string Brand { get; set; }//Navigation PROP
        public int CategoryId { get; set; }//foregin key
        public string Category { get; set; }
    }
}
