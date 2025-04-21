using Mart.Web.DbContext;
using Mart.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mart.Web.Controllers
{
    [Authorize(Policy = "MustBeAMember")]
    public class ProductDetailsController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task<IActionResult> DisplayProductDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (id == 0)
            {
                return NotFound();
            }
            try
            {
                var product = await _dbContext.Products.FindAsync(id);
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return NotFound();
            }
        }
    }
}
