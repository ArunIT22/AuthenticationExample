using AuthenticationExample.Models;
using AuthenticationExample.ViewModels;

namespace AuthenticationExample.Repositories
{
    public interface IRepository
    {
        UserDetail ValidateUser(string username, string password);
    }

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product? GetProductById(int? id);

        Product? DeleteProduct(int? id);

        IEnumerable<CountProductByBrandVM> CountProductByBrandVM();
    }
}
