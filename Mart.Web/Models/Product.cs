﻿using System.ComponentModel.DataAnnotations;

namespace Mart.Web.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime? ProductManufactureDate { get; set; }
        public DateTime? ProductExpiryDate { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public ProductBrand? ProductBrand { get; set; }
        public ProductColor? ProductColor { get; set; }
        public ProductAgeGroup? ProductAgeGroup { get; set; }

    }
}
