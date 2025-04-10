using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
