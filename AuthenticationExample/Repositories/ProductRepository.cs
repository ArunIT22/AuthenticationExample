using AuthenticationExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationExample.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BikeStoresContext _context;

        public ProductRepository(BikeStoresContext context)
        {
            _context = context;
        }

        public Product? DeleteProduct(int? id)
        {
            var product = _context.Products.SingleOrDefault(x => x.ProductId == id!.Value);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            return null;
        }

        public Product? GetProductById(int? id) => _context.Products.Include(x => x.Brand).Include(x => x.Category).SingleOrDefault(x => x.ProductId == id!.Value);

        public IEnumerable<Product> GetProducts()=> _context.Products.Include(x => x.Brand).Include(x => x.Category).ToList();

    }
}
