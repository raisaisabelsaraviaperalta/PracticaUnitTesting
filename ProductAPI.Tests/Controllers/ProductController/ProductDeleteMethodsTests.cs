using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Tests.Utils;
using ProductAPI.Services;

namespace ProductAPI.Controllers.UnitTests
{
    public class ProductDeleteMethodsTests
    {
        [Fact]
        public void DeleteProduct_ExistingId_ReturnsDeletedProduct()
        {
            // Arrange - Given
            ProductService productService = new ProductService();
            productService.Create(new Product { Id = 1, Name = "Laptop", Price = 1200 });
            productService.Create(new Product { Id = 2, Name = "Phone", Price = 800 });
            ProductController controller = new ProductController(productService);
            int productId = 1;
            
            // Act - When
            Product productDeleted = controller.Delete(productId);
            int productCount = controller.GetAll().Count();

            // Assert - Then
            Assert.NotNull(productDeleted);
            Assert.Equal(productId, productDeleted.Id);
            Assert.Equal("Laptop", productDeleted.Name);
            Assert.Equal(1200, productDeleted.Price);
            Assert.Equal(1, productCount);
        }
    }
}