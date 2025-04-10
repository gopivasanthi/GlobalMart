﻿namespace Mart.Web.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime? ProductManufactureDate { get; set; }
        public DateTime? ProductExpiryDate { get; set; }

    }
}
