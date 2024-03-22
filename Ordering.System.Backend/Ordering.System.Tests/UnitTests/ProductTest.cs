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
    public class AlunoTest
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
            var product = ProductMock.GetValidProduct();
            product.Code = string.Empty;
            product.Description = string.Empty;
            product.Value = -3.14;
            product.RegistrationDate = DateTime.Today.AddDays(1);

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
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(service =>
                service.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var controller = new ProductController(serviceMock.Object);

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

            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(service => service.GetProductsAsync()).ReturnsAsync(products);

            var controller = new ProductController(serviceMock.Object);

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
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(service =>
                service.CreateProductAsync(It.IsAny<Product>())).ReturnsAsync(product);

            var controller = new ProductController(serviceMock.Object);

            // Act
            var result = await controller.CreateProduct(product);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeOfType<Product>();
        }

        [Fact]
        public async Task Should_Update_New_Product()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(service =>
                service.CreateProductAsync(It.IsAny<Product>())).ReturnsAsync(product);

            var controller = new ProductController(serviceMock.Object);

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
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(service =>
                service.DeletProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

            var controller = new ProductController(serviceMock.Object);

            // Act
            var result = await controller.DeleteProduct(Guid.NewGuid());

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}

