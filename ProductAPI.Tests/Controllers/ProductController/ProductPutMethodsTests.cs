using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Tests.Utils;
using ProductAPI.Services;

namespace ProductAPI.Controllers.UnitTests
{

    public class ProductControllerPutMethodsTests
    {
        [Fact]

        public void UpdateProduct_ExistingId_ReturnsProduct()
        {
            // Arrange - Given
            ProductController controller = ProductUtils.GetTestProductControllerStub();
            int productId = 1;
            Product updatedProduct = new Product { Id = productId, Name = "Mack PRO", Price = 1500 };
            // Act - When
            var result = controller.Update(productId, updatedProduct);

            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(updatedProduct.Name, result.Name);
            Assert.Equal(updatedProduct.Price, result.Price);
            Assert.Equal(productId, result.Id); // Assuming the ID remains the same

        }


    }
}