using Mart.Web.DbContext;
using Mart.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mart.Web.Controllers
{
    public class ProductListingController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IActionResult> Index()
        {
            List<Product> listOfProducts = await _dbContext.Products.ToListAsync();
            return View(listOfProducts);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            Product product = new();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(product);
            }
        }
    }
}
