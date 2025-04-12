using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models
{
    public class ProductAgeGroup
    {
        [Key]
        public int ProductAgeGroupId { get; set; }
        [Required]
        public string? ProductAgeGroupName { get; set; }
        public int? ProductAgeGroupStartAge { get; set; }
        public int? ProductAgeGroupEndAge { get; set; }
    }
}
