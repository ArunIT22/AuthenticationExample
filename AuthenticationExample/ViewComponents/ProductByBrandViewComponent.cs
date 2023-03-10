using AuthenticationExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationExample.ViewComponents
{
    public class ProductByBrandViewComponent : ViewComponent
    {
        private readonly IProductRepository _repository;

        public ProductByBrandViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var result = _repository.CountProductByBrandVM();
            return View("_BrandList", result);
        }
    }
}
