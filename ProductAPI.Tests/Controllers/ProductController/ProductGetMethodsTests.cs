using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Tests.Utils;
using ProductAPI.Tests.Stubs;
using ProductAPI.Services;
using Moq;


namespace ProductAPI.Controllers.UnitTests
{
    public class ProductGetMethodsTests
    {
        // Unit Test
        [Fact]
        public void GetAll_ExistingProducts_WithAllProducts()
        {
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.GetAll()).Returns(
                new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Price = 1200 },
                    new Product { Id = 2, Name = "Phone", Price = 800 }
                }
            );
            // Arrange - Given
            ProductController controller = new ProductController(mockService.Object);

            // Act - When
            var result = controller.GetAll();
            
            // Assert - Then
            // var okResult = Assert.IsType<OkObjectResult>(result.Result);
            // var products = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, result.Count());
            Assert.Equal("Laptop", result[0].Name);
            Assert.Equal(1200, result[0].Price);
            Assert.Equal("Phone", result[1].Name);
            Assert.Equal(800, result[1].Price);
        }
        
        // Unit Test
        [Fact]
        public void GetById_ExistingId_ReturnsProduct()
        {
            // Arrange - Given
            ProductController controller = new ProductController(new ProductServiceStub());
            int productId = 1;
            
            // Act - When
            var result = controller.GetById(productId);
            
            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal("Product Name", result.Name);
            Assert.Equal(1200, result.Price);
        }

        // Unit Test => Integration Test
        [Fact]
        public void GetById_NonExistingId_ReturnsNull()
        {
            // Arrange - Given
            ProductService productService = new ProductService();
            productService.Create(new Product { Id = 1, Name = "Laptop", Price = 1200 });
            productService.Create(new Product { Id = 2, Name = "Phone", Price = 800 });
            ProductController controller = new ProductController(productService);
            int productId = 10;

            // Act - When
            Product result = controller.GetById(productId);

            Console.WriteLine("Product ID: "+ result.Id);
            Console.WriteLine($"Product Name: {result.Name}");

            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(-1, result.Id);
            Assert.Equal("Product Name", result.Name);
        }
    }
}
