using AuthenticationExample.Models;
using AuthenticationExample.ViewModels;
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

        public IEnumerable<CountProductByBrandVM> CountProductByBrandVM()
        {
            var joinedData = _context.Products.Join(_context.Brands,
                                              p => p.BrandId,
                                              b => b.BrandId,
                                              (p, b) => new
                                              {
                                                  BrandName = b.BrandName,
                                                  ProductId = p.ProductId,
                                                  ProductName = p.ProductName
                                              });
            var products_brands = joinedData.GroupBy(x => x.BrandName).Select(x => new CountProductByBrandVM
            {
                BrandName = x.Key,
                ProductCount = x.Count()
            });

            return products_brands;
        }

        public Product? DeleteProduct(int? id)
        {
            var product = _context.Products.SingleOrDefault(x => x.ProductId == id!.Value);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            return null;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Product> GetProductByCategory(int? categoryId)
        {
            return _context.Products.Include(x => x.Category).Where(x => x.CategoryId == categoryId);
        }

        public Product? GetProductById(int? id) => _context.Products.Include(x => x.Brand).Include(x => x.Category).SingleOrDefault(x => x.ProductId == id!.Value);

        public IEnumerable<Product> GetProducts() => _context.Products.Include(x => x.Brand).Include(x => x.Category).ToList();

    }
}
