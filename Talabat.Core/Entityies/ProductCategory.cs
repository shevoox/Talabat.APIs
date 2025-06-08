using System.ComponentModel.DataAnnotations;

namespace Talabat.Core.Entityies
{
    public class ProductCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
