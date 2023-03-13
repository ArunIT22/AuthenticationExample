using AuthenticationExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationExample.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [Route("Products/GetProduct/{id?}")]
        public IActionResult GetProducts(int? id = null)
        {
            ViewBag.Categories = _repository.GetCategories();
            //if (id != null)
            //{
            //    var productByCategory = _repository.GetProductByCategory(id.Value);
            //    if (productByCategory.Any())
            //    {
            //        return View(productByCategory);
            //    }
            //    return BadRequest();
            //}
            //var products = _repository.GetProducts();
            //return View(products);
            if (id <= 0)
            {
                return BadRequest();
            }
            return View();
        }

        public IActionResult Index(int? id = null)
        {
            var products = _repository.GetProducts();
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            var products = _repository.GetProductById(id!.Value);
            if (products == null || id == null)
            {
                return NotFound();
            }
            return View(products);
        }

        public IActionResult Delete(int? id)
        {
            var products = _repository.GetProductById(id!.Value);
            if (id == null || products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int? id)
        {
            var products = _repository.DeleteProduct(id!.Value);
            if (products == null || id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ProductByBrand()
        {
            return View();
        }
    }
}
