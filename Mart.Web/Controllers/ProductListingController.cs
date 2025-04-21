using Mart.Web.DbContext;
using Mart.Web.Models;
using Mart.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mart.Web.Controllers
{
    [Authorize(Policy = "MustBeAMember")]
    public class ProductListingController(ApplicationDbContext dbContext) : Controller
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IActionResult> Index()
        {
            List<Product> listOfProducts = await _dbContext.Products.ToListAsync();
            return View(listOfProducts);
        }
        [HttpGet]
        [Authorize(Policy = "MustBeAnAdmin")]
        public async Task<IActionResult> AddProduct()
        {
            ProductViewModel productViewModel = new();

            var productCategories = await _dbContext.ProductCategories.ToListAsync();
            //old way of doing it
            List<SelectListItem> productCatSelectListItem = new List<SelectListItem>();
            foreach(var prodcat in productCategories)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = prodcat.CategoryName,
                    Value = prodcat.CategoryId.ToString(),
                };
                productCatSelectListItem.Add(selectListItem);
            }
            //new way based on linq
            var productCategorySelectListItems = productCategories.Select(prodcate => new SelectListItem
            {
                Text = prodcate.CategoryName,
                Value = prodcate.CategoryId.ToString()
            }).ToList();

            productViewModel.ProductCategories = productCategorySelectListItems;

            productViewModel.ProductColors = (await _dbContext.ProductColors.ToListAsync())
                                        .Select(prodColor => new SelectListItem
                                        {
                                            Text = prodColor.ProductColorName,
                                            Value = prodColor.ProductColorId.ToString()
                                        });

            productViewModel.ProductBrands = (await _dbContext.ProductBrands.ToListAsync())
                                                    .Select(prodBrand => new SelectListItem
                                                    {
                                                        Text = prodBrand.ProductBrandName,
                                                        Value = prodBrand.ProductBrandId.ToString()
                                                    });
            productViewModel.ProductAgeGroups = (await _dbContext.ProductAgeGroups.ToListAsync())
                                                    .Select(prodAgeGroup => new SelectListItem
                                                    {
                                                        Text = prodAgeGroup.ProductAgeGroupName,
                                                        Value = prodAgeGroup.ProductAgeGroupId.ToString()
                                                    });

            return View(productViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }
            try
            {
                var productBrand = await _dbContext.ProductBrands.FindAsync(productViewModel.ProductBrandId);
                var productAgeGroup = await _dbContext.ProductAgeGroups.FindAsync(productViewModel.ProductAgeGroupId);
                var productCategory = await _dbContext.ProductCategories.FindAsync(productViewModel.CategoryId);

                Product product = new()
                {
                    ProductId = productViewModel.ProductId,
                    ProductAgeGroup = productAgeGroup,
                    ProductName = productViewModel.ProductName,
                    ProductDescription = productViewModel.ProductDescription,
                    ProductCategory = productCategory,
                    ProductBrand = productBrand,
                    ProductColor = await _dbContext.ProductColors.FindAsync(productViewModel.ProductColorId),
                    ProductExpiryDate = productViewModel.ProductExpiryDate,
                    ProductManufactureDate = productViewModel.ProductManufactureDate
                };
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(productViewModel);
            }
        }
    }
}
