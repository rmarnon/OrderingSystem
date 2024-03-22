using FluentAssertions;
using Moq;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services;
using Ordering.System.Tests.Mocks;

namespace Ordering.System.Tests.UnitTests
{
    public class ProductServiceTest
    {
        [Fact]
        public async void Should_Create_Product_And_Should_Be_Returned_By_Repository()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var repository = new Mock<IProductRepository>();

            repository.Setup(repo =>
                repo.CreateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(product);

            var service = new ProductService(repository.Object);

            // Act
            var productData = await service.CreateProductAsync(product);

            // Assert
            productData.Should().Be(product);
            repository.Verify(repo => repo.CreateProductAsync(product), Times.Once);
        }

        [Fact]
        public async void Should_Update_Product_And_Should_Be_Returned_By_Repository()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var updatedProduct = ProductMock.GetUpdatedProduct(product);
            var repository = new Mock<IProductRepository>();

            repository.Setup(repo =>
               repo.GetProductByIdAsync(It.IsAny<Guid>()))
               .ReturnsAsync(product);

            repository.Setup(repo =>
                repo.UpdateProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(updatedProduct);

            var service = new ProductService(repository.Object);

            // Act
            var productData = await service.UpdateProductAsync(product);

            // Assert
            productData.Should().Be(updatedProduct);
            repository.Verify(repo => repo.UpdateProductAsync(product), Times.Once);
        }

        [Fact]
        public async void Should_GetProductById_And_Returned_By_Repository()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var repository = new Mock<IProductRepository>();

            repository.Setup(repo =>
                repo.GetProductByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(product);

            var service = new ProductService(repository.Object);

            // Act
            var productData = await service.GetProductByIdAsync(product.Id);

            // Assert
            productData.Should().BeEquivalentTo(product);
        }

        [Fact]
        public async void Should_Delete_Product_With_Success()
        {
            // Arrange
            var product = ProductMock.GetValidProduct();
            var repository = new Mock<IProductRepository>();

            repository.Setup(repo =>
                repo.DeleteProductAsync(It.IsAny<Product>()))
                .ReturnsAsync(product);

            var service = new ProductService(repository.Object);

            // Act
            var productData = await service.DeleteProductByIdAsync(product.Id);

            // Assert
            productData.Should().BeNull();
        }

        [Fact]
        public async void Should_Verify_If_Products_Exists_And_Return_True()
        {
            // Arrange
            var repository = new Mock<IProductRepository>();

            repository.Setup(repo =>
                repo.ExistProductByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var service = new ProductService(repository.Object);

            // Act
            var result = await service.ExistProductAsync(Guid.NewGuid());

            // Assert
            result.Should().BeTrue();
        }
    }
}
