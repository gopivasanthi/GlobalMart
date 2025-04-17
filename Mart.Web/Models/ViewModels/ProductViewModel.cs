using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime? ProductManufactureDate { get; set; }
        public DateTime? ProductExpiryDate { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductBrandId { get; set; }
        public int? ProductColorId { get; set; }
        public int? ProductAgeGroupId { get; set; }
        public IEnumerable<SelectListItem>? ProductCategories { get; set; }
        public IEnumerable<SelectListItem>? ProductColors { get; set; }
        public IEnumerable<SelectListItem>? ProductAgeGroups { get; set; }
        public IEnumerable<SelectListItem>? ProductBrands { get; set; }
    }
}
