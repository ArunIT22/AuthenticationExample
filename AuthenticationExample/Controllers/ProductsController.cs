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

        public IActionResult Index()
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
            if(products == null || id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
