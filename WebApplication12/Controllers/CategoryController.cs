using Interfaces.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.Entities;

namespace WebApplication12.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult ProductsByCategory(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null) return NotFound();

            ViewBag.CategoryName = category.Name;
            var products = _productService.GetAllProducts()
                                           .Where(p => p.CategoryId == categoryId);
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult EditProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteProductConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
