using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Tests.Stubs
{
    public class ProductServiceStub : IProductService
    {
        private List<Product> _products;

        public ProductServiceStub()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200 },
                new Product { Id = 2, Name = "Phone", Price = 800 }
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);;
        }

        public Product Create(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            return product;
        }

        public Product Update(int id, Product updatedProduct)
        {
            return updatedProduct;
        }

        public Product Delete(int id)
        {
            return _products[0];
        }
    }
}