using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models
{
    public class ProductBrand
    {
        [Key]
        public int ProductBrandId { get; set; }
        [Required]
        public string? ProductBrandName { get; set; }
    }
}
