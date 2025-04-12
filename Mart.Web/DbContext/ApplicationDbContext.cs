using Mart.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace Mart.Web.DbContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
                        : IdentityDbContext<AccountUser>(options)
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductAgeGroup> ProductAgeGroups { get; set; }
    }
}
