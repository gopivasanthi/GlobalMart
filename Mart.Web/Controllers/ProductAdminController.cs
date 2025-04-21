using Mart.Web.DbContext;
using Mart.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mart.Web.Controllers
{
    [Authorize(Policy = "MustBeAnAdmin")]
    public class ProductAdminController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public IActionResult Index()
        {
            return View();
        }

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
        public async Task<IActionResult> ProductBrands()
        {
            var brands = await _dbContext.ProductBrands.ToListAsync();
            return View(brands);
        }
        public IActionResult AddBrand()
        {
            ProductBrand productBrand = new();
            return View(productBrand);
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dbContext.ProductBrands.AddAsync(productBrand);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductBrands");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productBrand);
        }
        public async Task<IActionResult> EditBrand(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var brand = await _dbContext.ProductBrands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        [HttpPost]
        public async Task<IActionResult> EditBrand(ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.ProductBrands.Update(productBrand);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductBrands");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productBrand);
        }
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var brand = await _dbContext.ProductBrands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            _dbContext.ProductBrands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ProductBrands");
        }

        #endregion

        #region Product Colors
        public async Task<IActionResult> ProductColors()
        {
            var colors = await _dbContext.ProductColors.ToListAsync();
            return View(colors);
        }
        public IActionResult AddColor()
        {
            ProductColor productColor = new();
            return View(productColor);
        }
        [HttpPost]
        public async Task<IActionResult> AddColor(ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dbContext.ProductColors.AddAsync(productColor);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductColors");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productColor);
        }
        public async Task<IActionResult> EditColor(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var color = await _dbContext.ProductColors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }
        [HttpPost]
        public async Task<IActionResult> EditColor(ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.ProductColors.Update(productColor);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductColors");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productColor);
        }
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var color = await _dbContext.ProductColors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            _dbContext.ProductColors.Remove(color);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ProductColors");
        }

        #endregion

        #region Product Age Limit
        public async Task<IActionResult> ProductAgeGroups()
        {
            var ageGroups = await _dbContext.ProductAgeGroups.ToListAsync();
            return View(ageGroups);
        }
        public IActionResult AddAgeGroup()
        {
            ProductAgeGroup productAgeGroup = new();
            return View(productAgeGroup);
        }
        [HttpPost]
        public async Task<IActionResult> AddAgeGroup(ProductAgeGroup productAgeGroup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dbContext.ProductAgeGroups.AddAsync(productAgeGroup);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductAgeGroups");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productAgeGroup);
        }
        public async Task<IActionResult> EditAgeGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var ageGroup = await _dbContext.ProductAgeGroups.FindAsync(id);
            if (ageGroup == null)
            {
                return NotFound();
            }
            return View(ageGroup);
        }
        [HttpPost]
        public async Task<IActionResult> EditAgeGroup(ProductAgeGroup productAgeGroup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.ProductAgeGroups.Update(productAgeGroup);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("ProductAgeGroups");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(productAgeGroup);
        }
        public async Task<IActionResult> DeleteAgeGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var ageGroup = await _dbContext.ProductAgeGroups.FindAsync(id);
            if (ageGroup == null)
            {
                return NotFound();
            }
            _dbContext.ProductAgeGroups.Remove(ageGroup);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ProductAgeGroups");
        }
        #endregion
    }
}
