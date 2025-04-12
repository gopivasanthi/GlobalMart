using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models
{
    public class ProductColor
    {
        [Key]
        public int ProductColorId { get; set; }
        [Required]
        public string? ProductColorName { get; set; }
        public string? ProductColorAsciiCode { get; set; }
    }
}
