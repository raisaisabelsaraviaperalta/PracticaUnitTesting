using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.Find(p => p.Id == id);
        }

        public Product? Create(Product product)
        {
            if (product.Price <= 0)
            {
                // No se crea si el precio no es válido
                return null;
            }

            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            return product;
        }

        public Product? Update(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return product;
        }

        public Product? Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;

            _products.Remove(product);
            return product;
        }
    }
}
