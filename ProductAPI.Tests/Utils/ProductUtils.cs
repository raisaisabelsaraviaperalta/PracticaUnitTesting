using ProductAPI.Models;
using ProductAPI.Controllers;
using ProductAPI.Services;
using ProductAPI.Tests.Stubs;

namespace ProductAPI.Tests.Utils
{
    public static class ProductUtils
    {
        public static List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1200 },
                new Product { Id = 2, Name = "Phone", Price = 800 }
            };
        }

        public static ProductController GetTestProductControllerStub()
        {
            ProductController controller = new ProductController(new ProductServiceStub());
            return controller;
        }
    }
}
