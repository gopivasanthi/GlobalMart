using Mart.Web.DbContext;
using Mart.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mart.Web.Controllers
{
    public class ProductAdminController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        #region Product Categories
        public async Task<IActionResult> ProductCategories()
        {
            var categories = await _dbContext.ProductCategories.ToListAsync();
            return View(categories);
        }
        public IActionResult AddCategory()
        {
            ProductCategory productCategory = new ();
            return View(productCategory);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dbContext.ProductCategories.AddAsync(productCategory);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductCategories");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productCategory);
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            var category = await _dbContext.ProductCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.ProductCategories.Update(productCategory);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductCategories");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productCategory);
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var category = await _dbContext.ProductCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _dbContext.ProductCategories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ProductCategories");
        }

        #endregion

        #region Product Brands
        #endregion

        #region Product Colors
        #endregion

        #region Product Age Limit
        #endregion
    }
}
