using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Entityies
{
    public class ProductBrand : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
