using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ordering.System.Api.Controllers;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Services.Interfaces;
using Ordering.System.Api.Validators;
using Ordering.System.Tests.Mocks;

namespace Ordering.System.Tests.UnitTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Should_Validate_Product()
        {
            //Arrange
            var product = ProductMock.GetValidProduct();

            //Act
            var result = new ProductValidator().Validate(product);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_Fail_To_Validate_Product()
        {
            //Arrange
            var product = ProductMock.GetInvalidProduct();

            //Act
            var result = new ProductValidator().Validate(product);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(6);
        }

        [Fact]
        public async Task Should_Return_Product_By_Id()
        {
            var product = ProductMock.GetValidProduct();
            var service = new Mock<IProductService>();

            service.Setup(service =>
                service.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var controller = new ProductController(service.Object);

            // Act
            var result = await controller.GetProductById(Guid.NewGuid());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeOfType<Product>();
        }

        [Fact]
        public async Task Should_Return_Products()
        {
            var product1 = ProductMock.GetValidProduct();
            var product2 = ProductMock.GetValidProduct();
            var products = new List<Product>() { product1, product2 };

            var service = new Mock<IProductService>();
            service.Setup(service => service.GetProductsAsync()).ReturnsAsync(products);

            var controller = new ProductController(service.Object);

            // Act
            var result = await controller.GetProducts();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async Task Should_Create_New_Product()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var service = new Mock<IProductService>();

            service.Setup(service =>
                service.CreateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(product);

            var controller = new ProductController(service.Object);

            // Act
            var result = await controller.CreateProduct(product);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeOfType<Product>();
        }

        [Fact]
        public async Task Should_Update_Product()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var updatedProduct = ProductMock.GetUpdatedProduct(product);
            var service = new Mock<IProductService>();

            service.Setup(service =>
                service.CreateProductAsync(product))
                .ReturnsAsync(updatedProduct);

            var controller = new ProductController(service.Object);

            // Act
            var result = await controller.CreateProduct(product);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeOfType<Product>();
        }

        [Fact]
        public async Task Should_Delete_Product()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var service = new Mock<IProductService>();

            service.Setup(service =>
                service.DeleteProductByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(product);

            var controller = new ProductController(service.Object);

            // Act
            var result = await controller.DeleteProduct(Guid.NewGuid());

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}

